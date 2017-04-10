namespace DotsAndBoxesLab1
{
    public class Box
    {
        public DotLine Up { get; set; }
        public DotLine Down { get; set; }
        public DotLine Left { get; set; }
        public DotLine Right { get; set; }

        public Box()
        {
            Up = new DotLine { IsDraw = false };
            Down = new DotLine { IsDraw = false };
            Left = new DotLine { IsDraw = false };
            Right = new DotLine { IsDraw = false };
        }
    }
}