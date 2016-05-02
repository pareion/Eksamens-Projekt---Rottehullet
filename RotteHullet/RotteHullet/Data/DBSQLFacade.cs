using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RotteHullet.Domain.BusinessLogic;

namespace RotteHullet.Data
{
    class DBSQLFacade
    {
        private static IDBFacade _dbsqlFacade;

        public static IDBFacade HentDBSQLFacade()
        {
            if (_dbsqlFacade == null)
            {
                // Skal ændres til DBSQLFacade når vi bruger en rigtig database
                _dbsqlFacade = DBRamFacade.HentDbRamFacade();
            }
            return _dbsqlFacade;
        }
        #region forbindelse
        private SqlConnection hentForbindelse() {
            SqlConnection forb = new SqlConnection("Server=ealdb1.eal.local;Database=ejl51_db; User ID = ejl51_usr; Password = Baz1nga51");
            forb.Open();
            return forb;
        }
        #endregion
        /*


+ÆndreUdstyr(int: gammeltID, Udstyr: udstyr): bool
+HentUdstyr(int: id): Udstyr
+HentAlleUdstyr(): List<Udstyr>
+SletUdstyr(int: id): bool

+GemLokale(Lokale: lokale): bool
+ÆndreLokale(int: gammeltID, Lokale: lokale): bool
+HentLokale(int: id): Lokale
+HentAlleLokaler(): List<Lokale>
+SletLokale(int: id): bool
    */
        #region Bog
        public bool GemBog(Bog bog) {
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

                kommando.Parameters.Add(new SqlParameter("@BogID", bog.Id));
                kommando.Parameters.Add(new SqlParameter("@titel", bog.Titel));
                kommando.Parameters.Add(new SqlParameter("@forfatter", bog.Forfatter));
                kommando.Parameters.Add(new SqlParameter("@genre", bog.Genre));
                kommando.Parameters.Add(new SqlParameter("@subkategori", bog.Subkategori));
                kommando.Parameters.Add(new SqlParameter("@familie", bog.Familie));
                kommando.Parameters.Add(new SqlParameter("@forlag", bog.Forlag));
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
                    string kommentar = Convert.ToString(sdr["kommentar"]);

                    resultat = AktivFactory.HentAktivFactory().SkabNyBog(bogid, titel, forfatter, genre, subkategori, familie, forlag);
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
        public List<Bog> HentAlleBøger() {
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
                    string kommentar = Convert.ToString(reader["kommentar"]);

                    Bog bog = AktivFactory.HentAktivFactory().SkabNyBog(bogid, titel, forfatter, genre, subkategori, familie, forlag);
                    bogListe.Add(bog);
                }

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

            return false;
        }
        public bool ÆndreBrætSpil(int gammeltID, Brætspil bs)
        {

            return false;
        }
        public Brætspil HentBrætSpil(int id)
        {

            return null;
        }
        public List<Brætspil> HentAlleBrætSpil()
        {

            return null;
        }
        public bool SletBrætSpil(int id)
        {
            return false;
        }
        #endregion
        #region Udstyr
        public bool GemUdstyr(Udstyr udstyr)
        {
            return false;
        }
        #endregion
    }
}
