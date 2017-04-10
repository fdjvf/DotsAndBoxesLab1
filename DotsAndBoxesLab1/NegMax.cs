using System;
using System.Collections.Generic;

namespace DotsAndBoxesLab1
{
    class NegMax
    {
        
        public float MaxValue(State state, float Alpha,float Beta, int Depth)
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
                    return Alpha;
                }
            }
            return Alpha;
        }

        private float MinValue(State state, float Alpha, float Beta, int Depth)
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
                    return Beta;
                }
            }
            return Beta;
        }



        public int EvalHeuristic(State state)
        {
            //20x1+5x2-10x3
            int X1 = state.CountBoxes();
            int X2 = state.CountLs();
            int X3 = state.CountEnemyCounter();
                return 20 * X1 + 5 * X2 - 10 * X3;
        }            



    }
}
