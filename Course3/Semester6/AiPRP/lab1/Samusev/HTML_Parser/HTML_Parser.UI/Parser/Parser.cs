using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Parser
    {
        private HttpClient client;
        private string[] urls;

        public Parser()
        {
            client = new HttpClient();
            urls = new[] {
                @"D:\Studieren\Course3\Semester6\AiPRP\lab1\Samusev\HTML_Parser\HTML_Parser.UI\HTML_Parser.UI\Health.html",
                @"D:\Studieren\Course3\Semester6\AiPRP\lab1\Samusev\HTML_Parser\HTML_Parser.UI\HTML_Parser.UI\Magic.html",
                @"D:\Studieren\Course3\Semester6\AiPRP\lab1\Samusev\HTML_Parser\HTML_Parser.UI\HTML_Parser.UI\Sport.html"
            };
        }

        public async Task<string> Parse(string[] words)
        {
            int[] urlCoincidences = new int[urls.Length];

            for (int i = 0; i < urlCoincidences.Length; i++)
            {
                int coincidencesCount = 0;
                
                string source = File.ReadAllText(urls[i]);

                var parser = new HtmlParser();
                var document = parser.ParseDocument(source);

                var list = new List<string>();

                foreach(string word in words)
                {
                    var divItems = document.QuerySelectorAll("div").Where(element => element.TextContent.Contains(word.ToLower())).Count();
                    var aItems = document.QuerySelectorAll("a").Where(element => element.TextContent.Contains(word.ToLower())).Count();
                    var hItems = document.QuerySelectorAll("h1").Where(element => element.TextContent.Contains(word.ToLower())).Count();

                    coincidencesCount += divItems + aItems + hItems;
                }

                urlCoincidences[i] = coincidencesCount;
            }

            int max = urlCoincidences.Max();
            int urlId = Array.IndexOf(urlCoincidences, max);

            string url = urls[urlId];
          
            return url;
        }
    }
}
