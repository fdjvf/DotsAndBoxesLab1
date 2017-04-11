using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxesLab1
{
    public class BooleanBox
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool IsComplete { get { return Up && Down && Left && Right; } }
        public bool HasL
        {
            get
            {
                return (Left && Up && !Right && !Down) || (!Left && !Up && Right && Down)
    || (Left && Down && !Right && !Up) || (!Left && !Down && Right && Up);
            }
        }
        public bool Lines3 { get {  return (Up && Down && Left && !Right)
                    || (Up && Down && !Left && Right)
                    || (Up && !Down && Left && Right)
                    || (!Up && Down && Left && Right)

                    ; }  }

    }
}
