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
using System.Reflection;

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for BogInfo.xaml
    /// </summary>
    public partial class BogInfo : UserControl
    {
        public object AktivInfo { get; set; }

        private Window hovedSide
        {
            get { return Window.GetWindow(this); }
        }

        public BogInfo(object data)
        {
            InitializeComponent();
            AktivInfo = data;
            indlæsData();
        }

        private void indlæsData()
        {
            tb_Titel.Text = aktivLæser((string)tb_Titel.Tag);
            tb_Forfatter.Text = aktivLæser((string)tb_Forfatter.Tag);
            tb_Forlag.Text = aktivLæser((string)tb_Forlag.Tag);
            tb_Kategori.Text = aktivLæser((string)tb_Kategori.Tag);
            tb_Familie.Text = aktivLæser((string)tb_Familie.Tag);
            tb_Status.Text = aktivLæser((string)tb_Status.Tag);
            tb_Kommentar.Text = aktivLæser((string)tb_Kommentar.Tag);
        }

        private string aktivLæser(string egenskabNavn)
        {
            if(egenskabNavn == "Udlånes")
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
