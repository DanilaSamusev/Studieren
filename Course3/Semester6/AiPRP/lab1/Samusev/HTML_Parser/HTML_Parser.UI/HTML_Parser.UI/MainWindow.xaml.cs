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

namespace HTML_Parser.UI
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

        public async Task<string> FindDocument(string[] words)
        {
            var parser = new Parser.Parser();
            return await parser.Parse(words);
        }

        public async void OpenDocument()
        {
            string[] words = Words.Text.Split(", ").Select(x => x.ToLower()).ToArray();
            string url = await FindDocument(words);

            System.Diagnostics.Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", url);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenDocument();
        }        
    }
}
