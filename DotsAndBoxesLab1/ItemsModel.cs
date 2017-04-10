using System.Collections.Generic;

using System.Windows.Media;

namespace DotsAndBoxesLab1
{
  public   class ItemsModel
    {
        public List<Dot> Items { get; set; } = new List<Dot>();
        public ItemsModel(int Size)
        {
            int L = 0;
            for (int y = 0; y < Size + 1; y++)
                for (int x = 0; x < Size + 1; x++)
                {
                    L++;
                    Items.Add(new Dot
                    {
                        X = x * 45,
                        Y = y * 45
                        ,
                        StrokeColor = Brushes.Black
                        ,
                        ThickStroke = 1,
                        TAG = new TAGInfo { TAG=L,X=x*45,Y=y*45}
                    });
                }
        }
    }
}
