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

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for BrugerPanel.xaml
    /// </summary>
    public partial class BrugerPanel : Window
    {
        private ListView _bogView, _brætspilView, _udstyrView, _lokaleView;
        public enum AktivType { Bog, Brætspil, Udstyr, Lokale }

        private GridViewColumnHeader listeSortCol = null;
        private ReservationListe reservation = null;

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
        

        private class Test
        {
            public string Titel { get; set; }
            public string Forfatter { get; set; }
            public string Genre { get; set; }
            public string Subkategori { get; set; }
        }

        public BrugerPanel()
        {
            InitializeComponent();
            
            //lv_Aktiver.Items.Add(new Test { Titel = "Hello world", Forfatter = "Programmer", Genre = "Code", Subkategori = "Amature" });
            //lv_Aktiver.Items.Add(new Test { Titel = "The tiny Earth", Forfatter = "Unknow", Genre = "General", Subkategori = "Experienced" });
            //lv_Aktiver.Items.Add(new Test { Titel = "Universe War", Forfatter = "X person", Genre = "Strategy", Subkategori = "Expert" });
            //lv_Aktiver.Items.Add(new Test { Titel = "Information Research", Forfatter = "Matter", Genre = "Sci-fi", Subkategori = "Master" });
        }

        #region Event

        private void Søgning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                aktivSøgning();
            }
        }

        private void Søgning_MouseUp(object sender, MouseButtonEventArgs e)
        {
            aktivSøgning();
        }

        #endregion

        #region Funktioner

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
                    break;
                case AktivType.Udstyr:
                    ResultatVisning(ref _udstyrView, UIFacade.HentUIFacade().HentUdstyrFacade().FindAlleUdstyr(tb_Søgboks.Text));
                    break;
                case AktivType.Lokale:
                    ResultatVisning(ref _lokaleView, UIFacade.HentUIFacade().HentLokaleFacade().FindAlleLokaler(tb_Søgboks.Text));
                    break;
                default:
                    break;
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
            GridViewColumnHeader column = sender as GridViewColumnHeader;
            

            //Console.WriteLine(dock.Parent.GetType().Name);

            //Console.WriteLine(column.Parent.GetType().Name);

            string sortOrd = column.Tag.ToString();

            ListSortDirection dir = ListSortDirection.Ascending;
            if (listeSortCol == column)
            {
                dir = ListSortDirection.Descending;
            }

            listeSortCol = column;
            //lv_Aktiver.Items.SortDescriptions.Add(new SortDescription(sortOrd, dir));
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

        private void VisReservation_Click(object sender, RoutedEventArgs e)
        {
            if (reservation == null)
            {
                reservation = new ReservationListe();
                reservation.Owner = this;
                reservation.ShowDialog();
            }
            else
            {
                reservation.Visibility = Visibility.Visible;
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
            //liste.Margin = new Thickness(60, 230, 60, 0);
            //liste.Width = double.NaN;
            //liste.Height = double.NaN;

            Style style = new Style();
            EventSetter setter = new EventSetter();
            
            
        }

        private void ListViewItem_DoubleClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void bygBogListe(ref ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Titel", null, 220));
            view.Columns.Add(bygColumn("Familie", null, 180));
            view.Columns.Add(bygColumn("Status", null, 180));

            liste.View = view;
        }

        private void bygBrætspilListe(ref ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "BrætspilsNavn", 220));
            view.Columns.Add(bygColumn("Kategori", null, 180));
            view.Columns.Add(bygColumn("Status", null, 180));

            liste.View = view;
        }

        private void bygUdstyrListe(ref ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "UdstyrsNavn", 220));
            view.Columns.Add(bygColumn("Kategori", null, 180));
            view.Columns.Add(bygColumn("Status", null, 180));

            liste.View = view;
        }

        private void bygLokaleListe(ref ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "LokaleNavn", 220));
            view.Columns.Add(bygColumn("Adresse", "Lokation", 180));
            view.Columns.Add(bygColumn("Status", null, 180));

            liste.View = view;
        }

        private GridViewColumn bygColumn(string header, string bind = null, double width = 0)
        {
            GridViewColumn col = new GridViewColumn { Header = header, DisplayMemberBinding = new Binding(bind == null ? header : bind) };
            
            if (width != 0)
            {
                col.Width = width;
            }
            else
            {
                col.Width = 50;
            }
            return col;
        }

        #endregion
    }
}
