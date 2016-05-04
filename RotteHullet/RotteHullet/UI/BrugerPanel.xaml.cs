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
    /// Interaction logic for BrugerPanel.xaml
    /// </summary>
    public partial class BrugerPanel : Window
    {
        private ListView _bogView, _brætspilView, _udstyrView, _lokaleView;
        private enum AktivType { Bog, Brætspil, Udstyr, Lokale }

        public BrugerPanel()
        {
            InitializeComponent();
            
        }

        #region ListView danner
        private void danneListe()
        {
            
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
            liste.Width = double.NaN;
            liste.Height = double.NaN;

            GridView view = new GridView();
            
            liste.View = view;
        }

        private void bygBogListe(ListView liste)
        {
            GridView view = new GridView();
            view.Columns.Add(bygColumn("Titel"));
            view.Columns.Add(bygColumn("Forfatter"));
            view.Columns.Add(bygColumn("Genre"));
            view.Columns.Add(bygColumn("Subkategori"));
        }

        private GridViewColumn bygColumn(string header, string bind = null)
        {
            return new GridViewColumn { Header = header, DisplayMemberBinding = new Binding(bind == null ? header : bind) };
        }

        #endregion
    }
}
