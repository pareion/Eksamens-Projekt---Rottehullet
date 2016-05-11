using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RotteHullet.Domain.BusinessLogic;
using System.Data;

namespace RotteHullet.Data
{
    class DBSQLFacade : IDBFacade
    {
        //Disse glemmer vi lidt at bruge... PLease advice JA
        private static DBSQLFacade _dbsqlfacade;
        public static IDBFacade HentDBSQLFacade()
        {
            if (_dbsqlfacade == null)
            {
                _dbsqlfacade = new DBSQLFacade();
            }
            return _dbsqlfacade;
        }

        #region forbindelse
        private SqlConnection hentForbindelse()
        {
            SqlConnection forb = new SqlConnection("Server=ealdb1.eal.local;Database=ejl52_db; User ID = ejl52_usr; Password = Baz1nga52");
            forb.Open();
            return forb;
        }
        #endregion
        #region Bog
        public bool GemBog(Bog bog)
        {
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("GemBog", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@titel", bog.Titel));
                kommando.Parameters.Add(new SqlParameter("@forfatter", bog.Forfatter));
                kommando.Parameters.Add(new SqlParameter("@genre", bog.Genre));
                kommando.Parameters.Add(new SqlParameter("@subkategori", bog.Subkategori));
                kommando.Parameters.Add(new SqlParameter("@familie", bog.Familie));
                kommando.Parameters.Add(new SqlParameter("@forlag", bog.Forlag));
                kommando.Parameters.Add(new SqlParameter("@udlånes", bog.Udlånes));
                kommando.Parameters.Add(new SqlParameter("@kommentar", bog.Kommentar));

                kommando.ExecuteNonQuery();

                forb.Close();
                forb.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ÆndreBog(Bog bog)
        {
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("ÆndreBog", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@bogid", bog.Id));
                kommando.Parameters.Add(new SqlParameter("@titel", bog.Titel));
                kommando.Parameters.Add(new SqlParameter("@forfatter", bog.Forfatter));
                kommando.Parameters.Add(new SqlParameter("@genre", bog.Genre));
                kommando.Parameters.Add(new SqlParameter("@subkategori", bog.Subkategori));
                kommando.Parameters.Add(new SqlParameter("@familie", bog.Familie));
                kommando.Parameters.Add(new SqlParameter("@forlag", bog.Forlag));
                kommando.Parameters.Add(new SqlParameter("@udlånes", bog.Udlånes));
                kommando.Parameters.Add(new SqlParameter("@kommentar", bog.Kommentar));

                kommando.ExecuteNonQuery();

                forb.Close();
                forb.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Bog HentBog(int id)
        {
            Bog resultat = null;
            try
            {
                SqlConnection forb = hentForbindelse();
                SqlCommand kommando = new SqlCommand("HentBog", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@BogID", id));

                SqlDataReader sdr = kommando.ExecuteReader();

                if (sdr.Read())
                {
                    int bogid = Convert.ToInt32(sdr["bogid"]);
                    string titel = Convert.ToString(sdr["titel"]);
                    string forfatter = Convert.ToString(sdr["forfatter"]);
                    string genre = Convert.ToString(sdr["genre"]);
                    string subkategori = Convert.ToString(sdr["subkategori"]);
                    string familie = Convert.ToString(sdr["familie"]);
                    string forlag = Convert.ToString(sdr["forlag"]);
                    bool udlånes = Convert.ToBoolean(sdr["udlånes"]);
                    string kommentar = Convert.ToString(sdr["kommentar"]);
                    bool kanudlånes = (bool)sdr["udlånt"];

                    resultat = AktivFactory.HentAktivFactory().SkabNyBog(bogid, titel, forfatter, genre, subkategori, familie, forlag, udlånes, kommentar, kanudlånes);
                }
                forb.Close();
                forb.Dispose();
            }
            catch (Exception)
            {
                resultat = null;
            }
            return resultat;
        }
        public bool SletBog(int id)
        {
            bool resultat = false;

            try
            {
                SqlConnection forb = hentForbindelse();
                SqlCommand kommando = new SqlCommand("SletBog", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@bogid", id));

                kommando.ExecuteNonQuery();

                forb.Close();
                forb.Dispose();
                resultat = true;
            }
            catch (Exception)
            {
                resultat = false;
            }
            return resultat;
        }
        public List<Bog> HentAlleBøger()
        {
            List<Bog> bogListe = new List<Bog>();

            try
            {
                SqlConnection forb = hentForbindelse();
                SqlCommand kommando = new SqlCommand("HentAlleBøger", forb);

                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = kommando.ExecuteReader();

                while (reader.Read())
                {
                    int bogid = Convert.ToInt32(reader["bogid"]);
                    string titel = Convert.ToString(reader["titel"]);
                    string forfatter = Convert.ToString(reader["forfatter"]);
                    string genre = Convert.ToString(reader["genre"]);
                    string subkategori = Convert.ToString(reader["subkategori"]);
                    string familie = Convert.ToString(reader["familie"]);
                    string forlag = Convert.ToString(reader["forlag"]);
                    bool udlånes = Convert.ToBoolean(reader["udlånes"]);
                    string kommentar = Convert.ToString(reader["kommentar"]);
                    bool kanudlånes = (bool)reader["udlånt"];
                    Bog bog = AktivFactory.HentAktivFactory().SkabNyBog(bogid, titel, forfatter, genre, subkategori, familie, forlag, udlånes, kommentar, kanudlånes);
                    bogListe.Add(bog);
                }
                forb.Close();
                forb.Dispose();
            }
            catch (Exception)
            {
                bogListe = null;
            }
            return bogListe;
        }
        #endregion
        #region Brætspil
        public bool GemBrætSpil(Brætspil bs)
        {
            bool resultat = false;
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("GemBrætSpil", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@brætspilsnavn", bs.BrætspilsNavn));
                kommando.Parameters.Add(new SqlParameter("@udgiver", bs.Udgiver));
                kommando.Parameters.Add(new SqlParameter("@udlånes", bs.Udlånes));
                kommando.Parameters.Add(new SqlParameter("@kommentar", bs.Kommentar));
                kommando.Parameters.Add(new SqlParameter("@kategori", bs.Kategori));

                kommando.ExecuteNonQuery();

                forb.Close();
                forb.Dispose();

                resultat = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fejl: " + e.Message);
                resultat = false;
            }
            return resultat;
        }
        public bool ÆndreBrætSpil(Brætspil bs)
        {
            bool resultat = false;

            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("ÆndreBrætSpil", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@brætspilid", bs.Id));
                kommando.Parameters.Add(new SqlParameter("@brætspilsnavn", bs.BrætspilsNavn));
                kommando.Parameters.Add(new SqlParameter("@udgiver", bs.Udgiver));
                kommando.Parameters.Add(new SqlParameter("@udlånes", bs.Udlånes));
                kommando.Parameters.Add(new SqlParameter("@kommentar", bs.Kommentar));
                kommando.Parameters.Add(new SqlParameter("@kategori", bs.Kategori));

                kommando.ExecuteNonQuery();

                forb.Close();
                forb.Dispose();

                resultat = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fejl: " + e.Message);
                resultat = false;
            }
            return resultat;
        }
        public Brætspil HentBrætSpil(int id)
        {
            Brætspil resultat = null;
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("HentBrætSpil", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@brætspilid", id));

                SqlDataReader sdr = kommando.ExecuteReader();

                if (sdr.Read())
                {
                    string brætspilnavn = Convert.ToString(sdr["brætspilnavn"]);
                    string udgiver = Convert.ToString(sdr["udgiver"]);
                    bool udlånes = Convert.ToBoolean(sdr["udlånes"]);
                    string kommentar = Convert.ToString(sdr["kommentar"]);
                    string kategori = Convert.ToString(sdr["kategori"]);
                    bool kanudlånes = (bool)sdr["udlånt"];

                    resultat = AktivFactory.HentAktivFactory().SkabNyBrætspil(id, brætspilnavn, udgiver, udlånes, kommentar, kategori, kanudlånes);
                }
                forb.Close();
                forb.Dispose();
            }
            catch (Exception)
            {
                resultat = null;
            }
            return resultat;
        }
        public List<Brætspil> HentAlleBrætSpil()
        {
            List<Brætspil> resultat = new List<Brætspil>();
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("HentAlleBrætSpil", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = kommando.ExecuteReader();

                while (sdr.Read())
                {
                    int brætspilid = Convert.ToInt32(sdr["brætspilid"]);
                    string brætspilnavn = Convert.ToString(sdr["brætspilnavn"]);
                    string udgiver = Convert.ToString(sdr["udgiver"]);
                    bool udlånes = (bool)sdr["udlånes"];
                    string kommentar = Convert.ToString(sdr["kommentar"]);
                    string kategori = Convert.ToString(sdr["kategori"]);
                    bool kanudlånes = (bool)sdr["udlånt"];
                    resultat.Add(AktivFactory.HentAktivFactory().SkabNyBrætspil(brætspilid, brætspilnavn, udgiver, udlånes, kommentar, kategori, kanudlånes));
                }
                forb.Close();
                forb.Dispose();
            }
            catch (Exception)
            {
                resultat = null;
            }
            return resultat;
        }
        public bool SletBrætSpil(int id)
        {
            bool resultat = false;

            try
            {
                SqlConnection forb = hentForbindelse();
                SqlCommand kommando = new SqlCommand("SletBrætSpil", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@brætspilid", id));
                kommando.ExecuteNonQuery();
                forb.Close();
                forb.Dispose();
                resultat = true;
            }
            catch (Exception)
            {
                resultat = false;
            }
            return resultat;
        }
        #endregion
        #region Udstyr
        public bool GemUdstyr(Udstyr udstyr)
        {
            bool resultat = false;
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("GemUdstyr", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@navn", udstyr.UdstyrsNavn));
                kommando.Parameters.Add(new SqlParameter("@kategori", udstyr.Kategori));
                kommando.Parameters.Add(new SqlParameter("@udlånes", udstyr.Udlånes));
                kommando.Parameters.Add(new SqlParameter("@kommentar", udstyr.Kommentar));

                kommando.ExecuteNonQuery();

                forb.Close();
                forb.Dispose();

                resultat = true;
            }
            catch (Exception)
            {
                resultat = false;
            }
            return resultat;
        }
        public bool ÆndreUdstyr(Udstyr udstyr)
        {
            bool resultat = false;

            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("ÆndreUdstyr", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@udstyrid", udstyr.Id));
                kommando.Parameters.Add(new SqlParameter("@navn", udstyr.UdstyrsNavn));
                kommando.Parameters.Add(new SqlParameter("@kategori", udstyr.Kategori));
                kommando.Parameters.Add(new SqlParameter("@udlånes", udstyr.Udlånes));
                kommando.Parameters.Add(new SqlParameter("@kommentar", udstyr.Kommentar));

                kommando.ExecuteNonQuery();

                forb.Close();
                forb.Dispose();

                resultat = true;
            }
            catch (Exception)
            {
                resultat = false;
            }
            return resultat;
        }
        public Udstyr HentUdstyr(int id)
        {
            Udstyr resultat = null;
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("HentUdstyr", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@udstyrid", id));

                SqlDataReader sdr = kommando.ExecuteReader();

                if (sdr.Read())
                {
                    string udstyrnavn = Convert.ToString(sdr["navn"]);
                    string kategori = Convert.ToString(sdr["kategori"]);
                    bool udlånes = Convert.ToBoolean(sdr["udlånes"]);
                    string kommentar = Convert.ToString(sdr["kommentar"]);
                    bool kanudlånes = (bool)sdr["udlånt"];
                    resultat = AktivFactory.HentAktivFactory().SkabNytUdstyr(id, udstyrnavn, kategori, udlånes, kommentar, kanudlånes);
                }
                forb.Close();
                forb.Dispose();
            }
            catch (Exception)
            {
                resultat = null;
            }
            return resultat;
        }
        public List<Udstyr> HentALtUdstyr()
        {
            List<Udstyr> resultat = new List<Udstyr>();
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("HentAltUdstyr", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = kommando.ExecuteReader();

                while (sdr.Read())
                {
                    int udstyrid = Convert.ToInt32(sdr["udstyrid"]);
                    string udstyrnavn = Convert.ToString(sdr["navn"]);
                    string kategori = Convert.ToString(sdr["kategori"]);
                    bool udlånes = Convert.ToBoolean(sdr["udlånes"]);
                    string kommentar = Convert.ToString(sdr["kommentar"]);
                    bool kanudlånes = (bool)sdr["udlånt"];
                    resultat.Add(AktivFactory.HentAktivFactory().SkabNytUdstyr(udstyrid, udstyrnavn, kategori, udlånes, kommentar, kanudlånes));
                }
                forb.Close();
                forb.Dispose();
            }
            catch (Exception)
            {
                resultat = null;
            }
            return resultat;
        }
        public bool SletUdstyr(int id)
        {
            bool resultat = false;

            try
            {
                SqlConnection forb = hentForbindelse();
                SqlCommand kommando = new SqlCommand("SletUdstyr", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@udstyrid", id));
                kommando.ExecuteNonQuery();
                forb.Close();
                forb.Dispose();
                resultat = true;
            }
            catch (Exception)
            {
                resultat = false;
            }
            return resultat;
        }
        #endregion
        #region Lokale
        public Lokale HentLokale(int id)
        {
            Lokale resultat = null;

            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("HentLokale", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@lokaleid", id));

                SqlDataReader sdr = kommando.ExecuteReader();

                if (sdr.Read())
                {
                    string lokalenavn = Convert.ToString(sdr["lokalenavn"]);
                    string lokation = Convert.ToString(sdr["lokation"]);
                    bool udlånes = Convert.ToBoolean(sdr["udlånes"]);
                    string kommentar = Convert.ToString(sdr["kommentar"]);
                    string møbler = Convert.ToString(sdr["møbler"]);
                    bool kanudlånes = (bool)sdr["udlånt"];
                    resultat = AktivFactory.HentAktivFactory().SkabNytLokale(id, lokalenavn, lokation, udlånes, kommentar, møbler, kanudlånes);
                }
                forb.Close();
                forb.Dispose();
            }
            catch (Exception)
            {
                resultat = null;
            }
            return resultat;
        }
        public List<Lokale> HentAlleLokaler()
        {
            List<Lokale> resultat = new List<Lokale>();
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("HentAlleLokaler", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = kommando.ExecuteReader();

                while (sdr.Read())
                {
                    int lokaleid = Convert.ToInt32(sdr["lokaleid"]);
                    string lokalenavn = Convert.ToString(sdr["lokalenavn"]);
                    string lokation = Convert.ToString(sdr["lokation"]);
                    bool udlånes = Convert.ToBoolean(sdr["udlånes"]);
                    string kommentar = Convert.ToString(sdr["kommentar"]);
                    string møbler = Convert.ToString(sdr["møbler"]);
                    bool kanudlånes = (bool)sdr["udlånt"];
                    resultat.Add(AktivFactory.HentAktivFactory().SkabNytLokale(lokaleid, lokalenavn, lokation, udlånes, kommentar, møbler, kanudlånes));
                }
                forb.Close();
                forb.Dispose();
            }
            catch (Exception)
            {
                resultat = null;
            }
            return resultat;
        }
        public bool GemLokale(Lokale lokale)
        {
            bool resultat = false;
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("GemLokale", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@lokalenavn", lokale.LokaleNavn));
                kommando.Parameters.Add(new SqlParameter("@lokation", lokale.Lokation));
                kommando.Parameters.Add(new SqlParameter("@udlånes", lokale.Udlånes));
                kommando.Parameters.Add(new SqlParameter("@kommentar", lokale.Kommentar));
                kommando.Parameters.Add(new SqlParameter("@møbler", lokale.Møbler));

                kommando.ExecuteNonQuery();

                forb.Close();
                forb.Dispose();

                resultat = true;
            }
            catch (Exception)
            {
                resultat = false;
            }
            return resultat;
        }
        public bool ÆndreLokale(Lokale lokale)
        {
            bool resultat = false;

            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("ÆndreLokale", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@lokaleid", lokale.Id));
                kommando.Parameters.Add(new SqlParameter("@lokalenavn", lokale.LokaleNavn));
                kommando.Parameters.Add(new SqlParameter("@lokation", lokale.Lokation));
                kommando.Parameters.Add(new SqlParameter("@udlånes", lokale.Udlånes));
                kommando.Parameters.Add(new SqlParameter("@kommentar", lokale.Kommentar));
                kommando.Parameters.Add(new SqlParameter("@møbler", lokale.Møbler));

                kommando.ExecuteNonQuery();

                forb.Close();
                forb.Dispose();

                resultat = true;
            }
            catch (Exception)
            {
                resultat = false;
            }
            return resultat;
        }
        public bool SletLokale(int id)
        {
            bool resultat = false;

            try
            {
                SqlConnection forb = hentForbindelse();
                SqlCommand kommando = new SqlCommand("SletLokale", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@lokaleid", id));
                kommando.ExecuteNonQuery();
                forb.Close();
                forb.Dispose();
                resultat = true;
            }
            catch (Exception)
            {
                resultat = false;
            }
            return resultat;
        }
        #endregion
        #region Udlån
        public bool OpdaterUdlån(Udlån udl)
        {
            bool resultat;
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("OpdaterUdlån", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@udlånid", udl.Id));
                kommando.Parameters.Add(new SqlParameter("@medlemsid", udl.Medlem));
                kommando.Parameters.Add(new SqlParameter("@adminid", udl.AdminId));
                kommando.Parameters.Add(new SqlParameter("@udlåningsdato", udl.Udlåningsdato));
                kommando.Parameters.Add(new SqlParameter("@afleveringsdato", udl.Afleveringsdato));
                kommando.Parameters.Add(new SqlParameter("@reeleafleveringsdato", udl.Reelleafleveringsdato));
                kommando.Parameters.Add(new SqlParameter("@godkendelse", (int)udl.Godkendt));

                kommando.ExecuteNonQuery();

                forb.Close();
                forb.Dispose();

                resultat = true;
            }
            catch (Exception)
            {
                resultat = false;
            }
            return resultat;
        }
        public bool GemUdlån(Udlån udl)
        {
            bool resultat = false;
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("GemUdlån", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@medlemsid", udl.Medlem));
                kommando.Parameters.Add(new SqlParameter("@udlåningsdato", udl.Udlåningsdato));
                kommando.Parameters.Add(new SqlParameter("@afleveringsdato", udl.Afleveringsdato));

                SqlDataReader sdr = kommando.ExecuteReader();
                if (sdr.Read())
                {
                    int udlånid = Convert.ToInt32(sdr["udlånid"]);
                    foreach (IAktiv item in udl.Aktiver)
                    {
                        if (item.GetType() == typeof(Bog))
                        {
                            SqlConnection forb2 = hentForbindelse();

                            Bog a = (Bog)item;

                            SqlCommand kommando2 = new SqlCommand("GemUdlånBog", forb2);
                            kommando2.CommandType = System.Data.CommandType.StoredProcedure;

                            kommando2.Parameters.Add(new SqlParameter("@udlånid", udlånid));
                            kommando2.Parameters.Add(new SqlParameter("@bogid", a.Id));

                            kommando2.ExecuteNonQuery();

                            forb2.Close();
                            forb2.Dispose();
                        }
                        else if (item.GetType() == typeof(Udstyr))
                        {
                            SqlConnection forb2 = hentForbindelse();

                            Udstyr a = (Udstyr)item;

                            SqlCommand kommando2 = new SqlCommand("GemUdlånUdstyr", forb2);
                            kommando2.CommandType = System.Data.CommandType.StoredProcedure;

                            kommando2.Parameters.Add(new SqlParameter("@udlånid", udlånid));
                            kommando2.Parameters.Add(new SqlParameter("@udstyrid", a.Id));

                            kommando2.ExecuteNonQuery();

                            forb2.Close();
                            forb2.Dispose();
                        }
                        else if (item.GetType() == typeof(Brætspil))
                        {
                            SqlConnection forb2 = hentForbindelse();

                            Brætspil a = (Brætspil)item;

                            SqlCommand kommando2 = new SqlCommand("GemUdlånBrætspil", forb2);
                            kommando2.CommandType = System.Data.CommandType.StoredProcedure;

                            kommando2.Parameters.Add(new SqlParameter("@udlånid", udlånid));
                            kommando2.Parameters.Add(new SqlParameter("@brætspilid", a.Id));

                            kommando2.ExecuteNonQuery();

                            forb2.Close();
                            forb2.Dispose();
                        }
                        else if (item.GetType() == typeof(Lokale))
                        {
                            SqlConnection forb2 = hentForbindelse();

                            Lokale a = (Lokale)item;

                            SqlCommand kommando2 = new SqlCommand("GemUdlånLokale", forb2);
                            kommando2.CommandType = System.Data.CommandType.StoredProcedure;

                            kommando2.Parameters.Add(new SqlParameter("@udlånid", udlånid));
                            kommando2.Parameters.Add(new SqlParameter("@lokaleid", a.Id));

                            kommando2.ExecuteNonQuery();

                            forb2.Close();
                            forb2.Dispose();
                        }
                    }
                }
                forb.Close();
                forb.Dispose();

                resultat = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                resultat = false;
            }

            return resultat;
        }
        public List<Udlån> FindAlleUdlån()
        {
            List<Udlån> result = new List<Udlån>();

            try
            {
                SqlConnection forb = hentForbindelse();
                SqlCommand kommando = new SqlCommand("HentAlleUdlån", forb);

                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = kommando.ExecuteReader();
                #region first result
                while (reader.Read())
                {

                    try
                    {
                        int udlånid = Convert.ToInt32(reader["udlånid"]);
                        int medlemid = Convert.ToInt32(reader["medlemid"]);
                        DateTime udldato = Convert.ToDateTime(reader["udlåningsdato"]);
                        DateTime afldato = Convert.ToDateTime(reader["afleveringsdato"]);
                        int godkendelse = Convert.ToInt32(reader["godkendelse"]);

                        Medlem mdl = HentMedlem(medlemid);

                        result.Add(AktivFactory.HentAktivFactory().SkabNytUdlån(udlånid, mdl, 0, udldato, afldato, null, godkendelse, new List<IAktiv>()));


                    }
                    catch (Exception e)
                    {

                    }
                }
                #endregion
                #region the rest
                while (reader.NextResult())
                {

                    while (reader.Read())
                    {
                        Bog bog = null;
                        Udstyr udstyr = null;
                        Lokale lokale = null;
                        Brætspil brætspil = null;

                        try
                        {
                            udstyr = HentUdstyr(Convert.ToInt32(reader["udstyrid"]));
                            int udlånid = Convert.ToInt32(reader["udlånid"]);
                            if (udstyr != null)
                            {
                                Udlån u = result.Find(x => x.Id == udlånid);
                                u.Aktiver.Add(udstyr);
                                u.Reelleafleveringsdato = u.Udlåningsdato.AddMonths(1);
                            }


                        }
                        catch (Exception e)
                        {

                        }
                        try
                        {
                            bog = HentBog(Convert.ToInt32(reader["bogid"]));
                            int udlånid = Convert.ToInt32(reader["udlånid"]);
                            if (bog != null)
                            {
                                Udlån u = result.Find(x => x.Id == udlånid);
                                u.Aktiver.Add(bog);
                                u.Reelleafleveringsdato = u.Udlåningsdato.AddMonths(3);
                            }

                        }
                        catch (Exception e)
                        {

                        }
                        try
                        {
                            lokale = HentLokale(Convert.ToInt32(reader["lokaleid"]));
                            int udlånid = Convert.ToInt32(reader["udlånid"]);
                            if (lokale != null)
                            {
                                Udlån u = result.Find(x => x.Id == udlånid);
                                u.Aktiver.Add(lokale);
                                u.Reelleafleveringsdato = u.Udlåningsdato.AddDays(1);
                            }

                        }
                        catch (Exception e)
                        {

                        }
                        try
                        {
                            brætspil = HentBrætSpil(Convert.ToInt32(reader["brætspilid"]));
                            int udlånid = Convert.ToInt32(reader["udlånid"]);
                            if (brætspil != null)
                            {
                                Udlån u = result.Find(x => x.Id == udlånid);
                                u.Aktiver.Add(brætspil);
                                u.Reelleafleveringsdato = u.Udlåningsdato.AddDays(7);
                            }

                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                #endregion
                forb.Close();
                forb.Dispose();
            }
            catch (Exception)
            {
                result = null;
            }
            foreach (var item in result)
            {
               
                foreach (var item2 in item.Aktiver)
                {
                    Console.WriteLine(item2.GetType());
                }
            }
            return result;
        }
        #endregion
        #region medlem
        public Medlem HentMedlem(int id)
        {
            Medlem resultat = null;

            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("HentMedlem", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                kommando.Parameters.Add(new SqlParameter("@id", id));

                SqlDataReader sdr = kommando.ExecuteReader();

                if (sdr.Read())
                {
                    int medlemid = Convert.ToInt32(sdr["medlemid"]);
                    string brugernavn = Convert.ToString(sdr["brugernavn"]);
                    string fornavn = Convert.ToString(sdr["fornavn"]);
                    string efternavn = Convert.ToString(sdr["efternavn"]);
                    string adgangskode = Convert.ToString(sdr["adgangskode"]);
                    string email = Convert.ToString(sdr["email"]);
                    int status = Convert.ToInt32(sdr["rang"]);
                    Medlem.MedlemType medl;

                    if (status == 1)
                    {
                        medl = Medlem.MedlemType.Bruger;
                    }
                    else
                    {
                        medl = Medlem.MedlemType.Bestyrelse;
                    }

                    resultat = new Medlem(medlemid, fornavn, efternavn, brugernavn, adgangskode, email, medl);
                   

                }
                forb.Close();
                forb.Dispose();
            }
            catch (Exception)
            {
                resultat = null;
            }
            return resultat;

        }

        public Medlem HentMedlem(string brugernavn, string password)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
