using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DotsAndBoxesLab1
{
    public class Dot:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _X;
        public double X
        {
            get { return _X; }
            set { _X = value; RaisePropertyChanged(); }
        }


        private double _Y;
        public double Y
        {
            get { return _Y; }
            set { _Y = value; RaisePropertyChanged(); }
        }

        private Brush _StrokeColor;

        public Brush StrokeColor
        {
            get { return _StrokeColor; }
            set { _StrokeColor = value;
                RaisePropertyChanged();
            }
        }
        private int _ThickStroke;

        public int ThickStroke
        {
            get { return _ThickStroke; }
            set { _ThickStroke = value;
                RaisePropertyChanged();
            }
        }

        private TAGInfo _TAG;

        public TAGInfo TAG
        {
            get { return _TAG; }
            set { _TAG = value;
                RaisePropertyChanged();
            }
        }


        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TAGInfo
    {
        public int TAG { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}

