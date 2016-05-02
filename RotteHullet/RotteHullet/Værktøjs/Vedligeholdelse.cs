using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RotteHullet.Værktøjs
{
    class Vedligeholdelse
    {
        private List<Thread> nuværendeTråde = new List<Thread>();

        public Vedligeholdelse()
        {
            nuværendeTråde = new List<Thread>();
        }
        public void start()
        {
            Thread a = new Thread(opdaterListerne);
            a.Start();
        }
        private void opdaterListerne()
        {
            while (true)
            {
                


                Thread.Sleep(10000);
            }
        }

    }
}
