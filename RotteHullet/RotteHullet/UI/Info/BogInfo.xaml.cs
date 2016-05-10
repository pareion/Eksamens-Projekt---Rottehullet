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
                    return "Tilgængelig";
                }
                else
                {
                    return "Ikke til udlån";
                }
            }
            else
            {
                string tekst = (string)AktivInfo.GetType().GetProperty(egenskabNavn).GetValue(AktivInfo, null);

                return tekst != null && tekst != "" ? tekst : "Ingen " + egenskabNavn.ToLower();
            }
        }
    }
}
