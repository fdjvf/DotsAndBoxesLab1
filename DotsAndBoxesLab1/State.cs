using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace DotsAndBoxesLab1
{
    public class State
    {
        public Box[,] GameState { get; set; }
        public bool Jugador { get; set; }//0 Max 1 Min
        public List<List<DotLine>> Rows { get; set; } = new List<List<DotLine>>();
        public List<List<DotLine>> Columns { get; set; } = new List<List<DotLine>>();
        public List<Dot> ItemsDots { get; set; } = new List<Dot>();
        public List<DotLine> ItemsLine { get; set; } = new List<DotLine>();
        public List<Box> ItemsBoxes { get; set; } = new List<Box>();
        public int Size { get; set; }

        #region Initializing Game
        public void DotsModel()
        {
            int L = 0;
            Dot[,] temp = new Dot[Size + 1, Size + 1];
            for (int y = 0; y < Size + 1; y++)
                for (int x = 0; x < Size + 1; x++)
                {
                    L++;
                    Dot dottoadd = new Dot
                    {
                        X = x * 45,
                        Y = y * 45,
                        StrokeColor = Brushes.Black
                        ,
                        ThickStroke = 1,
                        TAG = new TAGInfo { TAG = L, X = x * 45, Y = y * 45 }
                    };
                    temp[y, x] = dottoadd;
                    ItemsDots.Add(dottoadd);
                }
            LineModel(temp);
        }

        private void LineModel(Dot[,] temp)
        {
            //We get the Rows
            for (int i = 0; i < Size + 1; i++)
            {
                List<DotLine> row = new List<DotLine>();
                for (int j = 0; j < Size; j++)
                {
                    DotLine tem = new DotLine
                    {
                        IsDraw = false,
                        StrokeColor = Brushes.Transparent,
                        X1 = temp[i, j].X,
                        Y1 = temp[i, j].Y,
                        X2 = temp[i, j + 1].X,
                        Y2 = temp[i, j + 1].Y

                    };
                    ItemsLine.Add(tem);
                    row.Add(tem);
                }
                Rows.Add(row);

            }
            //We get the Columns
            for (int i = 0; i < Size + 1; i++)
            {
                List<DotLine> column = new List<DotLine>();
                for (int j = 0; j < Size; j++)
                {
                    DotLine tem = new DotLine
                    {
                        IsDraw = false,
                        StrokeColor = Brushes.Transparent,
                        X1 = temp[j, i].X,
                        Y1 = temp[j, i].Y,
                        X2 = temp[j + 1, i].X,
                        Y2 = temp[j + 1, i].Y,
                    };
                    ItemsLine.Add(tem);
                    column.Add(tem);
                }
                Columns.Add(column);

            }


        }


        public State(int Size)
        {
            this.Size = Size - 1;
            GameState = CreateGameState();
        }

        private Box[,] CreateGameState()
        {
            DotsModel();
            var gamestate = new Box[Size, Size];
            ItemsBoxes = new List<Box>();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    DotLine up = Rows[i][j];
                    DotLine down = Rows[i + 1][j];

                    DotLine left = Columns[j][i];
                    DotLine right = Columns[j + 1][i];

                    gamestate[i, j] = new Box { Up = up, Left = left, Right = right, Down = down, X = up.X1, Y = up.Y1, StrokeColor = Brushes.Transparent };
                    ItemsBoxes.Add(gamestate[i, j]);
                }
            }

            return gamestate;

        }

        #endregion


        /*
        private List<List<DotLine>> CreateRows()
        {
            var row = new List<List<DotLine>>();
            var mylist = new List<DotLine>();
            //Agregamos la primera fila
            for (int i = 0; i < Size; i++)
            {
                mylist.Add(GameState[0, i].Up);
            }
            row.Add(mylist);
            //Agregamos el resto de filas
            for (int i = 0; i < Size; i++)
            {

                for (int j = 0; j < Size; j++)
                {
                    Box temp = GameState[i, j];
                    mylist.Add(temp.Down);

                }
                row.Add(mylist);
            }

            return row;
        }
        private List<List<DotLine>> CreateColumns()
        {
            var column = new List<List<DotLine>>();
            var mylist = new List<DotLine>();
            //Agregamos la primera columna
            for (int i = 0; i < Size; i++)
            {
                mylist.Add(GameState[i, 0].Left);
            }
            column.Add(mylist);
            //Agregamos el resto de columnas
            for (int i = 0; i < Size; i++)
            {

                for (int j = 0; j < Size; j++)
                {
                    Box temp = GameState[j, i];
                    mylist.Add(temp.Right);

                }
                column.Add(mylist);
            }

            return column;
        }
        */
        internal List<BooleanState> GetSuccessors()
        {
            List<BooleanState> myStates = new List<BooleanState>();
            int Estado = 0;
            bool[,] rows = new bool[Size+1,Size];
            bool[,] columns = new bool[Size+1, Size];
            for (int i = 0; i < Size+1; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    rows[i, j] = Rows[i][j].IsDraw;
                    columns[i, j] = Columns[i][j].IsDraw;

                }
            }


            //Comenzamos por las filas (Cambio en una fila, un nuevo estado)
            for (int i = 0; i < Size+1; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (!rows[i,j])//Si no hay linea dibujada, supondremos que se ha dibujado
                    {
                        Estado++;
                        Console.WriteLine("--------------------------------------------------------------Estado: " + Estado);
                        BooleanState te = new BooleanState();
                        bool t = !rows[i, j];
                        bool[,] rows2 = (bool[,])rows.Clone();
                        rows2[i,j]=t;
                        te.boolRow = rows2;
                        te.boolColumn = (bool[,])columns.Clone();
                        te.Player = Jugador;
                        Console.WriteLine("Filas");
                        PrintMatrix(rows2);
                        Console.WriteLine("Colummnas");
                        PrintMatrix(te.boolColumn);
                        //Creando una linea 
                        te.booleangame = CreateBoxMatrix(te);
                        myStates.Add(te);
                     


                    }
                    if (!columns[i, j])//Si no hay linea dibujada, supondremos que se ha dibujado
                    {
                        Estado++;
                        Console.WriteLine("--------------------------------------------------------------Estado: " + Estado);
                        BooleanState te = new BooleanState();
                        bool t = !columns[i, j];
                        bool[,] rows2 = (bool[,])rows.Clone();
                        te.boolColumn = (bool[,])columns.Clone();
                        te.boolColumn[i, j] = t;
                        te.boolRow = rows2;
                        te.Player = Jugador;
               //         Console.WriteLine("Filas");
            //            PrintMatrix(rows2);
                //        Console.WriteLine("Colummnas");
                 //       PrintMatrix(te.boolColumn);
            //            Console.WriteLine("Cajas");
                        te.booleangame = CreateBoxMatrix(te);
              //          PrintMatrix(te.GetBoolBoxes());
                        //Creando una linea 
                    
                        myStates.Add(te);
                    
                    }

                }
            }

            return myStates;
        }

        private BooleanBox[,] CreateBoxMatrix(BooleanState te)
        {
            BooleanBox[,] gmstate= new BooleanBox[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    bool up = te.boolRow[i,j];
                    bool down =te.boolRow[i + 1,j];
                    bool left =te.boolColumn[j,i];
                    bool right = te.boolColumn[j + 1,i];
                    gmstate[i, j] = new BooleanBox { Up = up, Left = left, Right = right, Down = down };
                }
            }
            return gmstate;
        }

        private void PrintMatrix(bool [,] arr)
        {
            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", arr[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
     
        }

        internal int CountEnemyCounter()
        {
            throw new NotImplementedException();
        }

        internal int CountLs()
        {
            throw new NotImplementedException();
        }

        internal int CountBoxes()
        {
            throw new NotImplementedException();
        }
    }
    public enum Player
    {
        MaxPlayer, MinPlayer
    }
}
