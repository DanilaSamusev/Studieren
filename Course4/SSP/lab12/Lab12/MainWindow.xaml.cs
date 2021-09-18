using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Lab12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static double CANVAS_TOP = 50;
        private static double CANVAS_LEFT = 400;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Znak1_Click(object sender, RoutedEventArgs e)
        {
            Animate(Znak1, scaleTransform1);
        }

        private void Znak2_Click(object sender, RoutedEventArgs e)
        {
            Animate(Znak2, scaleTransform2);
        }

        private void Znak3_Click(object sender, RoutedEventArgs e)
        {
            Animate(Znak3, scaleTransform3);
        }

        private void Animate(Button button, ScaleTransform scaleTransform)
        {
            MoveAnimation(button, Canvas.TopProperty, CANVAS_TOP, Canvas.GetTop(button));
            MoveAnimation(button, Canvas.LeftProperty, CANVAS_LEFT, Canvas.GetLeft(button));
            ZoomAnimation(scaleTransform);
        }

        private void ZoomAnimation(ScaleTransform scaleTransform)
        {
            var animation = new DoubleAnimation(3, new Duration(TimeSpan.FromSeconds(8)));
            animation.AutoReverse = true;
            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, animation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
        }

        private void MoveAnimation(Button button, DependencyProperty property, double to, double from)
        {
            var animation = new DoubleAnimation();
            animation.To = to;
            animation.Duration = new Duration(TimeSpan.FromSeconds(6));
            animation.AutoReverse = false;
            animation.Completed += (s, e) =>
            {
                var reverseAnimation = new DoubleAnimation();
                reverseAnimation.To = from;
                reverseAnimation.Duration = new Duration(TimeSpan.FromSeconds(6));
                reverseAnimation.AutoReverse = false;
                reverseAnimation.BeginTime = TimeSpan.FromSeconds(2);
                button.BeginAnimation(property, reverseAnimation);
            };
            button.BeginAnimation(property, animation);
        }
    }
}
