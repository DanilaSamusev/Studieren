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

namespace SSP_lab3_2
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

        private void ChangeColor_MouseEnter(object sender, MouseEventArgs e)
        {
            this.StatusBarText.Text = "Change Color";
        }

        private void DeveloperInfo_MouseEnter(object sender, MouseEventArgs e)
        {
            this.StatusBarText.Text = "Developer Info";
        }

        private void Exit_MouseEnter(object sender, MouseEventArgs e)
        {
            this.StatusBarText.Text = "Exit App";
        }

        private void Clear_Status(object sender, MouseEventArgs e)
        {
            this.StatusBarText.Text = "";
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void White_Click(object sender, RoutedEventArgs e)
        {
            this.MainGrid.Background = Brushes.White;
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            this.MainGrid.Background = Brushes.Blue;
        }

        private void DeveloperInfoMenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Developer: A.N.Own");
        }
    }
}
