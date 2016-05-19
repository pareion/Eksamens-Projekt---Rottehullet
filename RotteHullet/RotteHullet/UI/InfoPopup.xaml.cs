using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for InfoPopup.xaml
    /// </summary>
    public partial class InfoPopup : Window
    {
        public enum InfoType { Bog, Brætspil, Udstyr, Lokale }
        public InfoType InfoTilstand { get; set; }

        protected bool ErAktiveret = false;

        public InfoPopup(InfoType type, object data = null)
        {
            InitializeComponent();

            if(type == InfoType.Bog)
            {
                this.Height = 700;
                this.MinHeight = 700;
            }

            InfoTilstand = type;
            hentControlVidue(data);
        }

        private void hentControlVidue(object data)
        {
            switch (InfoTilstand)
            {
                case InfoType.Bog:
                    this.Title = "Bog info";
                    this.Content = new BogInfo(data);
                    break;
                case InfoType.Brætspil:
                    this.Title = "Brætspil info";
                    this.Content = new BrætspilInfo(data);
                    break;
                case InfoType.Udstyr:
                    this.Title = "Udstyr info";
                    this.Content = new UdstyrInfo(data);
                    break;
                case InfoType.Lokale:
                    this.Title = "Lokale info";
                    this.Content = new LokaleInfo(data);
                    break;
                default:
                    this.Title = "Fejl meddelse";
                    this.Content = new FejlInfo();
                    break;
            }
        }

        #region Event Listener

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Owner.Activate();
            base.OnClosing(e);
        }

        #endregion
    }
}
