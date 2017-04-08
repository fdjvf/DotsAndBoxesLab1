namespace DotsAndBoxesLab1
{
    public class Box
    {
        public HorizontalLine Up { get; set; }
        public HorizontalLine Down { get; set; }
        public VerticalLine Left { get; set; }
        public VerticalLine Right { get; set; }

        public Box()
        {
            Up = new HorizontalLine { IsDraw = false };
            Down = new HorizontalLine { IsDraw = false };
            Left = new VerticalLine { IsDraw = false };
            Right = new VerticalLine { IsDraw = false };
        }
    }
}