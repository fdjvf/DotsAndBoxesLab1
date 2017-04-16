using System;
using System.Collections.Generic;

namespace DotsAndBoxesLab1
{

 public class NegMax
    {
        public BooleanState Result { get; set; }
        private float my { get; set; } = -99999;
        public float MaxValue(BooleanState state, float Alpha, float Beta, int Depth)
        {
            if (Depth == 0)
            {
                return EvalHeuristic(state);
            }
            List<BooleanState> Successors = state.GetSuccessors();
            foreach (BooleanState s in Successors)
            {//Bug inside the successors list
                Alpha = Math.Max(Alpha, MinValue(s, Alpha, Beta, Depth - 1));
                if (Depth==4 && Alpha>=my)
                {
                    Result = s;
                    my = Alpha;
                }              
                if (Beta <= Alpha)
                {
                    break;
                }
            }
            return Alpha;
        }

        private float MinValue(BooleanState state, float Alpha, float Beta, int Depth)
        {
            if (Depth == 0)
            {
                return EvalHeuristic(state);
            }
            List<BooleanState> Successors = state.GetSuccessors();
            foreach (BooleanState s in Successors)
            {
                Beta = Math.Min(Beta, MaxValue(s, Alpha, Beta, Depth - 1));        
                if (Beta <= Alpha)
                {
                    break;
                }
            }

            return Beta;
        }



        public int EvalHeuristic(BooleanState state)
        {
            //20x1+5x2-10x3
            var temp = state.getData();
            int X1 = temp.X1;
            int X2 = temp.X2;
            int X3 = temp.X3;
            return 30 * X1 + 5 * X2 - 10 * X3;
        }



    }
}
