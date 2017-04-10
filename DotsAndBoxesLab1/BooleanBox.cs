using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxesLab1
{
    class BooleanBox
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool IsComplete { get { return Up && Down && Left && Right; } }

   
    }
}
