using GraMemory.Model;
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
    /// Interaction logic for Mem.xaml
    /// </summary>
    public partial class Mem : UserControl
    {
        private int no = -1;

        public MemPossition Possition { get; set; }

        public bool isActive;

        public bool isVisible { get { return this.Visibility == Visibility.Visible ? true : false; }
            set { this.Visibility = value == true ? Visibility.Visible : Visibility.Collapsed; }
        }

        private Grid MemBody;

        public Mem(MemPossition possition,int no)
        {           
            InitializeComponent();
            this.no = no;
            Grid.SetRow(this, possition.memY);
            Grid.SetColumn(this, possition.memX);
            Possition = possition;
            isActive = false;
            isVisible = false;
            //Numer.Text = no.ToString();
        }

        private async void Color_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {         
            if(isActive)
            {
                this.isActive = false;
                this.isVisible = false;
                await GameHandler.CheckOrder(Possition);            
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            byte r = (byte)rand.Next(0, 256);
            byte g = (byte)rand.Next(0, 256);
            byte b = (byte)rand.Next(0, 256);

            MemBody = sender as Grid;
            MemBody.Background = new SolidColorBrush(GameHandler.ColorsList[no]);
        }
    }
}
