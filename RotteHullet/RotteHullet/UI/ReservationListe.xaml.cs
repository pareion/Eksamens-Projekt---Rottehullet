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

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for ReservationListe.xaml
    /// </summary>
    public partial class ReservationListe : Window
    {
        private ListView _bogView, _brætspilView, _udstyrView, _lokaleView;

        public ReservationListe()
        {
            InitializeComponent();
        }

        private void danneListe()
        {
            _bogView = new ListView();
            
        }

        private void konfigurereListe(ref ListView liste)
        {
            // Instantiere ListView objekt
            if (liste == null)
            {
                liste = new ListView();
            }

            // Position 
            liste.HorizontalAlignment = HorizontalAlignment.Stretch;
            liste.VerticalAlignment = VerticalAlignment.Stretch;
            liste.Margin = new Thickness(10, 50, 10, 10);
            liste.Width = double.NaN;
            liste.Height = double.NaN;


        }

        #region Klik event
        private void Reservere_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Fjern_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SletAlle_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
