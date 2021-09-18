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

namespace lab11_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 1; i <= 5; i++)
            {
                var picture = new CustomPicture();

                var pictureName = $"images/{i}.jpg";

                picture.PictureImage.Source =
                    new BitmapImage(new Uri(pictureName, UriKind.Relative));

                picture.PictureName.Text = pictureName;
                
                var grid = new Grid();
                grid.Children.Add(picture);

                RootWrapPanel.Children.Add(grid);
            }
        }
    }
}
