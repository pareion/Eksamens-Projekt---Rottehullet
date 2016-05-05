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

                kommando.Parameters.Add(new SqlParameter("@bogid", id));

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

                    resultat = AktivFactory.HentAktivFactory().SkabNyBog(bogid, titel, forfatter, genre, subkategori, familie, forlag, udlånes, kommentar);
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

                    Bog bog = AktivFactory.HentAktivFactory().SkabNyBog(bogid, titel, forfatter, genre, subkategori, familie, forlag, udlånes, kommentar);
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
                Console.WriteLine("Fejl: "+e.Message);
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
                Console.WriteLine("Fejl: "+e.Message);
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
                    string brætspilnavn = Convert.ToString(sdr["titel"]);
                    string udgiver = Convert.ToString(sdr["udgiver"]);
                    bool udlånes = Convert.ToBoolean(sdr["udlånes"]);
                    string kommentar = Convert.ToString(sdr["kommentar"]);
                    string kategori = Convert.ToString(sdr["kategori"]);

                    resultat = AktivFactory.HentAktivFactory().SkabNyBrætspil(id, brætspilnavn, udgiver, udlånes, kommentar, kategori);
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
                    bool udlånes =  (bool) sdr["udlånes"];
                    string kommentar = Convert.ToString(sdr["kommentar"]);
                    string kategori = Convert.ToString(sdr["kategori"]);
                    resultat.Add(AktivFactory.HentAktivFactory().SkabNyBrætspil(brætspilid, brætspilnavn, udgiver, udlånes, kommentar, kategori));
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

                    resultat = AktivFactory.HentAktivFactory().SkabNytUdstyr(id, udstyrnavn, kategori, udlånes, kommentar);
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
                    resultat.Add(AktivFactory.HentAktivFactory().SkabNytUdstyr(udstyrid, udstyrnavn, kategori, udlånes, kommentar));
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

                    resultat = AktivFactory.HentAktivFactory().SkabNytLokale(id, lokalenavn, lokation, udlånes, kommentar, møbler);
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

                    resultat.Add(AktivFactory.HentAktivFactory().SkabNytLokale(lokaleid, lokalenavn, lokation, udlånes, kommentar, møbler));
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
        public bool GemUdlån(Udlån udl)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region medlem
        public Medlem HentMedlem(string brugernavn, string password)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
