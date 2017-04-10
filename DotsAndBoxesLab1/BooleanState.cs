using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxesLab1
{
    class BooleanState
    {
        public bool[,] boolRow { get; set; }
        public bool[,] boolColumn { get; set; }
        public bool Player { get; set; }//0 Max 1 Min
        public BooleanBox[,] booleangame { get; set; }

        public bool[,] GetBoolBoxes()
        {
            int rowLength = booleangame.GetLength(0);          
            int colLength = booleangame.GetLength(1);
            bool[,] boxes = new bool[rowLength,colLength];
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    boxes[i, j] = booleangame[i, j].IsComplete;

                }
            }
            return boxes;
        }
    }
}
