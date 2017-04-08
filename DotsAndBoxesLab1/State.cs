using System;
using System.Collections.Generic;

namespace DotsAndBoxesLab1
{
    public class State
    {
        public Box[,] GameState { get; set; }
        public Player Jugador { get; set; }
        public List<List<HorizontalLine>> Rows { get; set; }
        public List<List<VerticalLine>> Columns { get ;  set; }
        public int Size { get; set; }


        public State(int Size)
        {
           this.Size = Size;
            GameState = new Box[Size-1, Size-1];
            Rows = CreateRows();
            Columns = CreateColumns();

     
            }

        private List<List<HorizontalLine>> CreateRows()
        {
            var row = new List<List<HorizontalLine>>();
            var mylist = new List<HorizontalLine>();
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
        private List<List<VerticalLine>> CreateColumns()
        {
            var column = new List<List<VerticalLine>>();
            var mylist = new List<VerticalLine>();
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

        internal List<State> GetSuccessors()
        {



            throw new NotImplementedException();
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
