using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RotteHullet.UI
{
    class Navigator
    {
        public static Window HovedVindue { get; set; }
        private UserControl nuværende { get; set; }
        private UserControl tidligere { get; set; }

        public void Skift(UserControl kontrol)
        {
            if (HovedVindue != null)
            {
                if (nuværende == null)
                {
                    HovedVindue.Content = kontrol;
                    nuværende = kontrol;
                }
                else
                {
                    HovedVindue.Content = kontrol;
                    tidligere = nuværende;
                    nuværende = kontrol;
                }
            }
            else
            {
                throw new Exception("Mangler Hovedvindue");
            }
        }

        public void Tilbage()
        {
            if (HovedVindue != null)
            {
                if(tidligere != null)
                {
                    UserControl middletid = nuværende;
                    HovedVindue.Content = tidligere;
                    nuværende = tidligere;
                    tidligere = middletid;
                }
            }
            else
            {
                throw new Exception("Mangler Hovedvindue");
            }
        }


    }
}
