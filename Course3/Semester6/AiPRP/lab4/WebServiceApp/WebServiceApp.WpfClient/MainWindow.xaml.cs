using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows;

namespace WebServiceApp.WpfClient
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

            var webRequest = WebRequest.Create("https://localhost:44327/api/WebService/getAll");
            string[] fileNames = { "" };

            var responseStream = webRequest.GetResponse().GetResponseStream();

            if (responseStream != null)
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    fileNames = JsonSerializer.Deserialize<string[]>(streamReader.ReadToEnd());
                }
            }

            FilesNamesList.ItemsSource = fileNames;
        }

		private void FilesNamesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string selectedFileName = FilesNamesList.SelectedItem.ToString();
            int selectedFileIndex = FilesNamesList.SelectedIndex;

            var userResult = MessageBox.Show($"Скачать файл {selectedFileName}?", "Подтвердите действие", MessageBoxButton.YesNo);
            if (userResult == MessageBoxResult.Yes)
			{
                using var client = new WebClient();
                client.DownloadFile("https://localhost:44327/api/WebService/" + selectedFileIndex, selectedFileName);
            }
		}
	}
}
