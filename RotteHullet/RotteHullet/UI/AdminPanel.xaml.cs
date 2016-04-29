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
using RotteHullet.Data;
using RotteHullet.Domain.BusinessLogic;

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private int _selectionID;

        private List<Bog> _bogListe = new List<Bog>(); 
    

        public AdminPanel()
        {
            InitializeComponent();
            indlæsData();
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

        private void indlæsData()
        {
            Bog bog1 = new Bog(1, "hello", "world", "action", "rpg", "app", "Nothing");
            Bog bog2 = new Bog(2, "hello2", "world2", "action", "rpg", "app", "Nothing");
            Bog bog3 = new Bog(3, "hello3", "world3", "action", "rpg", "app", "Nothing");

            lv_bøger.Items.Add(bog1);
            lv_bøger.Items.Add(bog2);
            lv_bøger.Items.Add(bog3);
        }

        private void opret_Click(object sender, RoutedEventArgs e)
        {
            OpretÆndreAktiv opret = new OpretÆndreAktiv(adminTab.SelectedIndex);
            opret.Show();
        }
    }
}
