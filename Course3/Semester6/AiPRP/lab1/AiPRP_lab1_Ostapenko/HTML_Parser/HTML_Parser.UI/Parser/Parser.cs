using AngleSharp.Html.Parser;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Parser
{
	public class Parser
    {
		private readonly string[] urls;

        public Parser()
        {
            urls = new[] {
                @"D:\Универ\Studieren\Course3\Semester6\AiPRP\lab1\AiPRP_lab1_Ostapenko\HTML_Parser\HTML_Parser.UI\HTML_Parser.UI\Caps.html",
                @"D:\Универ\Studieren\Course3\Semester6\AiPRP\lab1\AiPRP_lab1_Ostapenko\HTML_Parser\HTML_Parser.UI\HTML_Parser.UI\Pants.html",
                @"D:\Универ\Studieren\Course3\Semester6\AiPRP\lab1\AiPRP_lab1_Ostapenko\HTML_Parser\HTML_Parser.UI\HTML_Parser.UI\Shoes.html"
            };
        }

        public string Parse(string[] words)
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
                    var aItems = document.QuerySelectorAll("p").Where(element => element.TextContent.Contains(word.ToLower())).Count();
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
