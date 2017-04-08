using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (State s in GetSuccessors(state))
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
            List<State> Successors = state.GetSuccessors();
            foreach (State s in Successors)
            {
                Beta = Math.Min(Beta, MaxValue(state, Alpha, Beta, Depth - 1));
                if (Beta <= Alpha)
                {
                    return Alpha;
                }
            }
            return Beta;
        }

        private List<State> GetSuccessors(State state)
        {
            throw new NotImplementedException();
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
