using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Models;

namespace BiosManager.Context.MSSQL
{
    public class MssqlVoorstellingContext : Database.Database, IVoorstellingContext
    {
        public void Insert(Voorstelling voorstelling)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO dbo.voorstelling (zaal_ID, begintijd, eindtijd) VALUES (@zaal, @begintijd, @eindtijd)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@zaal", voorstelling.Zl);
                    cmd.Parameters.AddWithValue("@begintijd", voorstelling.Starttijd);
                    cmd.Parameters.AddWithValue("@eindtijd", voorstelling.Eindtijd);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public List<Voorstelling> Select()
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<Voorstelling> voorstellingen = new List<Voorstelling>();
                    conn.Open();
                    string query = "SELECT * FROM dbo.voorstelling INNER JOIN dbo.zaal ON voorstelling.zaal_ID = zaal.ID INNER JOIN dbo.film ON voorstelling.film_ID = film.ID INNER JOIN dbo.stoel ON zaal.ID = stoel.zaal_ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("ID"));
                        int zaalId = reader.GetInt32(reader.GetOrdinal("zaal_ID"));
                        int filmId = reader.GetInt32(reader.GetOrdinal("film_ID"));
                        DateTime starttijd = reader.GetDateTime(reader.GetOrdinal("begintijd"));
                        DateTime eindtijd = reader.GetDateTime(reader.GetOrdinal("eindtijd"));

                        int nummer = reader.GetInt32(reader.GetOrdinal("nummer"));
                        int grootte = reader.GetInt32(reader.GetOrdinal("grootte"));

                        string naam = reader.GetString(reader.GetOrdinal("naam"));
                        string genres = reader.GetString(reader.GetOrdinal("genre"));
                        string beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
                        int lengte = reader.GetInt32(reader.GetOrdinal("lengte"));
                        decimal rating = reader.GetDecimal(reader.GetOrdinal("rating"));
                        int jaar = reader.GetInt32(reader.GetOrdinal("jaar"));

                        int rij = reader.GetInt32(reader.GetOrdinal("rij"));
                        int stoelnummer = reader.GetInt32(reader.GetOrdinal("stoelnummer"));
                        bool bezet = reader.GetBoolean(reader.GetOrdinal("bezet"));

                        Stoel s = new Stoel(rij, stoelnummer, bezet);
                        Zaal z = new Zaal(zaalId, nummer, grootte);
                        Film f = new Film(filmId, naam, beschrijving, genres, lengte, rating, jaar);
                        Voorstelling v = new Voorstelling(id, z, f, starttijd, eindtijd);

                        voorstellingen.Add(v);
                    }
                    conn.Close();
                    return voorstellingen;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Voorstelling>();
            }
        }

        public void Delete(Voorstelling voorstelling)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM dbo.voorstelling WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", voorstelling.Id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}