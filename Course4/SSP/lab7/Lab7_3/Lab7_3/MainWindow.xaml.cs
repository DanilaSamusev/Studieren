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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab7_3
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0.0;
            doubleAnimation.To = 1.0;
            doubleAnimation.Duration = TimeSpan.FromSeconds(1.5);
            doubleAnimation.AutoReverse = true;
            GradientStop3.BeginAnimation(GradientStop.OffsetProperty, doubleAnimation);
        }

        private void GradientStopMove()
        {
            
        }
    }
}
