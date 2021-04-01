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

            // Send the http request and wait for the response
            var responseStream = webRequest.GetResponse().GetResponseStream();

            // Displays the response stream text
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

            using var client = new WebClient();
			client.DownloadFile("https://localhost:44327/api/WebService/" + selectedFileIndex, selectedFileName);
		}
	}
}
