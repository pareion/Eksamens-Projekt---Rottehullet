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
    /// Interaction logic for OpretÆndreAktiv.xaml
    /// </summary>
    public partial class OpretÆndreAktiv : Window
    {
        public enum IndexTab { Bog, Brætspil, Udstyr, Lokale }

        // variabler for redigering
        private int _aktivId = 0;
        private object _aktivInfo = null;
        private bool _tilladelse = false;
        private Dictionary<string, string> _originalInfo = new Dictionary<string, string>();
        private IndexTab faneIndeks = IndexTab.Bog;
        private bool erOpret { get; set; }

        private void AktivSlettet()
        {
            MessageBox.Show("Aktivet du forsøger at ændre, er blevet slettet af en anden bruger");

        }

        #region Constructor
        public OpretÆndreAktiv()
        {
            InitializeComponent();
            windowTitel();
            erOpret = true;
        }

        /// <summary>
        /// Oprettelse Aktiv Constructor
        /// </summary>
        /// <param name="index"></param>
        public OpretÆndreAktiv(int index)
        {
            InitializeComponent();
            erOpret = true;
            windowTitel(index);
            tilladTab();
            skiftTab(index);
        }
        /// <summary>
        /// Ændring Aktiv Constructor
        /// </summary>
        /// <param name="index">Fane indeks</param>
        /// <param name="data">Aktiv info</param>
        public OpretÆndreAktiv(int index, object data)
        {
            InitializeComponent();
            erOpret = false;
            // Frigiver en fane & Instantiere aktiv info
            tilladTab(index);
            _aktivInfo = data;
            windowTitel(index);
            // Udfylder aktiv info til alle felter
            opfylderAktivInfo(index);
            faneIndeks = (IndexTab)index;
        }
        #endregion

        #region Event

        private void btn_GemBog_Click(object sender, RoutedEventArgs e)
        {
            actionAktiv(IndexTab.Bog);
        }

        private void btn_GemBrætspil_Click(object sender, RoutedEventArgs e)
        {
            actionAktiv(IndexTab.Brætspil);
        }

        private void btn_GemUdstyr_Click(object sender, RoutedEventArgs e)
        {
            actionAktiv(IndexTab.Udstyr);
        }

        private void btn_GemLokale_Click(object sender, RoutedEventArgs e)
        {
            actionAktiv(IndexTab.Lokale);
        }

        private void tekstRedigering(object sender, TextChangedEventArgs e)
        {
            if (!erOpret)
            {
                if (faneIndeks == IndexTab.Bog)
                {
                    if (tb_Titel.Text != _originalInfo["Titel"] && tb_Titel.Text != string.Empty)
                    {
                        btn_GemBog.IsEnabled = true;
                    }
                    else if (tb_Forfatter.Text != _originalInfo["Forfatter"] && tb_Forfatter.Text != string.Empty)
                    {
                        btn_GemBog.IsEnabled = true;
                    }
                    else if (tb_Genre.Text != _originalInfo["Genre"] && tb_Genre.Text != string.Empty)
                    {
                        btn_GemBog.IsEnabled = true;
                    }
                    else if (tb_Subkategori.Text != _originalInfo["Subkategori"] && tb_Subkategori.Text != string.Empty)
                    {
                        btn_GemBog.IsEnabled = true;
                    }
                    else if (tb_Familie.Text != _originalInfo["Familie"] && tb_Familie.Text != string.Empty)
                    {
                        btn_GemBog.IsEnabled = true;
                    }
                    else if (tb_Forlag.Text != _originalInfo["Forlag"] && tb_Forlag.Text != string.Empty)
                    {
                        btn_GemBog.IsEnabled = true;
                    }
                    else if (tb_Kommentar.Text != _originalInfo["Kommentar"] && tb_Kommentar.Text != string.Empty)
                    {
                        btn_GemBog.IsEnabled = true;
                    }
                    else
                    {
                        btn_GemBog.IsEnabled = false;
                    }
                }
                else if (faneIndeks == IndexTab.Brætspil)
                {
                    if (tb_Brætspilnavn.Text != _originalInfo["BrætspilsNavn"] && tb_Brætspilnavn.Text != string.Empty)
                    {
                        btn_GemBrætspil.IsEnabled = true;
                    }
                    else if (tb_BrætspilUdgiver.Text != _originalInfo["BrætspilUdgiver"] && tb_BrætspilUdgiver.Text != string.Empty)
                    {
                        btn_GemBrætspil.IsEnabled = true;
                    }
                    else if (tb_BrætspilKommentar.Text != _originalInfo["BrætspilKommentar"] && tb_BrætspilKommentar.Text != string.Empty)
                    {
                        btn_GemUdstyr.IsEnabled = true;
                    }
                    else
                    {
                        btn_GemBrætspil.IsEnabled = false;
                    }
                }
                else if (faneIndeks == IndexTab.Udstyr)
                {
                    if (tb_Udstyrnavn.Text != _originalInfo["UdstyrsNavn"] && tb_Udstyrnavn.Text != string.Empty)
                    {
                        btn_GemUdstyr.IsEnabled = true;
                    }
                    else if (tb_UdstyrKategori.Text != _originalInfo["UdstyrKategori"] && tb_UdstyrKategori.Text != string.Empty)
                    {
                        btn_GemUdstyr.IsEnabled = true;
                    }
                    else if (tb_UdstyrKommentar.Text != _originalInfo["UdstyrKommentar"] && tb_UdstyrKommentar.Text != string.Empty)
                    {
                        btn_GemUdstyr.IsEnabled = true;
                    }
                    else
                    {
                        btn_GemUdstyr.IsEnabled = false;
                    }
                }
                else if (faneIndeks == IndexTab.Lokale)
                {
                    if (tb_Lokalenavn.Text != _originalInfo["LokaleNavn"] && tb_Lokalenavn.Text != string.Empty)
                    {
                        btn_GemLokale.IsEnabled = true;
                    }
                    else if (tb_Lokation.Text != _originalInfo["Lokation"] && tb_Lokation.Text != string.Empty)
                    {
                        btn_GemLokale.IsEnabled = true;
                    }
                    else if (tb_LokaleMøbler.Text != _originalInfo["LokaleMøbler"] && tb_LokaleMøbler.Text != string.Empty)
                    {
                        btn_GemLokale.IsEnabled = true;
                    }
                    else if (tb_LokaleKommentar.Text != _originalInfo["LokaleKommentar"] && tb_LokaleKommentar.Text != string.Empty)
                    {
                        btn_GemLokale.IsEnabled = true;
                    }
                    else
                    {
                        btn_GemLokale.IsEnabled = false;
                    }
                }
            }
        }
        #endregion

        #region Funktioner

        private void windowTitel(int index = -1)
        {
            string titel = _aktivInfo == null ? "Opret" : "Redigere";
            switch (index)
            {
                case 0:
                    Title = titel + " bog";
                    break;
                case 1:
                    Title = titel + " brætspil";
                    break;
                case 2:
                    Title = titel + " udstyr";
                    break;
                case 3:
                    Title = titel + " lokale";
                    break;
                default:
                    Title = "Opret aktiv";
                    break;
            }
        }

        private void actionAktiv(IndexTab index)
        {
            if (_aktivInfo == null)
            {
                gemAktiv(index);
            }
            else
            {
                redigereAktiv(index);
            }

            // Opdaterer ListView på hoved vindue
            AdminPanel win = this.Owner as AdminPanel;
            win.IndlæsData();

            this.Close();
        }

        private void gemAktiv(IndexTab index)
        {
            switch (index)
            {
                case IndexTab.Bog:
                    UIFacade.HentUIFacade().HentBogFacade().SkabBog(tb_Titel.Text, tb_Forfatter.Text, tb_Genre.Text, tb_Subkategori.Text, tb_Familie.Text, tb_Forlag.Text, cb_BogUdlån.IsChecked == true ? true : false, tb_Kommentar.Text);
                    break;
                case IndexTab.Brætspil:
                    UIFacade.HentUIFacade().HentBrætSpilFacade().SkabBrætSpil(0, tb_Brætspilnavn.Text, tb_BrætspilUdgiver.Text, (bool) cb_BrætspilUdlån.IsChecked, tb_BrætspilKommentar.Text, tb_BrætspilKategori.Text);
                    break;
                case IndexTab.Udstyr:
                    UIFacade.HentUIFacade().HentUdstyrFacade().SkabUdstyr(0, tb_Udstyrnavn.Text, tb_UdstyrKategori.Text, cb_UdstyrUdlån.IsChecked == true ? true : false, tb_UdstyrKommentar.Text);
                    break;
                case IndexTab.Lokale:
                    UIFacade.HentUIFacade().HentLokaleFacade().SkabLokale(0, tb_Lokalenavn.Text, tb_Lokation.Text, cb_LokaleUdlån.IsChecked == true ? true : false, tb_LokaleKommentar.Text, tb_LokaleMøbler.Text);
                    break;
                default:
                    throw new Exception("Denne fane findes ikke");
            }
        }

        private void redigereAktiv(IndexTab index)
        {
            switch (index)
            {
                case IndexTab.Bog:
                    UIFacade.HentUIFacade().HentBogFacade().ÆndreBog(_aktivId, tb_Titel.Text, tb_Forfatter.Text, tb_Genre.Text, tb_Subkategori.Text, tb_Familie.Text, tb_Familie.Text, cb_BogUdlån.IsChecked == true ? true : false, tb_Kommentar.Text);
                    break;
                case IndexTab.Brætspil:
                    UIFacade.HentUIFacade().HentBrætSpilFacade().ÆndreBrætSpil(_aktivId, _aktivId, tb_Brætspilnavn.Text, tb_BrætspilUdgiver.Text, cb_BrætspilUdlån.IsChecked == true ? true : false, tb_BrætspilKommentar.Text, tb_BrætspilKategori.Text);
                    break;
                case IndexTab.Udstyr:
                    UIFacade.HentUIFacade().HentUdstyrFacade().ÆndreUdstyr(_aktivId, _aktivId, tb_Udstyrnavn.Text, tb_UdstyrKategori.Text, cb_UdstyrUdlån.IsChecked == true ? true : false, tb_UdstyrKommentar.Text);
                    break;
                case IndexTab.Lokale:
                    UIFacade.HentUIFacade().HentLokaleFacade().ÆndreLokale(_aktivId, _aktivId, tb_Lokalenavn.Text, tb_Lokation.Text, cb_LokaleUdlån.IsChecked == true ? true : false, tb_LokaleKommentar.Text, tb_LokaleMøbler.Text);
                    break;
                default:
                    throw new Exception("Denne fane findes ikke");
            }
        }

        private void opfylderAktivInfo(int aktivType)
        {
            Type type = _aktivInfo.GetType();
            switch (aktivType)
            {
                case 0:
                    // Instantiere Aktiv ID
                    _aktivId = (int)type.GetProperty("Id").GetValue(_aktivInfo, null);
                    // Udfylder textboks med aktiv info
                    _originalInfo.Add("Titel", (string)type.GetProperty("Titel").GetValue(_aktivInfo, null));
                    _originalInfo.Add("Forfatter", (string)type.GetProperty("Forfatter").GetValue(_aktivInfo, null));
                    _originalInfo.Add("Genre", (string)type.GetProperty("Genre").GetValue(_aktivInfo, null));
                    _originalInfo.Add("Subkategori", (string)type.GetProperty("Subkategori").GetValue(_aktivInfo, null));
                    _originalInfo.Add("Familie", (string)type.GetProperty("Familie").GetValue(_aktivInfo, null));
                    _originalInfo.Add("Forlag", (string)type.GetProperty("Forlag").GetValue(_aktivInfo, null));
                    _originalInfo.Add("Kommentar", (string)type.GetProperty("Kommentar").GetValue(_aktivInfo, null));
                    _tilladelse = (bool)type.GetProperty("Udlånes").GetValue(_aktivInfo, null);

                    tb_Titel.Text = _originalInfo["Titel"];
                    tb_Forfatter.Text = _originalInfo["Forfatter"];
                    tb_Genre.Text = _originalInfo["Genre"];
                    tb_Subkategori.Text = _originalInfo["Subkategori"];
                    tb_Familie.Text = _originalInfo["Familie"];
                    tb_Forlag.Text = _originalInfo["Forlag"];
                    tb_Kommentar.Text = _originalInfo["Kommentar"];
                    cb_BogUdlån.IsChecked = _tilladelse;

                    btn_GemBog.IsEnabled = false;
                    break;
                case 1:
                    // Instantiere Aktiv ID
                    _aktivId = (int)type.GetProperty("Id").GetValue(_aktivInfo, null);
                    // Udfylder textboks med aktiv info
                    _originalInfo.Add("BrætspilsNavn", (string)type.GetProperty("BrætspilsNavn").GetValue(_aktivInfo, null));
                    _originalInfo.Add("BrætspilUdgiver", (string)type.GetProperty("Udgiver").GetValue(_aktivInfo, null));
                    _originalInfo.Add("BrætspilKommentar", (string)type.GetProperty("Kommentar").GetValue(_aktivInfo, null));
                    _originalInfo.Add("BrætspilKategori", (string)type.GetProperty("Kategori").GetValue(_aktivInfo, null));
                    _tilladelse  = (bool)type.GetProperty("Udlånes").GetValue(_aktivInfo, null);

                    tb_Brætspilnavn.Text = _originalInfo["BrætspilsNavn"];
                    tb_BrætspilUdgiver.Text = _originalInfo["BrætspilUdgiver"];
                    tb_BrætspilKommentar.Text = _originalInfo["BrætspilKommentar"];
                    tb_BrætspilKategori.Text = _originalInfo["BrætspilKategori"];
                    cb_BrætspilUdlån.IsChecked = _tilladelse;

                    btn_GemBog.IsEnabled = false;
                    break;
                case 2:
                    // Instantiere Aktiv ID
                    _aktivId = (int)type.GetProperty("Id").GetValue(_aktivInfo, null);
                    // Udfylder textboks med aktiv info
                    _originalInfo.Add("UdstyrsNavn", (string)type.GetProperty("UdstyrsNavn").GetValue(_aktivInfo, null));
                    _originalInfo.Add("UdstyrKategori", (string)type.GetProperty("Kategori").GetValue(_aktivInfo, null));
                    _originalInfo.Add("UdstyrKommentar", (string)type.GetProperty("Kommentar").GetValue(_aktivInfo, null));
                    _tilladelse = (bool)type.GetProperty("Udlånes").GetValue(_aktivInfo, null);

                    tb_Udstyrnavn.Text = _originalInfo["UdstyrsNavn"];
                    tb_UdstyrKategori.Text = _originalInfo["UdstyrKategori"];
                    tb_UdstyrKommentar.Text = _originalInfo["UdstyrKommentar"];
                    cb_UdstyrUdlån.IsChecked = _tilladelse;

                    btn_GemBog.IsEnabled = false;
                    break;
                case 3:
                    // Instantiere Aktiv ID
                    _aktivId = (int)type.GetProperty("Id").GetValue(_aktivInfo, null);
                    // Udfylder textboks med aktiv info
                    _originalInfo.Add("LokaleNavn", (string)type.GetProperty("LokaleNavn").GetValue(_aktivInfo, null));
                    _originalInfo.Add("Lokation", (string)type.GetProperty("Lokation").GetValue(_aktivInfo, null));
                    _originalInfo.Add("LokaleMøbler", (string)type.GetProperty("Møbler").GetValue(_aktivInfo, null));
                    _originalInfo.Add("LokaleKommentar", (string)type.GetProperty("Kommentar").GetValue(_aktivInfo, null));
                    _tilladelse = (bool)type.GetProperty("Udlånes").GetValue(_aktivInfo, null);

                    tb_Lokalenavn.Text = _originalInfo["LokaleNavn"];
                    tb_Lokation.Text = _originalInfo["Lokation"];
                    tb_LokaleMøbler.Text = _originalInfo["LokaleMøbler"];
                    tb_LokaleKommentar.Text = _originalInfo["LokaleKommentar"];
                    cb_UdstyrUdlån.IsChecked = _tilladelse;

                    btn_GemBog.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void tilladTab()
        {
            foreach (TabItem item in maintab.Items)
            {
                item.IsEnabled = true;
            }
        }
        private void tilladTab(int index)
        {
            faneIndeks = (IndexTab)index;
            TabItem item = maintab.Items[index] as TabItem;
            item.IsEnabled = true;
            skiftTab(index);
        }
        private void skiftTab(int index)
        {
            maintab.TabIndex = index;
            maintab.SelectedIndex = index;
        }
        private void annullereProces(object sender, RoutedEventArgs e)
        {
            // Lukke Opret og Ændre aktiv vindue ned
            this.Close();
        }

        #endregion


    }
}
