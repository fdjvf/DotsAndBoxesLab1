using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace DotsAndBoxesLab1
{
    public class DotLine : INotifyPropertyChanged
    {
        public bool IsDraw { get; set; }
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
        private double x1;

        public double X1
        {
            get { return x1+10; }
            set
            {
                x1 = value;
                RaisePropertyChanged();
            }
        }
        private double x2;

        public double X2
        {
            get { return x2+10; }
            set
            {
                x2 = value;
                RaisePropertyChanged();
            }
        }

        private double y1;

        public double Y1
        {
            get { return y1+10; }
            set
            {
                y1 = value;
                RaisePropertyChanged();
            }
        }

        private double y2;

        public double Y2
        {
            get { return y2+10; }
            set
            {
                y2 = value;
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