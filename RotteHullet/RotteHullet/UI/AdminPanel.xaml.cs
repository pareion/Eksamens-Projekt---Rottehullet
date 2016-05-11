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

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private List<object> _bogData = new List<object>();
        private List<object> _brætspilData = new List<object>();
        private List<object> _udstyrData = new List<object>();
        private List<object> _lokaleData = new List<object>();
        private List<object> _udlånData = new List<object>();
        private List<Tuple<string, object, DateTime>> _udlånDataTuple = new List<Tuple<string, object, DateTime>>();
        private List<UdlånData> _reservationData = new List<UdlånData>();

        private object _selectBog = null;
        private object _selectBrætspil = null;
        private object _selectUdstyr = null;
        private object _selectLokale = null;

        public AdminPanel()
        {
            InitializeComponent();
            IndlæsData();
        }

        #region Funktioner

    

        class UdlånData
        {
            public string MedlemsNavn { get; private set; }
            public string BestillingsDato { get; private set; }
            public string ReservationType { get; private set; }

            private DateTime _dato;
            private object _aktiv;

            public UdlånData(string navn, object aktiv, DateTime dato)
            {
                // Gem original data source
                _aktiv = aktiv;
                _dato = dato;

                MedlemsNavn = navn;
                BestillingsDato = dato.ToString("dd-MM-yyyy HH:mm:ss");

                // Bestemmer selv hvad man vil gerne se i "Reserveret materiale"
                ReservationType = aktiv.ToString();
            }
        }

        internal void IndlæsData()
        {
            // Rydder lister op 
            fjernLister();

            try
            {
                

                // Indlæser nye data
                _bogData = UIFacade.HentUIFacade().HentBogFacade().FindAlleBøger();
                _bogData.ForEach(x => lv_bøger.Items.Add(x));

                _brætspilData = UIFacade.HentUIFacade().HentBrætSpilFacade().FindAlleBrætspil();
                _brætspilData.ForEach(x => lv_brætspil.Items.Add(x));

                _udstyrData = UIFacade.HentUIFacade().HentUdstyrFacade().FindAlleUdstyr();
                _udstyrData.ForEach(x => lv_udstyr.Items.Add(x));

                _lokaleData = UIFacade.HentUIFacade().HentLokaleFacade().FindAlleLokaler();
                _lokaleData.ForEach(x => lv_lokal.Items.Add(x));

                // Forventer logisk fejl (Logic error)
                /*_udlånDataTuple = UIFacade.HentUIFacade().HentUdlåningsFacade().FindAlleUdlån();
                foreach (Tuple<string, object, DateTime> item in _udlånDataTuple)
                {
                    _reservationData.Add(new UdlånData(item.Item1, item.Item2, item.Item3));
                    
                    //MyItem my = new MyItem(item.Item1,item.Item2);
                    //lv_udlån.Items.Add(my);
                }
                _reservationData.ForEach(x => lv_udlån.Items.Add(x));*/

                //_udlånDataTuple.ForEach(x => lv_udlån.Items.Add(x));
                

            }
            catch
            {
                MessageBox.Show("Kan ikke få forbindelse til database");
            }

            
        }

        private void skabUdlånsliste() {

        }

        private void fjernLister()
        {
            lv_bøger.Items.Clear();
            lv_brætspil.Items.Clear();
            lv_udstyr.Items.Clear();
            lv_lokal.Items.Clear();
            lv_udlån.Items.Clear();
        }

        private void redigereAktiv()
        {
            OpretÆndreAktiv opret;

            if (adminTab.SelectedIndex == 0)
            {
                opret = new OpretÆndreAktiv(adminTab.SelectedIndex, lv_bøger.SelectedItem);
            }
            else if (adminTab.SelectedIndex == 1)
            {
                opret = new OpretÆndreAktiv(adminTab.SelectedIndex, lv_brætspil.SelectedItem);
            }
            else if (adminTab.SelectedIndex == 2)
            {
                opret = new OpretÆndreAktiv(adminTab.SelectedIndex, lv_udstyr.SelectedItem);
            }
            else
            {
                opret = new OpretÆndreAktiv(adminTab.SelectedIndex, lv_lokal.SelectedItem);
            }
            opret.Owner = this;
            opret.ShowDialog();
        }

        private string forkortTekst(string tekst, int længde = 24, string slutningTekst = "...")
        {
            if (tekst.Length > længde)
            {
                return tekst.Substring(0, længde) + slutningTekst;
            }
            else
            {
                return tekst;
            }
        } 

        private void sletAktiv()
        {
            if (adminTab.SelectedIndex == 0)
            {
                if (lv_bøger.SelectedIndex != -1)
                {
                    string navn = (string)lv_bøger.SelectedItem.GetType().GetProperty("Titel").GetValue(lv_bøger.SelectedItem, null);
                    string besked = string.Format("Vil du slette \"{0}\"?", forkortTekst(navn));

                    int id = (int)lv_bøger.SelectedItem.GetType().GetProperty("Id").GetValue(lv_bøger.SelectedItem, null);

                    MessageBoxResult svar = MessageBox.Show(besked, "Slet bog ID:" + id.ToString(), MessageBoxButton.YesNo);
                    if (svar == MessageBoxResult.Yes)
                    {
                        // Slet bog fra database
                        UIFacade.HentUIFacade().HentBogFacade().SletBog(id);

                        // Slet bog fra liste
                        lv_bøger.Items.Remove(lv_bøger.SelectedItem);
                    }
                }
            }
            else if (adminTab.SelectedIndex == 1)
            {
                if (lv_brætspil.SelectedIndex != -1)
                {
                    string navn = (string)lv_brætspil.SelectedItem.GetType().GetProperty("BrætspilsNavn").GetValue(lv_brætspil.SelectedItem, null);
                    string besked = string.Format("Vil du slet \"{0}\"?", forkortTekst(navn));

                    int id = (int)lv_brætspil.SelectedItem.GetType().GetProperty("Id").GetValue(lv_brætspil.SelectedItem, null);

                    MessageBoxResult svar = MessageBox.Show(besked, "Slet brætspil ID:" + id.ToString(), MessageBoxButton.YesNo);
                    if (svar == MessageBoxResult.Yes)
                    {
                        // Slet bog fra database
                        UIFacade.HentUIFacade().HentBrætSpilFacade().SletBrætSpil(id);

                        // Slet bog fra liste
                        lv_brætspil.Items.Remove(lv_brætspil.SelectedItem);
                    }
                }
            }
            else if (adminTab.SelectedIndex == 2)
            {
                if (lv_udstyr.SelectedIndex != -1)
                {
                    string navn = (string)lv_udstyr.SelectedItem.GetType().GetProperty("UdstyrsNavn").GetValue(lv_udstyr.SelectedItem, null);
                    string besked = string.Format("Vil du slet \"{0}\"?", forkortTekst(navn));

                    int id = (int)lv_udstyr.SelectedItem.GetType().GetProperty("Id").GetValue(lv_udstyr.SelectedItem, null);

                    MessageBoxResult svar = MessageBox.Show(besked, "Slet udstyr ID:" + id.ToString(), MessageBoxButton.YesNo);
                    if (svar == MessageBoxResult.Yes)
                    {
                        // Slet bog fra database
                        UIFacade.HentUIFacade().HentUdstyrFacade().SletUdstyr(id);

                        // Slet bog fra liste
                        lv_udstyr.Items.Remove(lv_udstyr.SelectedItem);
                    }
                }
            }
            else
            {
                if (lv_lokal.SelectedIndex != -1)
                {
                    string navn = (string)lv_lokal.SelectedItem.GetType().GetProperty("LokaleNavn").GetValue(lv_lokal.SelectedItem, null);
                    string besked = string.Format("Vil du slet \"{0}\"?", forkortTekst(navn));

                    int id = (int)lv_lokal.SelectedItem.GetType().GetProperty("Id").GetValue(lv_lokal.SelectedItem, null);

                    MessageBoxResult svar = MessageBox.Show(besked, "Slet lokale ID:" + id.ToString(), MessageBoxButton.YesNo);
                    if (svar == MessageBoxResult.Yes)
                    {
                        // Slet bog fra database
                        UIFacade.HentUIFacade().HentLokaleFacade().SletLokale(id);

                        // Slet bog fra liste
                        lv_lokal.Items.Remove(lv_lokal.SelectedItem);
                    }
                }
            }
        }

        #endregion

        #region Udvælgelse event

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

        private void lv_brætspil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lv_brætspil.SelectedIndex != -1)
            {
                b_redigereBrætspil.IsEnabled = true;
                b_sletBrætspil.IsEnabled = true;
                _selectBrætspil = lv_brætspil.Items.GetItemAt(lv_brætspil.SelectedIndex);
            }
            else
            {
                b_redigereBrætspil.IsEnabled = false;
                b_sletBrætspil.IsEnabled = false;
            }
        }

        private void lv_udstyr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lv_udstyr.SelectedIndex != -1)
            {
                b_redigereUdstyr.IsEnabled = true;
                b_sletUdstyr.IsEnabled = true;
                _selectUdstyr = lv_udstyr.Items.GetItemAt(lv_udstyr.SelectedIndex);
            }
            else
            {
                b_redigereUdstyr.IsEnabled = false;
                b_sletUdstyr.IsEnabled = false;
            }
        }

        private void lv_lokal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lv_lokal.SelectedIndex != -1)
            {
                b_redigereLokal.IsEnabled = true;
                b_sletLokal.IsEnabled = true;
                _selectLokale = lv_lokal.Items.GetItemAt(lv_lokal.SelectedIndex);
            }
            else
            {
                b_redigereLokal.IsEnabled = false;
                b_sletLokal.IsEnabled = false;
            }
        }

        #endregion

        #region Klik event
        private void opret_Click(object sender, RoutedEventArgs e)
        {
            OpretÆndreAktiv opret = new OpretÆndreAktiv(adminTab.SelectedIndex);
            opret.Owner = this;
            opret.ShowDialog();
        }

        private void redigere_Click(object sender, RoutedEventArgs e)
        {
            redigereAktiv();
        }

        private void slet_Click(object sender, RoutedEventArgs e)
        {
            sletAktiv();
        }

        #endregion

        #region Søgning event

        private void opdatereList(ListView dataListe, List<object> data)
        {
            dataListe.Items.Clear();

            switch(data.GetType().Name)
            {
                case "Bog":
                    _bogData = data;
                    break;
                case "Brætspil":
                    _brætspilData = data;
                    break;
                case "Udstyr":
                    _udstyrData = data;
                    break;
                case "Lokale":
                    _lokaleData = data;
                    break;
                case "Udlån":
                    _udlånData = data;
                    break;
            }

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
                    opdatereList(lv_bøger, UIFacade.HentUIFacade().HentBogFacade().FindAlleBøger(boks.Text.ToLower()));
                }
                else if (e.Key == Key.Escape)
                {
                    l_søgBøger.Foreground = Brushes.LightGray;
                    boks.Text = "";
                    opdatereList(lv_bøger, _bogData);
                }
            }
            else
            {
                // Effektiv data oprydning
                if (boks.Text.Length == 0 && _bogData.Count != lv_bøger.Items.Count)
                {
                    opdatereList(lv_bøger, UIFacade.HentUIFacade().HentBogFacade().FindAlleBøger());
                }
                l_søgBøger.Foreground = Brushes.LightGray;
            }
        }

        private void søgBrætspil_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox boks = sender as TextBox;
            if (boks.Text.Length > 1)
            {
                l_søgBrætspil.Foreground = Brushes.Black;

                // Laver søgning
                if (e.Key == Key.Enter)
                {
                    // Sætter ListView objekt for bøger og søg resultater til opdatere ListView list
                    opdatereList(lv_brætspil, UIFacade.HentUIFacade().HentBrætSpilFacade().FindAlleBrætspil(boks.Text.ToLower()));
                }
                else if (e.Key == Key.Escape)
                {
                    l_søgBrætspil.Foreground = Brushes.LightGray;
                    boks.Text = "";
                    opdatereList(lv_brætspil, UIFacade.HentUIFacade().HentBrætSpilFacade().FindAlleBrætspil());
                }
            }
            else
            {
                // Effektiv data oprydning
                if (boks.Text.Length == 0 && _brætspilData.Count != lv_brætspil.Items.Count)
                {
                    opdatereList(lv_brætspil, _brætspilData);
                }
                l_søgBrætspil.Foreground = Brushes.LightGray;
            }
        }

        private void søgUdstyr_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox boks = sender as TextBox;
            if (boks.Text.Length > 1)
            {
                l_søgUdstyr.Foreground = Brushes.Black;

                // Laver søgning
                if (e.Key == Key.Enter)
                {
                    // Sætter ListView objekt for bøger og søg resultater til opdatere ListView list
                    opdatereList(lv_udstyr, UIFacade.HentUIFacade().HentUdstyrFacade().FindAlleUdstyr(boks.Text.ToLower()));
                }
                else if (e.Key == Key.Escape)
                {
                    l_søgUdstyr.Foreground = Brushes.LightGray;
                    boks.Text = "";
                    opdatereList(lv_udstyr, UIFacade.HentUIFacade().HentUdstyrFacade().FindAlleUdstyr());
                }
            }
            else
            {
                // Effektiv data oprydning
                if (boks.Text.Length == 0 && _udstyrData.Count != lv_udstyr.Items.Count)
                {
                    opdatereList(lv_udstyr, _udstyrData);
                }
                l_søgUdstyr.Foreground = Brushes.LightGray;
            }
        }

        private void søgLokale_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox boks = sender as TextBox;
            if (boks.Text.Length > 1)
            {
                l_søgLokale.Foreground = Brushes.Black;

                // Laver søgning
                if (e.Key == Key.Enter)
                {
                    // Sætter ListView objekt for bøger og søg resultater til opdatere ListView list
                    opdatereList(lv_lokal, UIFacade.HentUIFacade().HentLokaleFacade().FindAlleLokaler(boks.Text.ToLower()));
                }
                else if (e.Key == Key.Escape)
                {
                    l_søgLokale.Foreground = Brushes.LightGray;
                    boks.Text = "";
                    opdatereList(lv_lokal, UIFacade.HentUIFacade().HentLokaleFacade().FindAlleLokaler());
                }
            }
            else
            {
                // Effektiv data oprydning
                if (boks.Text.Length == 0 && _lokaleData.Count != lv_lokal.Items.Count)
                {
                    opdatereList(lv_lokal, _lokaleData);
                }
                l_søgLokale.Foreground = Brushes.LightGray;
            }
        }

        #endregion

        #region Doubleklik event

        private void lv_bøger_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lv_bøger.SelectedIndex != -1)
            {
                redigereAktiv();
            }
        }

        private void lv_brætspil_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lv_brætspil.SelectedIndex != -1)
            {
                redigereAktiv();
            }
        }

        private void lv_udstyr_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lv_udstyr.SelectedIndex != -1)
            {
                redigereAktiv();
            }
        }

        private void lv_lokale_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lv_lokal.SelectedIndex != -1)
            {
                redigereAktiv();
            }
        }

        #endregion

        private void slet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                sletAktiv();
            }
        }

        private void btn_Bestillingsinfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Opdater_Click(object sender, RoutedEventArgs e)
        {
            IndlæsData();
        }
        private void lv_udlån_DoubleClick(object sender, RoutedEventArgs e) {
            // Gå ind i Udlånet og se dets detaljer

        }

        private void lv_udlån_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // opdatere det aktive element.
        }


        

    }
}
