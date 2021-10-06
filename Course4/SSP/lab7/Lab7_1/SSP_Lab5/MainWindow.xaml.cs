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

namespace SSP_Lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoubleAnimation TextAnimation = new DoubleAnimation();
            TextAnimation.From = BigText1.FontSize;
            TextAnimation.To = 32;
            TextAnimation.Duration = TimeSpan.FromSeconds(3);
            BigText1.BeginAnimation(TextBox.FontSizeProperty, TextAnimation);
        }

        private void BigText2_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            DoubleAnimation TextAnimation = new DoubleAnimation();
            TextAnimation.From = BigText2.FontSize;
            TextAnimation.To = 6;
            TextAnimation.Duration = TimeSpan.FromSeconds(3);
            BigText2.BeginAnimation(TextBox.FontSizeProperty, TextAnimation);     
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation heightAnim1 = new DoubleAnimation();
            heightAnim1.From = BigText1.Height;
            heightAnim1.To = 1;
            heightAnim1.Duration = TimeSpan.FromSeconds(3);
            DoubleAnimation widthAnim1 = new DoubleAnimation();
            widthAnim1.From = BigText2.Width;
            widthAnim1.To = 1;
            widthAnim1.Duration = TimeSpan.FromSeconds(3);
            BigText2.BeginAnimation(TextBox.HeightProperty, heightAnim1);
            BigText2.BeginAnimation(TextBox.WidthProperty, widthAnim1);
            DoubleAnimation heightAnim2 = new DoubleAnimation();
            heightAnim2.From = BigText1.Height;
            heightAnim2.To = 1;
            heightAnim2.Duration = TimeSpan.FromSeconds(3);
            DoubleAnimation widthAnim2 = new DoubleAnimation();
            widthAnim2.From = BigText1.Width;
            widthAnim2.To = 1;
            widthAnim2.Duration = TimeSpan.FromSeconds(3);
            BigText1.BeginAnimation(TextBox.HeightProperty, heightAnim2);
            BigText1.BeginAnimation(TextBox.WidthProperty, widthAnim2);

        }
    }
}
