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
    /// Interaction logic for OpretÆndreAktiv.xaml
    /// </summary>
    public partial class OpretÆndreAktiv : Window
    {
        public OpretÆndreAktiv()
        {
            InitializeComponent();
        }

        private void AktivType_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            List<string> data = new List<string>();
            data.Add("Bog");
            data.Add("Brætspil");
            data.Add("Udstyr");
            data.Add("Lokale");

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        private void Valgt_AktivType(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            this.Title = "Opret: " + value;
        }

    }
}
