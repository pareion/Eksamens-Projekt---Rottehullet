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
using System.Windows.Shapes;
//using RotteHullet.Domain;

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private List<object> _datavisningListe = new List<object>();

        public AdminPanel()
        {
            InitializeComponent();
            indlæsData();
        }

        private void lv_lokal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void lv_udstyr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lv_brætspil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lv_bøger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void indlæsData()
        {
            Random rand = new Random();
            for (int i = 0; i < 9999; i++)
            {
                RotteHullet.Domain.UIFacade.HentUIFacade().HentBogFacade().SkabBog(GetText(rand), GetText(rand), GetText(rand), GetText(rand), GetText(rand), GetText(rand), GetText(rand));
            }

            _datavisningListe = RotteHullet.Domain.UIFacade.HentUIFacade().HentBogFacade().FindAlleBøger();

            _datavisningListe.ForEach(x => lv_bøger.Items.Add(x));
        }

        private string GetText(Random rand)
        {

            byte[] raw = new byte[32];
            rand.NextBytes(raw);

            System.Security.Cryptography.SHA1Managed sha = new System.Security.Cryptography.SHA1Managed();
            byte[] data = sha.ComputeHash(raw);
            return Convert.ToBase64String(data);
        }

        private void opret_Click(object sender, RoutedEventArgs e)
        {
            OpretÆndreAktiv opret = new OpretÆndreAktiv(adminTab.SelectedIndex);
            opret.Show();
        }
    }
}
