﻿using System;
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
        internal BooleanState BooleanRepresentation()
        {
            //Se arma el equivalente booleano
            BooleanState myState = new BooleanState();

            bool[,] rows = new bool[Size + 1, Size];
            bool[,] columns = new bool[Size + 1, Size];
            for (int i = 0; i < Size + 1; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    rows[i, j] = Rows[i][j].IsDraw;
                    columns[i, j] = Columns[i][j].IsDraw;
                }
            }
            BooleanState Temp = new BooleanState { BoolColumn = columns, BoolRow = rows, Player = Jugador, Size = Size };
            Temp.CreateBoxMatrix();
            return Temp;

        }
        #endregion









    }
}
