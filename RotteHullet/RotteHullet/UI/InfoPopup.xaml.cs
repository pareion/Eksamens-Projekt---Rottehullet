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
    /// Interaction logic for InfoPopup.xaml
    /// </summary>
    public partial class InfoPopup : Window
    {
        public enum InfoType { Bog, Brætspil, Udstyr, Lokale }
        public InfoType InfoTilstand { get; set; }

        public InfoPopup(InfoType type, object data = null)
        {
            InitializeComponent();

            InfoTilstand = type;
            hentControlVidue(data);
        }

        private void hentControlVidue(object data)
        {
            switch (InfoTilstand)
            {
                case InfoType.Bog:
                    this.Content = new BogInfo(data);
                    break;
                case InfoType.Brætspil:
                    this.Content = new BogInfo(data);
                    break;
                case InfoType.Udstyr:
                    this.Content = new BogInfo(data);
                    break;
                case InfoType.Lokale:
                    this.Content = new BogInfo(data);
                    break;
                default:
                    this.Content = new FejlInfo();
                    break;
            }
        }
    }
}
