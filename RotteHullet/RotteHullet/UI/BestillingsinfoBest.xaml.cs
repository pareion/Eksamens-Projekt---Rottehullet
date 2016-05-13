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

namespace RotteHullet.UI
{
    /// <summary>
    /// Interaction logic for BestillingsinfoBest.xaml
    /// </summary>
    public partial class BestillingsinfoBest : Window
    {

        public enum Udlånstype {Bog, Brætspil, Udstyr, Lokale }
        public Udlånstype Udlånstilstand { get; set; }
        object denne;
        public BestillingsinfoBest( Udlånstype udl, object data)
        {
            InitializeComponent();

            Udlånstilstand = udl;
            udfyldVindue(data);
            denne = data;
        }


        void udfyldVindue(object data) {

            lv_Reservationer.Items.Add(data);
            var a = data.GetType().GetProperty("Aktiver").GetValue(data);
            foreach (var item in (List<object>)data.GetType().GetProperty("Aktiver").GetValue(data))
            {
                Console.WriteLine("lol");
            }
            /*
            switch (data.GetType().Name)
            {
                case "Bog":
                    
                    break;
                case "Brætspil":
                    break;
                case "Udstyr":
                    break;
                case "Lokale":
                    break;
                default:
                    break;
            }*/
        }

    }
}
