using RotteHullet.Domain.BusinessLogic;
using RotteHullet.Værktøjs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHullet.Domain
{
    class VærktøjsFacade
    {
        private static VærktøjsFacade _værktøjsFacade;

        public static VærktøjsFacade HentVærktøjsFacade()
        {
            if (_værktøjsFacade == null)
            {
                _værktøjsFacade = new VærktøjsFacade();
            }
            return _værktøjsFacade;
        }

        //Søg Alt - Bruges ikke
        public bool Søg(bool bøger, bool lokaler, bool brætspil, bool udstyr, string søgning, out List<Bog> bogResult, out List<Lokale> lokaleResult, out List<Brætspil> brætspilResult, out List<Udstyr> udstyrResult)
        {
            return Søgning.HentSøgning().Søg(bøger, lokaler, brætspil, udstyr, søgning, out bogResult, out lokaleResult, out brætspilResult, out udstyrResult);
        }

        //Søg Lokale
        public bool Søg(string søgord, out List<Lokale> lokaler)
        {
            return Søgning.HentSøgning().Søg(søgord,out lokaler);
        }

        //Søg Bøger
        public bool Søg(string søgord, out List<Bog> bøger)
        {
            return Søgning.HentSøgning().Søg(søgord, out bøger);
        }

        //Søg Udstyr
        public bool Søg(string søgord, out List<Udstyr> udstyr)
        {
            return Søgning.HentSøgning().Søg(søgord, out udstyr);
        }

        //Søg Brætspil
        public bool Søg(string søgord, out List<Brætspil> brætspil)
        {
            return Søgning.HentSøgning().Søg(søgord, out brætspil);
        }
    }
}
