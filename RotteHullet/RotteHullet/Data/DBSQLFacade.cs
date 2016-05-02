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


        private SqlConnection hentForbindelse() {
            /*
            Servernavn: ealdb1.eal.local
Brugernavn: ejl51_usr
kodeord: Baz1nga51
Databasenavn: ejl51_db

    */
            SqlConnection forb = new SqlConnection("Server=ealdb1.eal.local;Database=ejl51_db; User ID = ejl51_usr; Password = Baz1nga51");
            forb.Open();
            return forb;
        }


        /*



        +GemBrætSpil(BrætSpil: bs): bool
+ÆndreBrætSpil(int: gammeltID, BrætSpil: bs): bool
+HentBrætSpil(int: id): BrætSpil
+HentAlleBrætSpil(): List<BrætSpil>
+SletBrætSpil(int: id): bool

+GemBog(Bog: bog): bool
+ÆndreBog(int: gammeltID, Bog: bog): bool
+HentBog(int: id): Bog
+HentAlleBøger(): List<Bog>
+Sletbog(int: id): bool

+GemUdstyr(Udstyr: udstyr): bool
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


        /*

        -_bogid: int
-_titel: string
-_forfatter: string
-_genre: string
-_subkategori: string
-_familie: string
-_forlag: string
-_kommentar: string

*/

        public bool GemBog(Bog bog) {
            try
            {
                SqlConnection forb = hentForbindelse();

                SqlCommand kommando = new SqlCommand("GemBog", forb);
                kommando.CommandType = System.Data.CommandType.StoredProcedure;

                //  kommando.Parameters.Add(new SqlParameter("@BogID", bog. getID()));
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

                SqlCommand kommando = new SqlCommand("GemBog", forb);
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


/*
        public Bog HentBog(int id)
        {
            Bog resultat = null;

            SqlConnection conn = hentForbindelse();
            //TODO lav en stored procedore der henter hele quality testen
            SqlCommand command = new SqlCommand("HentBog", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@QualityTestID", ID));

            SqlDataReader sdr = command.ExecuteReader();

            while (sdr.Read())
            {
                DateTime date = Convert.ToDateTime(sdr["CheckedDate"]);
                string qualityTestActivities = Convert.ToString(sdr["QualityTestActivities"]);
                string expectedR = Convert.ToString(sdr["expectedResult"]);
                string employee = Convert.ToString(sdr["employee"]);
                string comment = Convert.ToString(sdr["comment"]);
                string results = Convert.ToString(sdr["result"]);
                bool done = (bool)sdr["done"];
                bool approved = (bool)sdr["approved"]; ;

                result = Factory.GetFactory().GetQTF().CreateQualityTest(ID, date, qualityTestActivities, expectedR, employee, comment, results, approved, done);
            }
            conn.Close();
            conn.Dispose();
            return result;
        }

        */

        // DONE     +GemBog(Bog: bog): bool

        /*
        + DONE ÆndreBog(int: gammeltID, Bog: bog): bool
+HentBog(int: id): Bog
+HentAlleBøger(): List<Bog>
+Sletbog(int: id): bool
*/

    }
}
