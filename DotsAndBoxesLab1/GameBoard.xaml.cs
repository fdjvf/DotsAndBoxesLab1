﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DotsAndBoxesLab1
{
    /// <summary>
    /// Interaction logic for GameBoard.xaml
    /// </summary>
    public partial class GameBoard : Window, INotifyPropertyChanged
    {
        public State gameState { get; set; }
        public CompositeCollection ModelData { get; set; }
        public NegMax Alg { get; set; } = new NegMax();


        private VsState players;
        private int _PuntajePlayer1;
        private int _PuntajePlayer2;


        public event PropertyChangedEventHandler PropertyChanged;

        public GameBoard(State gameState, VsState players)
        {
            this.gameState = gameState;
            this.players = players;
            gameState.Jugador = false;//Max comienza osea la persona 
            ModelData = new CompositeCollection
            {
                new CollectionContainer() { Collection = gameState.ItemsDots },
                new CollectionContainer() { Collection = gameState.ItemsLine }
            };

            InitializeComponent();

        }


        #region OnChangedProperties
        public int PuntajePlayer1
        {
            get
            {
                return _PuntajePlayer1;
            }
            set
            {
                _PuntajePlayer1 = value;
                RaisePropertyChanged();
            }
        }
        public int PuntajePlayer2
        {
            get
            {
                return _PuntajePlayer2;
            }
            set
            {
                _PuntajePlayer2 = value;
                RaisePropertyChanged();
            }
        }



        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region DrawingLines
        public bool OnlyOneSelected { get; private set; } = false;
        public TAGInfo TAGPrevious { get; set; }
        private Ellipse PreviousEl { get; set; }

        private void MyCircle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Ellipse clickdot = ((Ellipse)sender);
            if (!OnlyOneSelected)
            {
                PreviousEl = clickdot;
                if (!gameState.Jugador)//0 Max
                {
                    clickdot.Stroke = Brushes.Blue;
                }
                else
                {
                    clickdot.Stroke = Brushes.Red;//Min Rojo
                }
                clickdot.StrokeThickness = 3;
                TAGPrevious = (TAGInfo)clickdot.Tag;
                OnlyOneSelected = true;
            }
            else
            {
                OnlyOneSelected = false;
                if (TAGPrevious.TAG == ((TAGInfo)clickdot.Tag).TAG)
                {
                    clickdot.Stroke = Brushes.Black;
                    clickdot.StrokeThickness = 1;
                }
                else
                {
                    double x1 = TAGPrevious.X + 10;
                    double x2 = ((TAGInfo)clickdot.Tag).X + 10;
                    double y1 = TAGPrevious.Y + 10;
                    double y2 = ((TAGInfo)clickdot.Tag).Y + 10;
                    DotLine linetodraw;
                    //Sirve para izquierda a derecha y arriba hacia abajo
                    linetodraw = gameState.ItemsLine.Where(x => (x.X1 == x1 && x.Y1 == y1 && x.X2 == x2 && x.Y2 == y2) ||
                    (x.X1 == x2 && x.Y1 == y2 && x.X2 == x1 && x.Y2 == y1)).SingleOrDefault();
                    linetodraw?.DrawLine();
                    PreviousEl.Stroke = Brushes.Black;
                    PreviousEl.StrokeThickness = 1;



                    //Dibujar rectangulito
                    Thread.Sleep(10);
                    DrawBox();
                    while (gameState.Jugador)
                    {
                        //Hacer jugada por parte de la maquina
                
                        var tem = Alg.MaxValue(gameState.BooleanRepresentation(), float.MinValue + 1, float.MaxValue - 1, 4);
                        BooleanState t = Alg.Result;
                        gameState.UpdateGame(t);
                        DrawBox();
                    }
              




                }

            }






        }
        private (int NewScore, bool turno) HelperMethodDraw(Brush ColorStroke)
        {
            int Score = 0;
            bool Continue = false;
            foreach (var item in gameState.ItemsBoxes)
            {
                if (item.IsComplete && !item.IsDrawn)
                {
                    item.StrokeColor = ColorStroke;
                    item.IsDrawn = true;
                    Score++;
                    Continue = true;
                }
            }
            return (Score, Continue);
        }
        private void DrawBox()
        {
            if (!gameState.Jugador)
            {
                var val = HelperMethodDraw(Brushes.Blue);
                PuntajePlayer1 = PuntajePlayer1 + val.NewScore;
                gameState.Jugador = !val.turno;
            }
            else
            {
                var val = HelperMethodDraw(Brushes.Red);
                PuntajePlayer2 = PuntajePlayer2 + val.NewScore;
                gameState.Jugador = val.turno;
            }

        }
        #endregion

    }
}
