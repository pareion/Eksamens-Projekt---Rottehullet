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

        private int _aktivId = 0;
        private object _aktivInfo = null;

        private void AktivSlettet() {
            MessageBox.Show("Aktivet du forsøger at ændre, er blevet slettet af en anden bruger");
            
        }
        public OpretÆndreAktiv()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Oprettelse Aktiv Constructor
        /// </summary>
        /// <param name="index"></param>
        public OpretÆndreAktiv(int index)
        {
            InitializeComponent();
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
            // Frigiver en fane & Instantiere aktiv info
            tilladTab(index);
            _aktivInfo = data;
            // Udfylder aktiv info til alle felter
            opfylderAktivInfo(index);
        }

        #region Event

        private void btn_GemBog_Click(object sender, RoutedEventArgs e)
        {
            UIFacade.HentUIFacade().HentBogFacade().SkabBog(tb_Titel.Text,tb_Forfatter.Text,tb_Genre.Text,tb_Subkategori.Text,tb_Familie.Text,tb_Familie.Text,tb_Kommentar.Text);
        }

        private void btn_GemBrætspil_Click(object sender, RoutedEventArgs e)
        {
            UIFacade.HentUIFacade().HentBrætSpilFacade().SkabBrætSpil(0, tb_Brætspilnavn.Text, tb_BrætspilUdgiver.Text, tb_BrætspilKommentar.Text);
        }

        private void btn_GemUdstyr_Click(object sender, RoutedEventArgs e)
        {
            UIFacade.HentUIFacade().HentUdstyrFacade().SkabUdstyr(0,tb_Udstyrnavn.Text, tb_UdstyrKategori.Text, tb_UdstyrKommentar.Text);
        }

        private void btn_GemLokale_Click(object sender, RoutedEventArgs e)
        {
            UIFacade.HentUIFacade().HentLokaleFacade().SkabLokale(0, tb_Lokalenavn.Text, tb_Lokation.Text, tb_LokaleKommentar.Text, tb_LokaleMøbler.Text);
        }

        #endregion

        #region Funktioner
        private void gemAktiv(IndexTab index)
        {
            switch (index)
            {
                case IndexTab.Bog:
                    UIFacade.HentUIFacade().HentBogFacade().SkabBog(tb_Titel.Text, tb_Forfatter.Text, tb_Genre.Text, tb_Subkategori.Text, tb_Familie.Text, tb_Familie.Text, tb_Kommentar.Text);
                    break;
                case IndexTab.Brætspil:
                    UIFacade.HentUIFacade().HentBrætSpilFacade().SkabBrætSpil(0, tb_Brætspilnavn.Text, tb_BrætspilUdgiver.Text, tb_BrætspilKommentar.Text);
                    break;
                case IndexTab.Udstyr:
                    UIFacade.HentUIFacade().HentUdstyrFacade().SkabUdstyr(0, tb_Udstyrnavn.Text, tb_UdstyrKategori.Text, tb_UdstyrKommentar.Text);
                    break;
                case IndexTab.Lokale:
                    UIFacade.HentUIFacade().HentLokaleFacade().SkabLokale(0, tb_Lokalenavn.Text, tb_Lokation.Text, tb_LokaleKommentar.Text, tb_LokaleMøbler.Text);
                    break;
                default:
                    throw new Exception("Denne fane fines ikke");
            }
        }
        private void redigereAktiv(IndexTab index)
        {
            switch (index)
            {
                case IndexTab.Bog:
                    UIFacade.HentUIFacade().HentBogFacade().ÆndreBog(_aktivId, tb_Titel.Text, tb_Forfatter.Text, tb_Genre.Text, tb_Subkategori.Text, tb_Familie.Text, tb_Familie.Text, tb_Kommentar.Text);
                    break;
                case IndexTab.Brætspil:
                    UIFacade.HentUIFacade().HentBrætSpilFacade().ÆndreBrætSpil(_aktivId, _aktivId, tb_Brætspilnavn.Text, tb_BrætspilUdgiver.Text, tb_BrætspilKommentar.Text);
                    break;
                case IndexTab.Udstyr:
                    UIFacade.HentUIFacade().HentUdstyrFacade().ÆndreUdstyr(_aktivId, _aktivId, tb_Udstyrnavn.Text, tb_UdstyrKategori.Text, tb_UdstyrKommentar.Text);
                    break;
                case IndexTab.Lokale:
                    UIFacade.HentUIFacade().HentLokaleFacade().ÆndreLokale(_aktivId, _aktivId, tb_Lokalenavn.Text, tb_Lokation.Text, tb_LokaleKommentar.Text, tb_LokaleMøbler.Text);
                    break;
                default:
                    throw new Exception("Denne fane fines ikke");
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
                    tb_Titel.Text = (string)type.GetProperty("Titel").GetValue(_aktivInfo, null);
                    tb_Forfatter.Text = (string)type.GetProperty("Forfatter").GetValue(_aktivInfo, null);
                    tb_Genre.Text = (string)type.GetProperty("Genre").GetValue(_aktivInfo, null);
                    tb_Subkategori.Text = (string)type.GetProperty("Subkategori").GetValue(_aktivInfo, null);
                    tb_Familie.Text = (string)type.GetProperty("Familie").GetValue(_aktivInfo, null);
                    tb_Forlag.Text = (string)type.GetProperty("Forlag").GetValue(_aktivInfo, null);
                    tb_Kommentar.Text = (string)type.GetProperty("Kommentar").GetValue(_aktivInfo, null);
                    break;
                case 1:
                    // Instantiere Aktiv ID
                    _aktivId = (int)type.GetProperty("Id").GetValue(_aktivInfo, null);
                    // Udfylder textboks med aktiv info
                    tb_Brætspilnavn.Text = (string)type.GetProperty("BrætspilsNavn").GetValue(_aktivInfo, null);
                    tb_BrætspilUdgiver.Text = (string)type.GetProperty("Udgiver").GetValue(_aktivInfo, null);
                    tb_BrætspilKommentar.Text = (string)type.GetProperty("Kommentar").GetValue(_aktivInfo, null);
                    break;
                case 2:
                    // Instantiere Aktiv ID
                    _aktivId = (int)type.GetProperty("Id").GetValue(_aktivInfo, null);
                    // Udfylder textboks med aktiv info
                    tb_Udstyrnavn.Text = (string)type.GetProperty("UdstyrsNavn").GetValue(_aktivInfo, null);
                    tb_UdstyrKategori.Text = (string)type.GetProperty("Kategori").GetValue(_aktivInfo, null);
                    tb_UdstyrKommentar.Text = (string)type.GetProperty("Kommentar").GetValue(_aktivInfo, null);
                    break;
                case 3:
                    // Instantiere Aktiv ID
                    _aktivId = (int)type.GetProperty("Id").GetValue(_aktivInfo, null);
                    // Udfylder textboks med aktiv info
                    tb_Lokalenavn.Text = (string)type.GetProperty("LokaleNavn").GetValue(_aktivInfo, null);
                    tb_Lokation.Text = (string)type.GetProperty("Lokation").GetValue(_aktivInfo, null);
                    tb_LokaleMøbler.Text = (string)type.GetProperty("Møbler").GetValue(_aktivInfo, null);
                    tb_LokaleKommentar.Text = (string)type.GetProperty("Kommentar").GetValue(_aktivInfo, null);
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
