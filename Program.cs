using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using HtmlAgilityPack;
using System.Net;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //WebBrowser wb = new WebBrowser();
            //wb.Navigate("http://www.zzap.ru/default.aspx?partnumber=ak0001&class_man=AVERTRUCK&location=1&currency=1&rawdata=ak0001");
            //System.Windows.Forms.HtmlDocument hdocument = wb.Document;



            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            var WebClient = new WebClient();
            //WebClient.Headers.Add("accept-encoding", "gzip, deflate");
            WebClient.Headers.Add("accept-language", "ru-RU,ru;");
            WebClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36");
            WebClient.Headers.Add("content-type", "charset=UTF-8");
            WebClient.Encoding = System.Text.Encoding.UTF8;
            NameValueCollection QueryString = new NameValueCollection();
            QueryString.Add("partnumber", "AK0001");
            QueryString.Add("class_man", "AVERTRUCK");
            QueryString.Add("location", "1");
            QueryString.Add("currency", "1");
            QueryString.Add("rawdata", "ak0001");

            WebClient.QueryString = QueryString;
            var pString = WebClient.DownloadString("http://www.zzap.ru/default.aspx");
            html.LoadHtml(pString);
            var Document = html.DocumentNode;
            var p = Document.Descendants("span");
            //.Where(j => j.GetAttributeValue("class", "").Equals("dx-vam"));
            //.Where(h => h.InnerText.Contains("Купить"));
            foreach (HtmlNode lp in p)
            {
                var strInnerText = lp.InnerText;
                Console.WriteLine(strInnerText);
            }
            Console.Write("all");

        }
    }
}
