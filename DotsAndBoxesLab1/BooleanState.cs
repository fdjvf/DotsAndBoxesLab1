using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace DotsAndBoxesLab1
{
    public class BooleanState
    {
        public int Size { get; set; }
        public bool[,] BoolRow { get; set; }
        public bool[,] BoolColumn { get; set; }
        public bool Player { get; set; }//0 Max 1 Min
        public BooleanBox[,] BooleanGame { get; set; }


        /// <summary>
        /// Expresa el estado 
        /// boleano como una matriz boleana que indica que cuadrados se han completado y cuales no
        /// </summary>
        /// <returns></returns>
        public bool[,] GetBoolBoxes()
        {
            int rowLength = BooleanGame.GetLength(0);
            int colLength = BooleanGame.GetLength(1);
            bool[,] boxes = new bool[rowLength, colLength];
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    boxes[i, j] = BooleanGame[i, j].IsComplete;

                }
            }
            return boxes;
        }

        internal List<BooleanState> GetSuccessors()
        {
            List<BooleanState> myStates = new List<BooleanState>();
            int Estado = 0;
            //Comenzamos por las filas (Cambio en una fila, un nuevo estado)
            for (int i = 0; i < Size + 1; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (!BoolRow[i, j])//Si no hay linea dibujada, supondremos que se ha dibujado
                    {
            //            Estado++;
            //            Console.WriteLine("--------------------------------------------------------------Estado: " + Estado);
                        BooleanState NewChild = new BooleanState();
                        bool t = !BoolRow[i, j];
                        bool[,] boolRow2 = (bool[,])BoolRow.Clone();
                        boolRow2[i, j] = t;
                        NewChild.Size = Size;
                        NewChild.BoolRow = boolRow2;
                        NewChild.BoolColumn = (bool[,])BoolColumn.Clone();
                        NewChild.Player = Player;
                        NewChild.CreateBoxMatrix();
                        //NewChild.Print();
                        myStates.Add(NewChild);
                    }
       if (!BoolColumn[i, j])//Si no hay linea dibujada, supondremos que se ha dibujado
                    {
            //            Estado++;
               //         Console.WriteLine("--------------------------------------------------------------Estado: " + Estado);
                        BooleanState NewChild = new BooleanState();
                        bool t = !BoolColumn[i, j];
                        bool[,] boolRow2 = (bool[,])BoolRow.Clone();
                        NewChild.BoolColumn = (bool[,])BoolColumn.Clone();
                        NewChild.BoolColumn[i, j] = t;
                        NewChild.BoolRow = boolRow2;
                        NewChild.Player = Player;
                        NewChild.Size = Size;
                        NewChild.CreateBoxMatrix();
                        //NewChild.Print();
                        myStates.Add(NewChild);

                    }
                  
                }
            }

            return myStates;
        }

        internal (int X1, int X2, int X3) getData()
        {
            int count = 0;
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    BooleanBox box = BooleanGame[i, j];
                    if (box.IsComplete)
                    {
                        count++;
                    }
                    else if (box.HasL)
                    {
                        count1++;
                    }
                    else if (box.Lines3)
                    {
                        count2++;
                    }

                }
            }
            return (count, count1, count2);
        }


    }
    public static class Helper
    {
        public static void UpdateGame(this State st, BooleanState boolst)
        {
            var temp = st.GameState;

            for (int i = 0; i < st.Size; i++)
            {
                for (int j = 0; j < st.Size; j++)
                {
                    var box = temp[i, j];
                    var boxbool = boolst.BooleanGame[i, j];
                    if ((!box.Down.IsDraw && boxbool.Down))
                    {
                        box.Down.DrawLine();
                        break;
                    }
                    else if ((!box.Up.IsDraw && boxbool.Up))
                    {

                        box.Up.DrawLine();
                        break;
                    }
                    else if ((!box.Left.IsDraw && boxbool.Left))
                    {
                        box.Left.DrawLine();
                        break;

                    }
                    else if ((!box.Right.IsDraw && boxbool.Right))
                    {

                        box.Right.DrawLine();
                        break;
                    }




                }
            }
        }
        public static void DrawLine(this DotLine linetodraw)
        {
            linetodraw.StrokeColor = Brushes.Black;
            linetodraw.IsDraw = true;
        }
        public static void CreateBoxMatrix(this BooleanState te)
        {

            BooleanBox[,] gmstate = new BooleanBox[te.Size, te.Size];
            for (int i = 0; i < te.Size; i++)
            {
                for (int j = 0; j < te.Size; j++)
                {
                    bool up = te.BoolRow[i, j];
                    bool down = te.BoolRow[i + 1, j];
                    bool left = te.BoolColumn[j, i];
                    bool right = te.BoolColumn[j + 1, i];
                    gmstate[i, j] = new BooleanBox { Up = up, Left = left, Right = right, Down = down };
                }
            }
            te.BooleanGame = gmstate;
        }
        public static void Print(this BooleanState te)
        {
            Console.WriteLine("Filas");
            te.BoolRow.PrintMatrix();
            Console.WriteLine("Colummnas");
            te.BoolColumn.PrintMatrix();
            Console.WriteLine("Cajas");
            te.GetBoolBoxes().PrintMatrix();
        }
        private static void PrintMatrix(this bool[,] arr)
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
    }
}

