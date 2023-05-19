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

namespace ConectivoApp
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
       public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var color = MainGrid.Background as SolidColorBrush;
            var newColor = color.Color.Equals(Color.FromArgb(0xFF, 0xED, 0xED, 0xED)) ?
                            new SolidColorBrush(Color.FromArgb(0xFF, 0x6A, 0x6B, 0x6B)) :
                            new SolidColorBrush(Color.FromArgb(0xFF, 0xED, 0xED, 0xED));

            MainGrid.Background = newColor;
        }
    }
}
