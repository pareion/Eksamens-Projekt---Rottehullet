using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using RotteHullet.Data;

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        string RemoveBetween(string s, char begin, char end)
        {
            Regex regex = new Regex(string.Format("\\{0}.*?\\{1}", begin, end));
            return regex.Replace(s, string.Empty);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = wc.DownloadData("http://www.foeniks.org/ressourcer-og-udlaan/bibliotek/__trashed/");

            string webData = System.Text.Encoding.ASCII.GetString(raw);

            List<Dictionary<string, List<string>>> books = new List<Dictionary<string, List<string>>>();


            string[] test = webData.Substring(18020, webData.Length - 18021).Split(new string[] { "<h3>" }, StringSplitOptions.None);
            for (int x = 1; x < test.Length; x++)
            {
                Dictionary<string, List<string>> temp2 = new Dictionary<string, List<string>>();
                string[] tmp = test[x].Split(new string[] { "<em>" }, StringSplitOptions.None);
                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] = RemoveBetween(tmp[i], '<', '>');
                    tmp[i] = tmp[i].Replace("\n", "_");
                    tmp[i] = tmp[i].Replace("?", "");
                    tmp[i] = tmp[i].Replace("__", "_");
                    tmp[i] = tmp[i].Replace("&#8211;", "-");
                    tmp[i] = tmp[i].Replace("&#8217;", "'");

                    List<string> booksTemp = tmp[i].Split('_').ToList();
                    string familly = booksTemp[0];
                    if (booksTemp.Count() > 1)
                    {
                        booksTemp.RemoveAt(0);
                        booksTemp.RemoveAt(booksTemp.Count() - 1);
                    }


                    temp2.Add(familly, booksTemp);
                }
                books.Add(temp2);
            }
            List<Bog> finishedBooks = new List<Bog>();

            int count = 0;
            for (int i = 0; i < books.Count(); i++)
            {
                Dictionary<string, List<string>> current = books[i];

                string familie = "";
                count = 0;
                foreach (KeyValuePair<string,List<string>> item in current)
                {
                    if (count == 0)
                    {
                        familie = item.Key;
                        count++;
                    }
                    else
                    {
                        
                        foreach (var item2 in item.Value)
                        {
                            Bog bog = new Bog();
                            bog.familie = familie;
                            bog.subkategori = item.Key;
                            bog.titel = item2;
                            finishedBooks.Add(bog);
                        }
                    }
                }
            }
            for (int i = 490-1; i >= 448; i--)
            {
                finishedBooks.RemoveAt(i);

            }
            foreach (var item in finishedBooks)
            {
                DBEF.HentDBEF().GemBog(item);
            }
            //DBFacade.AngivDatabaseFacade(DBFacade.DatabaseType.EntityFrame);
            //Domain.UIFacade.HentUIFacade().HentBogFacade().FindAlleBøger();
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
