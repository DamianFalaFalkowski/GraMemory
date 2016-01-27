using GraMemory.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraMemory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public GamePageViewModel VM { get; set; }

        public MainWindow()
        {
            App.GamePage = this;
            this.DataContext = new GamePageViewModel();
            VM = this.DataContext as GamePageViewModel;
            InitializeComponent();            
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Grid send = sender as Grid;
            GameHandler.CreateGameHandler(send);
            if(send.ActualWidth>send.ActualHeight)
            {
                send.Width = send.ActualHeight;
            }
            else
            {
                send.Height = send.ActualWidth;
            }
            await GameHandler.StartGame(1);

            //Mem mem = new Mem();
            //MainGrid.Children.Add(mem);
            //Grid.SetColumn(mem, 5);
            //Grid.SetRow(mem, 5);
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Grid send = sender as Grid;
            if (send.ActualWidth > send.ActualHeight)
            {
                send.Width = send.ActualHeight;
            }
            else
            {
                send.Height = send.ActualWidth;
            }
        }

        
    }
}
