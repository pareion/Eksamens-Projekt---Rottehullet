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
    /// Interaction logic for ReservationListe.xaml
    /// </summary>
    public partial class ReservationListe : Window
    {
        public ListView AktivListe { get; set; }
        public List<object> DataListe { get; private set; }
        public bool IsClosed { get; private set; }

        public BrugerPanel.AktivType ReservationType { get; private set; }
        public int AntalAktiver
        {
            get
            {
                if (AktivListe == null)
                {
                    return 0;
                }
                else
                {
                    return AktivListe.Items.Count;
                }
            }
        }

        protected string aktivNavn
        {
            get
            {
                return Enum.GetName(typeof(BrugerPanel.AktivType), ReservationType);
            }
        }

        private DateTime hentAfleveringDato
        {
            get
            {
                DateTime date;

                switch (ReservationType)
                {
                    case BrugerPanel.AktivType.Bog:
                        date = DateTime.Now.AddMonths(3);
                        break;
                    case BrugerPanel.AktivType.Brætspil:
                        date = DateTime.Now.AddMonths(1);
                        break;
                    case BrugerPanel.AktivType.Udstyr:
                        date = DateTime.Now.AddMonths(1);
                        break;
                    case BrugerPanel.AktivType.Lokale:
                        date = DateTime.Now.AddDays(1);
                        break;
                    default:
                        date = DateTime.Now.AddMonths(1);
                        break;
                }
                return date;
            }
        }
        

        public ReservationListe(BrugerPanel.AktivType aktivType)
        {
            InitializeComponent();
            DataListe = new List<object>();
            ReservationType = aktivType;
            Title = string.Format(Title, aktivNavn.ToLower());
            danneListe();
        }

        public void Tilføj(object data)
        {
            if (data is ListViewItem)
            {
                ListViewItem item = data as ListViewItem;
                data = item.DataContext;
            }
            if(data.GetType().Name == aktivNavn)
            {
                tilføjAktiv(data);
            }
        }

        public void FjernAlle()
        {
            if (AktivListe != null)
            {
                DataListe.Clear();
                AktivListe.Items.Clear();
            }
        }

        public void Fjern(int indeks)
        {
            if (AktivListe != null)
            {
                try
                {
                    DataListe.RemoveAt(indeks);
                    AktivListe.Items.RemoveAt(indeks);
                }
                catch
                {
                    
                }
            }
        }

        private void tilføjAktiv(object aktiv)
        {
            if (AktivListe != null)
            {
                if (DataListe.Any(x => x == aktiv) == false)
                {
                    DataListe.Add(aktiv);
                    AktivListe.Items.Add(aktiv);
                }
                else
                {
                    MessageBox.Show("Har allerede tilføjet");
                }
            }
        }

        private void lukReservation()
        {
            this.IsClosed = true;
            BrugerPanel hovedside = this.Owner as BrugerPanel;
            hovedside.FjernReservation();
        }

        #region Event Listener

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DataListe.Count != 0)
            {
                e.Cancel = true;
                this.Owner.Activate();
                this.Hide();
            }
            else
            {
                base.OnClosing(e);
                lukReservation();
            }
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            if (DataListe.Count != 0)
            {
                this.Hide();
                this.Owner.Activate();
            }
            else
            {
                lukReservation();
                this.Close();
            }
        }

        private int omdanneAktivType()
        {
            int resultat = 0;
            switch (ReservationType)
            {
                case BrugerPanel.AktivType.Bog:
                    resultat = 1;
                    break;
                case BrugerPanel.AktivType.Brætspil:
                    resultat = 2;
                    break;
                case BrugerPanel.AktivType.Udstyr:
                    resultat = 0;
                    break;
                case BrugerPanel.AktivType.Lokale:
                    resultat = 3;
                    break;
                default:
                    break;
            }
            return resultat;
        }

        #endregion

        #region Event

        private void Reservere_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> IDer = new List<int>();
                foreach (object item in DataListe)
                {
                    IDer.Add((int)item.GetType().GetProperty("Id").GetValue(item));
                }

                string resultat = UIFacade.HentUIFacade().HentUdlåningsFacade().ReserverAktiv(
                    DateTime.Now,
                    hentAfleveringDato,
                    omdanneAktivType(),
                    IDer
                );
                if (resultat == "Udlån er skabt")
                {
                    MessageBox.Show(string.Format("{0} reservation er fuldført", aktivNavn));
                    FjernAlle();

                    lukReservation();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Fejl, kunne ikke opret reservation");
                }
            }
            catch
            {
                MessageBox.Show("Fejl, kunne ikke opret reservation");
            }
        }
        private void Fjern_Click(object sender, RoutedEventArgs e)
        {
            Fjern(AktivListe.SelectedIndex);
        }

        private void SletAlle_Click(object sender, RoutedEventArgs e)
        {
            FjernAlle();
        }
        private void AktivListeUdvalgt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (btn_Fjern.IsEnabled == false)
            {
                btn_Fjern.IsEnabled = true;
            }
        }

        #endregion

        #region ListView

        private void danneListe()
        {
            konfigurereListe();
            Indhold.Children.Add(AktivListe);
        }

        private void konfigurereListe()
        {
            // Instantiere ListView objekt
            if (AktivListe == null)
            {
                AktivListe = new ListView();
            }

            //// Position 
            //AktivListe.HorizontalAlignment = HorizontalAlignment.Stretch;
            //AktivListe.VerticalAlignment = VerticalAlignment.Stretch;
            //AktivListe.Margin = new Thickness(10, 50, 10, 10);

            AktivListe.SelectionChanged += AktivListeUdvalgt_SelectionChanged;

            switch (ReservationType)
            {
                case BrugerPanel.AktivType.Bog:
                    bygBogListe();
                    break;
                case BrugerPanel.AktivType.Brætspil:
                    bygBrætspilListe();
                    break;
                case BrugerPanel.AktivType.Udstyr:
                    bygUdstyrListe();
                    break;
                case BrugerPanel.AktivType.Lokale:
                    bygLokaleListe();
                    break;
                default:
                    break;
            }
        }

        private void bygBogListe()
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Titel", null, 220));
            view.Columns.Add(bygColumn("Familie", null, 150));

            AktivListe.View = view;
        }

        private void bygBrætspilListe()
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "BrætspilsNavn", 220));
            view.Columns.Add(bygColumn("Kategori", null, 150));

            AktivListe.View = view;
        }

        private void bygUdstyrListe()
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "UdstyrsNavn", 220));
            view.Columns.Add(bygColumn("Kategori", null, 150));

            AktivListe.View = view;
        }

        private void bygLokaleListe()
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Navn", "LokaleNavn", 150));
            view.Columns.Add(bygColumn("Adresse", "Lokation", 220));

            AktivListe.View = view;
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
