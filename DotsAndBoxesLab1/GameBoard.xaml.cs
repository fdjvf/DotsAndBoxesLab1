using System.ComponentModel;
using System.Windows;

namespace DotsAndBoxesLab1
{
    /// <summary>
    /// Interaction logic for GameBoard.xaml
    /// </summary>
    public partial class GameBoard :  Window, INotifyPropertyChanged
    {
        private State gameState;
        private VsState players;
        private int _PuntajePlayer1;
        private int _PuntajePlayer2;

        public event PropertyChangedEventHandler PropertyChanged;

        public GameBoard(State gameState, VsState players)
        {
            this.gameState = gameState;
            this.players = players;      
        
           
            InitializeComponent();
            DataContext = this;
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
                RaisePropertyChanged("PuntajePlayer1");
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
                RaisePropertyChanged("PuntajePlayer2");
            }
        }

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

    }
}
