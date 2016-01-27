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
        public MemPossition Possition { get; set; }

        public bool isActive;

        public bool isVisible { get { return this.Visibility == Visibility.Visible ? true : false; }
            set { this.Visibility = value == true ? Visibility.Visible : Visibility.Collapsed; }
        }

        private Grid MemBody;

        public Mem(MemPossition possition)
        {
            Grid.SetRow(this, possition.memY);
            Grid.SetColumn(this, possition.memX);
            Possition = possition;
            isActive = false;
            isVisible = false;
            InitializeComponent();
        }

        private void Color_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {         
            if(isActive)
            {
                GameHandler.CheckOrder(Possition);
                this.isActive = false;
                this.isVisible = false;
                
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MemBody = sender as Grid;
            MemBody.Background = new SolidColorBrush(GameHandler.MemsColor);
        }
    }
}
