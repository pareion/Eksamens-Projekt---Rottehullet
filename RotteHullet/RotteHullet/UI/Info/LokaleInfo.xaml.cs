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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RotteHullet.UI
{
    /// <summary>
    /// Interaction logic for LokaleInfo.xaml
    /// </summary>
    public partial class LokaleInfo : UserControl
    {
        public object AktivInfo { get; set; }

        private Window hovedSide
        {
            get { return Window.GetWindow(this); }
        }

        public LokaleInfo(object data)
        {
            InitializeComponent();
            AktivInfo = data;
            indlæsData();
        }

        private void indlæsData()
        {
            tb_LokaleNavn.Text = aktivLæser((string)tb_LokaleNavn.Tag);
            tb_Lokation.Text = aktivLæser((string)tb_Lokation.Tag);
            tb_Møbler.Text = aktivLæser((string)tb_Møbler.Tag);
            tb_Status.Text = aktivLæser((string)tb_Status.Tag);
            tb_Kommentar.Text = aktivLæser((string)tb_Kommentar.Tag);
        }

        private string aktivLæser(string egenskabNavn)
        {
            if (egenskabNavn == "Udlånes")
            {
                bool tilladelse = (bool)AktivInfo.GetType().GetProperty(egenskabNavn).GetValue(AktivInfo);
                if (tilladelse)
                {
                    tb_Status.Foreground = new SolidColorBrush(Color.FromRgb(43, 200, 0));
                    return "Tilgængelig";
                }
                else
                {
                    btn_Kurv.IsEnabled = false;
                    tb_Status.Foreground = new SolidColorBrush(Color.FromRgb(200, 44, 44));
                    return "Ikke til udlån";
                }
            }
            else
            {
                string tekst = (string)AktivInfo.GetType().GetProperty(egenskabNavn).GetValue(AktivInfo, null);

                return tekst != null && tekst != "" ? tekst : "Ingen " + egenskabNavn.ToLower();
            }
        }

        #region Event

        private void HoverEffekt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                StackPanel panel = sender as StackPanel;
                StackPanel childPanel = panel.Children[1] as StackPanel;
                TextBox boks = childPanel.Children[0] as TextBox;
                boks.Foreground = new SolidColorBrush(Color.FromRgb(33, 88, 255));
            }
            catch
            {

            }
        }

        private void HoverEffekt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                StackPanel panel = sender as StackPanel;
                StackPanel childPanel = panel.Children[1] as StackPanel;
                TextBox boks = childPanel.Children[0] as TextBox;
                boks.Foreground = new SolidColorBrush(Color.FromRgb(55, 55, 55));
            }
            catch
            {

            }
        }

        private void TilføjAktiv_Click(object sender, RoutedEventArgs e)
        {
            BrugerPanel liste = hovedSide.Owner as BrugerPanel;
            liste.ReservereAktiv(AktivInfo);
            hovedSide.Close();
        }

        private void Annullere_Click(object sender, RoutedEventArgs e)
        {
            hovedSide.Close();
        }

        #endregion
    }
}
