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

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for LokaleInfo.xaml
    /// </summary>
    public partial class LokaleInfo : UserControl
    {
        public object AktivInfo { get; set; }

        public LokaleInfo(object data)
        {
            InitializeComponent();
            AktivInfo = data;
        }
    }
}
