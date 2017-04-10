using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace DotsAndBoxesLab1
{
    public class Box: INotifyPropertyChanged
    {
        public DotLine Up { get; set; }
        public DotLine Down { get; set; }
        public DotLine Left { get; set; }
        public DotLine Right { get; set; }
        
        public bool IsComplete { get { return Up.IsDraw && Down.IsDraw && Left.IsDraw && Right.IsDraw; } }
        public bool IsDrawn { get; set; } = false;
        private double x;

        public double X
        {
            get { return x; }
            set { x = value;
                RaisePropertyChanged();
            }
        }
        private double y;

        public double Y
        {
            get { return y; }
            set { y = value;
                RaisePropertyChanged();
            }
        }

        private Brush strokeColor;
        public Brush StrokeColor
        {
            get { return strokeColor; }
            set
            {
                strokeColor = value;
                RaisePropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
 

    }
}