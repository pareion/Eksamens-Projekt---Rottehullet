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
        private int _selectionID;
        
    

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void lv_lokal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void lv_udstyr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lv_brætspil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lv_bøger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void opret_Click(object sender, RoutedEventArgs e)
        {
            OpretÆndreAktiv opret = new OpretÆndreAktiv();
            opret.Show();
            opret.SætTabAktiv(adminTab.SelectedIndex);
        }
    }
}
