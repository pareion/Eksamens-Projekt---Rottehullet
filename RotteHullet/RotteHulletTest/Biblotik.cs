using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Domain;
using RotteHullet.Domain.BusinessLogic;

namespace RotteHulletTest
{
    static class Biblotik
    {
        public static List<Bog> Bøger
        {
            get
            {
                return new List<Bog>
                {
                    new Bog(1, "Hello world", "World", "Action", "RPG", "Code", "Unknow", true, "Det her er kommentar"),
                    new Bog(2, "Hello system", "System", "Action", "RPG", "Code", "Unknow", true, "Det her er kommentar"),
                    new Bog(3, "Hello galaxy", "Galaxy", "Fantasi", "Prøv", "Test", "Tester", true, "Det her er kommentar"),
                    new Bog(4, "Hello universe", "Universe", "Gyser", "Prøv", "Test", "Tester", true, "Det her er kommentar")
                };
            }
        }

        public static List<Brætspil> Brætspils
        {
            get
            {
                return new List<Brætspil>
                {
                    new Brætspil(1, "Test spil 1", "Test Facility", true, "ingen", "Test1"),
                    new Brætspil(2, "Test spil 2", "Test Facility", true, "ingen", "Test2"),
                    new Brætspil(3, "Test spil 3", "Test Data", true, "ingen", "Test3"),
                    new Brætspil(4, "Test spil 4", "Test Data", true, "ingen", "Test4")
                };
            }
        }

        public static List<Udstyr> Udstyrs
        {
            get
            {
                return new List<Udstyr>
                {
                    new Udstyr(1, "Udstyr 1", "Tøj", true, "ingen", false),
                    new Udstyr(1, "Udstyr 2", "Spyd", true, "ingen", false),
                    new Udstyr(1, "Udstyr 3", "Sværd", true, "ingen", false),
                    new Udstyr(1, "Udstyr 4", "Bukser", true, "ingen", false)
                };
            }
        }
        public static List<Lokale> Lokaler
        {
            get
            {
                return new List<Lokale>
                {
                    new Lokale(1, "Blå rum", "Studenterhus", true, "ingen", "1 Sofa, 2 bord"),
                    new Lokale(2, "Rød rum", "Studenterhus", true, "ingen", "1 Sofa, 2 bord, 10 Stoler")
                };
            }
        }

        public static List<Medlem> Medlemer
        {
            get
            {
                return new List<Medlem>
                {
                    new Medlem(1, "Admin", "Adminsen", "admin", "admin", "admin@rottehullet.dk", Medlem.MedlemType.Bestyrelse),
                    new Medlem(2, "Medlem", "Medlemsen", "medlem", "medlem", "medlem@rottehullet.dk", Medlem.MedlemType.Bruger)
                };
            }
        }
    }
}
