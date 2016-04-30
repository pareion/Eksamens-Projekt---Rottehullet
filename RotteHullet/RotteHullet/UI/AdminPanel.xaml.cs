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
using RotteHullet.Domain;
using RotteHullet.Værktøjs;

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private List<object> _datavisningListe = new List<object>();

        private object _selectBog = null;

        public AdminPanel()
        {
            InitializeComponent();
            indlæsData();
        }

        #region Funktioner
        private void indlæsData()
        {
            _datavisningListe = RotteHullet.Domain.UIFacade.HentUIFacade().HentBogFacade().FindAlleBøger();
            _datavisningListe.ForEach(x => lv_bøger.Items.Add(x));
        }

        #endregion

        #region Udvælgelse event
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
            if (lv_bøger.SelectedIndex != -1)
            {
                b_redigereBog.IsEnabled = true;
                b_sletBog.IsEnabled = true;
                _selectBog = lv_bøger.Items.GetItemAt(lv_bøger.SelectedIndex);
            }
            else
            {
                b_redigereBog.IsEnabled = false;
                b_sletBog.IsEnabled = false;
            }
        }
        #endregion

        #region Klik event
        private void opret_Click(object sender, RoutedEventArgs e)
        {
            OpretÆndreAktiv opret = new OpretÆndreAktiv(adminTab.SelectedIndex);
            opret.Show();
        }

        private void redigere_Click(object sender, RoutedEventArgs e)
        {
            OpretÆndreAktiv opret;

            if (adminTab.SelectedIndex == 0)
            {
                opret = new OpretÆndreAktiv(adminTab.SelectedIndex, lv_bøger.SelectedItem);
            }
            else if(adminTab.SelectedIndex == 1)
            {
                opret = new OpretÆndreAktiv(adminTab.SelectedIndex, lv_brætspil.SelectedItem);
            }
            else if(adminTab.SelectedIndex == 2)
            {
                opret = new OpretÆndreAktiv(adminTab.SelectedIndex, lv_udstyr.SelectedItem);
            }
            else
            {
                opret = new OpretÆndreAktiv(adminTab.SelectedIndex, lv_lokal.SelectedItem);
            }

            opret.Show();
        }
        #endregion

        #region Søgning event

        private void opdatereList(ListView dataListe, List<object> data)
        {
            dataListe.Items.Clear();
            foreach (object item in data)
            {
                dataListe.Items.Add(item);
            }
        }

        private void søgbøger_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox boks = sender as TextBox;
            if (boks.Text.Length > 1)
            {
                l_søgBøger.Foreground = Brushes.Black;

                // Laver søgning
                if (e.Key == Key.Enter)
                {
                    // Sætter ListView objekt for bøger og søg resultater til opdatere ListView list
                    opdatereList(lv_bøger, Søgning.GetSøgning().Find(boks.Text.ToLower(), Søgning.AktivType.Bog));
                }
                else if (e.Key == Key.Escape)
                {
                    l_søgBøger.Foreground = Brushes.LightGray;
                    boks.Text = "";
                    opdatereList(lv_bøger, _datavisningListe);
                }
            }
            else
            {
                // Effektiv data oprydning
                if (boks.Text.Length == 0 && _datavisningListe.Count != lv_bøger.Items.Count)
                {
                    opdatereList(lv_bøger, _datavisningListe);
                }
                l_søgBøger.Foreground = Brushes.LightGray;
            }
        }

        private void søgBrætspil_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void søgUdstyr_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void søgLokale_KeyUp(object sender, KeyEventArgs e)
        {

        }

        #endregion
    }
}
