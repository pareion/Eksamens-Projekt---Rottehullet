using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace RotteHullet.UI
{
    /// <summary>
    /// Interaction logic for BrugerPanel.xaml
    /// </summary>
    public partial class BrugerPanel : Window
    {
        private ListView _bogView, _brætspilView, _udstyrView, _lokaleView;
        public enum AktivType { Bog, Brætspil, Udstyr, Lokale }
        public AktivType SøgType
        {
            get
            {
                if (rb_Bog.IsChecked == true)
                {
                    return AktivType.Bog;
                }
                else if (rb_Brætspil.IsChecked == true)
                {
                    return AktivType.Brætspil;
                }
                else if (rb_Udstyr.IsChecked == true)
                {
                    return AktivType.Udstyr;
                }
                else if (rb_Lokale.IsChecked == true)
                {
                    return AktivType.Lokale;
                }
                else
                {
                    return AktivType.Bog;
                }
            }
        }
        public bool LåsFilter { get; private set; }

        private GridViewColumnHeader listViewCol = null;
        private SortAdorner listViewColUdseende = null;
        private ReservationListe reservationListe = null;
        private InfoPopup infoSide = null;
        private UdlånsListe udlånsListe = null;

        public BrugerPanel()
        {
            InitializeComponent();
        }

        #region Global metoder

        public void FjernReservation()
        {
            if (reservationListe != null && reservationListe.IsClosed)
            {
                reservationListe = null;
                frigivFilter();
                reservationInfo();
                this.Activate();
            }
        }

        public void OpdatereReservation()
        {
            reservationInfo();
        }

        public void ReservereAktiv(object data = null)
        {
            opretReservationListe();

            // Tilføj aktiv til reservation listen
            tilføjTilReservation(data);
            låsSøgningFilter();
            reservationInfo();
        }

        #endregion

        #region Event

        private void Søgning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    aktivSøgning();
                }
                catch
                {
                    MessageBox.Show("Kan ikke oprette forbindelse til serveren. Prøv igen senere");
                }
            }
        }

        private void Søgning_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                aktivSøgning();
            }
            catch
            {
                MessageBox.Show("Kan ikke oprette forbindelse til serveren. Prøv igen senere");
            }
        }

        private void AktivListe_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            visAktivInfo((ListViewItem)sender);
        }

        private void AktivListe_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                visAktivInfo((ListViewItem)sender);
            }
        }

        private void AktivListeUdvalgt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView liste = sender as ListView;
            tjekUdvalgtListe(ref liste);
        }

        private void Reservere_Click(object sender, RoutedEventArgs e)
        {
            ReservereAktiv();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            //if (infoSide.IsActive)
            //{
            //    MessageBox.Show("Success");
            //}
        }

        private void VisReservation_Click(object sender, RoutedEventArgs e)
        {
            if (reservationListe != null)
            {
                reservationListe.Show();
            }
        }

        private void VisUdlånte_Click(object sender, RoutedEventArgs e)
        {
            if (reservationListe != null)
            {
             //   reservationListe.Show();
            }
        }

        private void Filter_Checked(object sender, RoutedEventArgs e)
        {
            if (Indhold != null)
            {
                Indhold.Children.Clear();
            }
            
        }

        #endregion

        #region Funktioner

        private void visAktivInfo(ListViewItem data)
        {
            infoSide = new InfoPopup((InfoPopup.InfoType)SøgType, data.DataContext);
            infoSide.Owner = this;
            infoSide.ShowDialog();
        }

        private void opretReservationListe()
        {
            if (reservationListe == null)
            {
                reservationListe = new ReservationListe(SøgType);
                reservationListe.Owner = this;
            }
        }

        private void opretUdlånsliste()
        {
            if (udlånsListe == null)
            {
                udlånsListe = new UdlånsListe();
                udlånsListe.Owner = this;
            }
        }

        private void tilføjTilReservation(object data)
        {
            if (data == null)
            {
                switch (SøgType)
                {
                    case AktivType.Bog:
                        reservationListe.Tilføj(_bogView.SelectedItem);
                        break;
                    case AktivType.Brætspil:
                        reservationListe.Tilføj(_brætspilView.SelectedItem);
                        break;
                    case AktivType.Udstyr:
                        reservationListe.Tilføj(_udstyrView.SelectedItem);
                        break;
                    case AktivType.Lokale:
                        reservationListe.Tilføj(_lokaleView.SelectedItem);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                reservationListe.Tilføj(data);
            }
        }

        private void reservationInfo()
        {
            if (reservationListe == null || reservationListe.AntalAktiver == 0)
            {
                btn_ReservationVisning.Content = "Ingen aktiv i kurv";
            }
            else
            {
                btn_ReservationVisning.Content = string.Format("({0}) {1}", reservationListe.AntalAktiver, aktivBøjning(reservationListe.AntalAktiver));
            }
        }

        private string aktivBøjning(int antal = 0)
        {
            
            string[] bog = { "bog", "bøger" };
            string[] spil = { "brætspil", "brætspil" };
            string[] udstyr = { "udstyr", "udstyr" };
            string[] lokale = { "lokale", "lokaler" };

            string tekst = null;

            switch (SøgType)
            {
                case AktivType.Bog:
                    tekst = antal > 1 ? bog[1] : bog[0];
                    break;
                case AktivType.Brætspil:
                    tekst = antal > 1 ? spil[1] : spil[0];
                    break;
                case AktivType.Udstyr:
                    tekst = antal > 1 ? udstyr[1] : udstyr[0];
                    break;
                case AktivType.Lokale:
                    tekst = antal > 1 ? lokale[1] : lokale[0];
                    break;
                default:
                    break;
            }

            return tekst;
        }

        private void låsSøgningFilter()
        {
            if (LåsFilter == false)
            {
                switch (SøgType)
                {
                    case AktivType.Bog:
                        rb_Brætspil.IsEnabled = false;
                        rb_Udstyr.IsEnabled = false;
                        rb_Lokale.IsEnabled = false;
                        break;
                    case AktivType.Brætspil:
                        rb_Bog.IsEnabled = false;
                        rb_Udstyr.IsEnabled = false;
                        rb_Lokale.IsEnabled = false;
                        break;
                    case AktivType.Udstyr:
                        rb_Bog.IsEnabled = false;
                        rb_Brætspil.IsEnabled = false;
                        rb_Lokale.IsEnabled = false;
                        break;
                    case AktivType.Lokale:
                        rb_Bog.IsEnabled = false;
                        rb_Brætspil.IsEnabled = false;
                        rb_Udstyr.IsEnabled = false;
                        break;
                    default:
                        break;
                }

                LåsFilter = true;
            }
        }
        private void frigivFilter()
        {
            if (LåsFilter == true)
            {
                rb_Bog.IsEnabled = true;
                rb_Brætspil.IsEnabled = true;
                rb_Udstyr.IsEnabled = true;
                rb_Lokale.IsEnabled = true;

                LåsFilter = false;
            }
        }

        private void aktivSøgning()
        {
            danneListe();
            switch (SøgType)
            {
                case AktivType.Bog:
                    ResultatVisning(ref _bogView, UIFacade.HentUIFacade().HentBogFacade().FindAlleBøger(tb_Søgboks.Text));
                    break;
                case AktivType.Brætspil:
                    ResultatVisning(ref _brætspilView, UIFacade.HentUIFacade().HentBrætSpilFacade().FindAlleBrætspil(tb_Søgboks.Text));
                    tjekUdvalgtListe(ref _brætspilView);
                    break;
                case AktivType.Udstyr:
                    ResultatVisning(ref _udstyrView, UIFacade.HentUIFacade().HentUdstyrFacade().FindAlleUdstyr(tb_Søgboks.Text));
                    tjekUdvalgtListe(ref _udstyrView);
                    break;
                case AktivType.Lokale:
                    ResultatVisning(ref _lokaleView, UIFacade.HentUIFacade().HentLokaleFacade().FindAlleLokaler(tb_Søgboks.Text));
                    tjekUdvalgtListe(ref _lokaleView);
                    break;
                default:
                    break;
            }
            
        }

        private void tjekUdvalgtListe(ref ListView liste)
        {
            if(btn_Reservere.IsVisible == false)
            {
                btn_Reservere.Visibility = Visibility.Visible;
            }

            if (liste.SelectedIndex != -1)
            {
                btn_Reservere.IsEnabled = (bool)liste.SelectedItem.GetType().GetProperty("Udlånes").GetValue(liste.SelectedItem);
            }
            else
            {
                btn_Reservere.IsEnabled = false;
            }
        }

        private void ResultatVisning(ref ListView liste, List<object> resultater)
        {
            // Ryd aktiv liste
            liste.Items.Clear();

            // Indsæt aktiv info til listview
            foreach (object item in resultater)
            {
                liste.Items.Add(item);
            }
        }

        #endregion

        #region ListView Sortering
        private void Sortering_Click(object sender, RoutedEventArgs e)
        {
            switch (SøgType)
            {
                case AktivType.Bog:
                    sorteringData(sender as GridViewColumnHeader, _bogView);
                    break;
                case AktivType.Brætspil:
                    sorteringData(sender as GridViewColumnHeader, _brætspilView);
                    break;
                case AktivType.Udstyr:
                    sorteringData(sender as GridViewColumnHeader, _udstyrView);
                    break;
                case AktivType.Lokale:
                    sorteringData(sender as GridViewColumnHeader, _lokaleView);
                    break;
                default:
                    break;
            }
        }


        private void sorteringData(GridViewColumnHeader column, ListView datavising)
        {
            string sortBy = column.Tag.ToString();
            if (listViewCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewCol).Remove(listViewColUdseende);
                datavising.Items.SortDescriptions.Clear();
            }

            ListSortDirection nyRetning = ListSortDirection.Ascending;
            if (listViewCol == column && listViewColUdseende.Retning == nyRetning)
            {
                nyRetning = ListSortDirection.Descending;
            }

            listViewCol = column;
            listViewColUdseende = new SortAdorner(listViewCol, nyRetning);
            AdornerLayer.GetAdornerLayer(listViewCol).Add(listViewColUdseende);
            datavising.Items.SortDescriptions.Add(new SortDescription(sortBy, nyRetning));
        }



        private class SortAdorner : Adorner
        {
            private static Geometry ascGeo = Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");
            private static Geometry descGeo = Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Retning { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir) : base(element)
            {
                Retning = dir;
            }

            protected override void OnRender(DrawingContext drawContext)
            {
                base.OnRender(drawContext);
                if (AdornedElement.RenderSize.Width < 20)
                {
                    return;
                }
                TranslateTransform form = new TranslateTransform(AdornedElement.RenderSize.Width - 15, (AdornedElement.RenderSize.Height - 5) / 2);

                drawContext.PushTransform(form);
                Geometry geometry = ascGeo;
                if (Retning == ListSortDirection.Descending)
                {
                    geometry = descGeo;
                }
                drawContext.DrawGeometry(Brushes.Black, null, geometry);
                drawContext.Pop();
            }
        }
        #endregion

        #region ListView danner

        private void danneListe()
        {
            if(_bogView == null)
            {
                konfigurereListe();
            }

            // Fjerner indhold i Grid, for skab og opdatere listen
            Indhold.Children.Clear();

            // Tjekker på filter udvalgt

            switch (SøgType)
            {
                case AktivType.Bog:
                    Indhold.Children.Add(_bogView);
                    break;
                case AktivType.Brætspil:
                    Indhold.Children.Add(_brætspilView);
                    break;
                case AktivType.Udstyr:
                    Indhold.Children.Add(_udstyrView);
                    break;
                case AktivType.Lokale:
                    Indhold.Children.Add(_lokaleView);
                    break;
                default:
                    Indhold.Children.Add(_bogView);
                    break;
            }
            
        }

        private void konfigurereListe()
        {
            // Instantiere ListView objekt
            _bogView = new ListView();
            _brætspilView = new ListView();
            _udstyrView = new ListView();
            _lokaleView = new ListView();

            // Kofigurerer ListView
            instillKonfig(ref _bogView);
            instillKonfig(ref _brætspilView);
            instillKonfig(ref _udstyrView);
            instillKonfig(ref _lokaleView);

            // Indsæt koloner
            bygBogListe(ref _bogView);
            bygBrætspilListe(ref _brætspilView);
            bygUdstyrListe(ref _udstyrView);
            bygLokaleListe(ref _lokaleView);
        }

        private void instillKonfig(ref ListView liste)
        {
            // Position 
            liste.HorizontalAlignment = HorizontalAlignment.Stretch;
            liste.VerticalAlignment = VerticalAlignment.Stretch;
            liste.SelectionMode = SelectionMode.Single;
            //liste.Margin = new Thickness(60, 230, 60, 0);
            //liste.Width = double.NaN;
            //liste.Height = double.NaN;

            // ListView event
            liste.SelectionChanged += AktivListeUdvalgt_SelectionChanged;

            // Manuelle sætter dobbelt klik event til ListViewItem(er)
            EventSetter doubleclickEvent = new EventSetter(ListViewItem.MouseDoubleClickEvent, new MouseButtonEventHandler(AktivListe_DoubleClick));
            EventSetter enterEvent = new EventSetter(ListViewItem.KeyDownEvent, new KeyEventHandler(AktivListe_Enter));

            Style style = new Style();
            style.Setters.Add(doubleclickEvent);
            style.Setters.Add(enterEvent);
            liste.ItemContainerStyle = style;
        }

        private void bygBogListe(ref ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Titel", null, 350));
            view.Columns.Add(bygColumn("Familie", null, 180));

            liste.View = view;
        }

        private void bygBrætspilListe(ref ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "BrætspilsNavn", 220));
            view.Columns.Add(bygColumn("Kategori", null, 180));

            liste.View = view;
        }

        private void bygUdstyrListe(ref ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "UdstyrsNavn", 220));
            view.Columns.Add(bygColumn("Kategori", null, 180));

            liste.View = view;
        }

        private void bygLokaleListe(ref ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "LokaleNavn", 220));
            view.Columns.Add(bygColumn("Adresse", "Lokation", 180));

            liste.View = view;
        }

        private GridViewColumn bygColumn(string name, string bind = null, double width = 0)
        {
            if (bind == null)
            {
                bind = name;
            }
            GridViewColumn col = new GridViewColumn { DisplayMemberBinding = new Binding(bind) };
            if (width != 0)
            {
                col.Width = width;
            }
            else
            {
                col.Width = 50;
            }

            GridViewColumnHeader head = new GridViewColumnHeader();
            head.Tag = bind;
            head.Content = name;
            head.Click += Sortering_Click;

            col.Header = head;

            return col;
        }

        #endregion
    }
}
