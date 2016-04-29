using RotteHullet.Domain.BusinessLogic;
using RotteHullet.Værktøjs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain
{
    class SøgningsFacade
    {
        private static SøgningsFacade _søgningsFacade;

        public static SøgningsFacade GetSøgningsFacade()
        {
            if (_søgningsFacade == null)
            {
                _søgningsFacade = new SøgningsFacade();
            }
            return _søgningsFacade;
        }
        public bool Søg(bool bøger, bool lokaler, bool brætspil, bool udstyr, string søgning, out List<Bog> bogResult, out List<Lokale> lokaleResult, out List<Brætspil> brætspilResult, out List<Udstyr> udstyrResult)
        {
            return Søgning.GetSøgning().Søg(bøger, lokaler, brætspil, udstyr, søgning, out bogResult, out lokaleResult, out brætspilResult, out udstyrResult);
        }
        public bool Søg(string søgord, out List<Lokale> lokaler)
        {
            return Søgning.GetSøgning().Søg(søgord,out lokaler);
        }
        public bool Søg(string søgord, out List<Bog> bøger)
        {
            return Søgning.GetSøgning().Søg(søgord, out bøger);
        }
        public bool Søg(string søgord, out List<Udstyr> udstyr)
        {
            return Søgning.GetSøgning().Søg(søgord, out udstyr);
        }
        public bool Søg(string søgord, out List<Brætspil> brætspil)
        {
            return Søgning.GetSøgning().Søg(søgord, out brætspil);
        }
    }
}
