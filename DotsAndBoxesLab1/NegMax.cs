using System;
using System.Collections.Generic;

namespace DotsAndBoxesLab1
{

    class NegMax
    {
        public BooleanState Result { get; set; }
        public float MaxValue(BooleanState state, float Alpha,float Beta, int Depth)
        {
            if (Depth==0)
            {
                return EvalHeuristic(state);
            }
            List<BooleanState> Successors = state.GetSuccessors();
            foreach (BooleanState s in Successors)
            {
                Alpha = Math.Max(Alpha, MinValue(state, Alpha, Beta, Depth - 1));
                if (Alpha>=Beta)
                {
                    Result = state;
                    return Alpha;
                }
            }
         //   Result = state;
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
                Beta = Math.Min(Beta, MaxValue(state, Alpha, Beta, Depth - 1));
                if (Beta <= Alpha)
                {
                    Result = state;
                    return Beta;
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
                return 20 * X1 + 5 * X2 - 10 * X3;
        }            



    }
}
