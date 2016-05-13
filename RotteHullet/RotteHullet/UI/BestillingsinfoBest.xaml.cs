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

namespace RotteHullet.UI
{
    /// <summary>
    /// Interaction logic for BestillingsinfoBest.xaml
    /// </summary>
    public partial class BestillingsinfoBest : Window
    {

        public enum Udlånstype {Bog, Brætspil, Udstyr, Lokale }
        public Udlånstype Udlånstilstand { get; set; }
        object denne;
        public BestillingsinfoBest( Udlånstype udl, object data)
        {
            InitializeComponent();

            Udlånstilstand = udl;
            udfyldVindue(data);
            denne = data;
        }


        void udfyldVindue(object data)
        {
            // Forventer syntax fejl
            // Instatiate data
            List<object> aktiv = data.GetType().GetProperty("AktiverData").GetValue(data) as List<object>;

            string aktivType = aktiv[0].GetType().Name;

            object medlem = data.GetType().GetProperty("Medlem").GetValue(data);
            string fornavn = (string)medlem.GetType().GetProperty("Fornavn").GetValue(medlem);
            string efternavn = (string)medlem.GetType().GetProperty("Efternavn").GetValue(medlem);

            tb_Navn.Text = fornavn + " " + efternavn;
            tb_Type.Text = aktivType;

            aktiv.ForEach(x => omdanneAktiv(x));
        }

        private void omdanneAktiv(object data)
        {
            object aktiv = new { };
            switch (data.GetType().Name)
            {
                case "Bog":
                    aktiv = new { Navn = hentEgenskab<string>("Titel", data), Kommentar = hentEgenskab<string>("Kommentar", data) };
                    break;
                case "Brætspil":
                    aktiv = new { Navn = hentEgenskab<string>("BrætspilsNavn", data), Kommentar = hentEgenskab<string>("Kommentar", data) };
                    break;
                case "Udstyr":
                    aktiv = new { Navn = hentEgenskab<string>("UdstyrsNavn", data), Kommentar = hentEgenskab<string>("Kommentar", data) };
                    break;
                case "Lokale":
                    aktiv = new { Navn = hentEgenskab<string>("LokaleNavn", data), Kommentar = hentEgenskab<string>("Kommentar", data) };
                    break;
            }
            lv_Reservationer.Items.Add(aktiv);
        }

        private T hentEgenskab<T>(string egenskab, object data)
        {
            return (T)data.GetType().GetProperty(egenskab).GetValue(data);
        }

        private void acceptere_Click(object sender, RoutedEventArgs e)
        {

        }

        private void afvis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tillbage_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Activate();
            this.Close();
        }
    }
}
