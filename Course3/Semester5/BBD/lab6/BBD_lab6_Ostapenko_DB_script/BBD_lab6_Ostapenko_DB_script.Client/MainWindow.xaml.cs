using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows;

namespace BBD_lab6_Ostapenko_DB_script.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OleDbConnection connection;

        public MainWindow()
        {
            InitializeComponent();

            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Универ\Studieren\Course3\BBD\lab6\BBD_lab6_Ostapenko.accdb");
            connection.Open();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            //var rolesEntries = GetDBEntries("Roles.txt");
            //AddDBEntries(rolesEntries);

            //var usersEnries = CreateUsersEntries();
            //AddDBEntries(usersEnries);

            //var personalDataEntries = GetDBEntries("PersonalData.txt");
            //AddDBEntries(personalDataEntries);
        }

        private List<DBEntry> CreateUsersEntries()
        {
            int number = 50;
            Random rng = new Random();

            string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var passwords = new List<string>();

            foreach (var randomString in RandomStrings(AllowedChars, 8, 12, number, rng))
            {
                passwords.Add(randomString);
            }

            AllowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var logins = new List<string>();

            foreach (var randomString in RandomStrings(AllowedChars, 8, 12, number, rng))
            {
                logins.Add(randomString);
            }

            var entries = new List<DBEntry>();

            for (int i = 0; i < number; i++)
            {
                entries.Add(new DBEntry("Пользователи", "ИмяПользователя, ПарольПользователя, КодРоли", $"'{logins[i]}', '{passwords[i]}', {rng.Next(1, 5)}"));
            }

            return entries;
        }

        private void AddDBEntries(List<DBEntry> entries)
        {
            int result = 0;

            foreach (var entry in entries)
            {
                // текст запроса
                string query = $"INSERT INTO [{entry.TableName}] {entry.Columns} VALUES {entry.Values}";

                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, connection);

                // выполняем запрос к MS Access
                result += command.ExecuteNonQuery();
            }

            MessageBox.Show(result.ToString());
        }

        private List<DBEntry> GetDBEntries(string fileName)
        {
            var entries = new List<DBEntry>();

            using (var reader = new StreamReader(fileName, System.Text.Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var lines = line.Split("/".ToCharArray());
                    lines[2] = lines[2].Replace("\t", "");
                    entries.Add(new DBEntry(lines[0], lines[1], lines[2]));
                }
            }

            return entries;
        }

        private static IEnumerable<string> RandomStrings(
            string allowedChars,
            int minLength,
            int maxLength,
            int count,
            Random rng)
        {
            char[] chars = new char[maxLength];
            int setLength = allowedChars.Length;

            while (count-- > 0)
            {
                int length = rng.Next(minLength, maxLength + 1);

                for (int i = 0; i < length; ++i)
                {
                    chars[i] = allowedChars[rng.Next(setLength)];
                }

                yield return new string(chars, 0, length);
            }
        }
    }
}
