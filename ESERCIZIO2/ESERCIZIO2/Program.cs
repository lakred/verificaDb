using System;
using System.Data.SqlClient;
using static ESERCIZIO2.Constants;
namespace ESERCIZIO2
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //Query 1: Recupero la lista contenente: museo, nome opera, nome personaggio degli artisti italiani
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT M.MuseumName as MuseumName , A.Name as ArtworkName, C.Name as CharacterName " +
                                   "FROM MUSEUM M " +
                                   "JOIN ARTWORK AW ON M.Id_Museum = AW.ID_Museum " +
                                   "JOIN CHARACTER C ON AW.ID_Character = C.ID_Character " +
                                   "JOIN ARTIST A ON AW.ID_Artist = A.Id_Artist " +
                                   "WHERE A.Country = 'Italia';";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Console.WriteLine("{0} - {1} - {2}", reader[0], reader[1], reader[2]);
                    }

                    reader.Close();
                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore: " + ex.Message);
            }

            try
            {
                //Query 2: Recupero i nomi degli artisti, opere di quali sono conservate a Parigi
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT a.Name as ArtistName, aw.Name as ArtWorkName " +
                                   "FROM ARTIST a " +
                                   "JOIN ARTWORK aw ON a.Id_Artist = aw.Id_Artist " +
                                   "JOIN MUSEUM m ON aw.ID_Museum = m.Id_Museum " +
                                   "WHERE m.City = 'Parigi'; ";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Console.WriteLine("{0} - {1}", reader[0], reader[1]);
                    }

                    reader.Close();
                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore: " + ex.Message);
            }

            try
            {
                //Query 3: Recupero la città in cui è conservato il quadro "Flora"
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT M.City " +
                                   "FROM MUSEUM M " +
                                   "INNER JOIN ARTWORK AW ON M.Id_Museum = AW.ID_Museum " +
                                   "WHERE AW.Name = 'Flora'";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Console.WriteLine("{0}", reader[0]);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore: " + ex.Message);
            }
        }
    }
}