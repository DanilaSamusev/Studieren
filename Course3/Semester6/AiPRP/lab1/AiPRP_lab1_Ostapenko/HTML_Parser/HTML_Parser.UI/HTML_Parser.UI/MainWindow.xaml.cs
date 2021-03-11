using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
            return await Task.Run(() => parser.Parse(words));
        }

        public async void OpenDocument()
        {
            string[] words = Words.Text.Split(", ").Select(x => x.ToLower()).ToArray();
            string url = await FindDocument(words);

            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", url);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenDocument();
        }
    }
}
