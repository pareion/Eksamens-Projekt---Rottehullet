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

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for BrugerPanel.xaml
    /// </summary>
    public partial class BrugerPanel : Window
    {
        private ListView _bogView, _brætspilView, _udstyrView, _lokaleView;
        private enum AktivType { Bog, Brætspil, Udstyr, Lokale }


        private GridViewColumnHeader listeSortCol = null;


        private ReservationListe reservation = null;
        

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
            lv_Aktiver.Items.Add(new Test { Titel = "Hello world", Forfatter = "Programmer", Genre = "Code", Subkategori = "Amature" });
            lv_Aktiver.Items.Add(new Test { Titel = "The tiny Earth", Forfatter = "Unknow", Genre = "General", Subkategori = "Experienced" });
            lv_Aktiver.Items.Add(new Test { Titel = "Universe War", Forfatter = "X person", Genre = "Strategy", Subkategori = "Expert" });
            lv_Aktiver.Items.Add(new Test { Titel = "Information Research", Forfatter = "Matter", Genre = "Sci-fi", Subkategori = "Master" });
        }

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
            lv_Aktiver.Items.SortDescriptions.Add(new SortDescription(sortOrd, dir));
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

        private void konfigurereListe(ref ListView liste, AktivType type)
        {
            // Instantiere ListView objekt
            if (liste == null)
            {
                liste = new ListView();
            }

            // Position 
            liste.HorizontalAlignment = HorizontalAlignment.Stretch;
            liste.VerticalAlignment = VerticalAlignment.Top;
            liste.Margin = new Thickness(60, 230, 60, 0);
            //liste.Width = double.NaN;
            //liste.Height = double.NaN;

            GridView view = new GridView();
            
            liste.View = view;
        }

        private void bygBogListe(ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Titel", null, 220));
            view.Columns.Add(bygColumn("Familie", null, 180));
            view.Columns.Add(bygColumn("Status", null, 180));

        }

        private void bygBrætspilListe(ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "BrætspilsNavn", 220));
            view.Columns.Add(bygColumn("Kategori", null, 180));
            view.Columns.Add(bygColumn("Status", null, 180));
        }

        private void bygUdstyrListe(ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "UdstyrsNavn", 220));
            view.Columns.Add(bygColumn("Kategori", null, 180));
            view.Columns.Add(bygColumn("Status", null, 180));
        }

        private void bygLokaleListe(ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "LokaleNavn", 220));
            view.Columns.Add(bygColumn("Adresse", "Lokation", 180));
            view.Columns.Add(bygColumn("Status", null, 180));
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
