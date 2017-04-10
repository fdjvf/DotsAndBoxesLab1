using System;

using System.Windows;


namespace DotsAndBoxesLab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawBoard_Click(object sender, RoutedEventArgs e)
        {
           
            if (CpuPlayerRdb.IsChecked==false && CpuRdb.IsChecked==false)
            {
                Console.WriteLine("Mistake");
            }else
            {
                VsState players;
                if (CpuPlayerRdb.IsChecked.Value)
                {
                    Console.WriteLine("Cpu vs Player");
                    players = VsState.PlayerVsCPU;
                }
                else
                {
                    Console.WriteLine("Cpu vs Cpu");
                    players = VsState.CpuVsCpu;
                }
                State GameState = new State(int.Parse(GameSizeTbx.Text));
                GameBoard game = new GameBoard(GameState,players);
                Close();
                game.Show();
            }


        }
    }
    public enum VsState
    {
        CpuVsCpu,PlayerVsCPU
    }
}
