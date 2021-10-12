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

namespace Lab7_ssp
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


        private void runaway_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void runaway_MouseEnter(object sender, MouseEventArgs e)
        {
            
            var anim = new ThicknessAnimation();
            var thickk = runaway.Margin;
            thickk.Left = runaway.Margin.Left + new Random().Next(30, 50);
            thickk.Top = runaway.Margin.Top + new Random().Next(30,50);
            thickk.Bottom = runaway.Margin.Bottom - new Random().Next(30,50);
            thickk.Right = runaway.Margin.Right - new Random().Next(30, 50);
            anim.From = runaway.Margin;
            anim.To = thickk;
            anim.Duration = TimeSpan.FromSeconds(0.5);
            runaway.BeginAnimation(MarginProperty, anim);
        }
    }

}

    
        
    

