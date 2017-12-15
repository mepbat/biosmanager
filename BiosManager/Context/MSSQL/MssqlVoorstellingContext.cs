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
                    string query ="INSERT INTO dbo.voorstelling (zaal_ID, begintijd, eindtijd) VALUES (@zaal, @begintijd, @eindtijd)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@zaal", voorstelling.Zaal);
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
                    string query = "SELECT * FROM dbo.voorstelling";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("ID"));
                        int zaalNummer = reader.GetInt32(reader.GetOrdinal("zaal_ID"));
                        int filmId = reader.GetInt32(reader.GetOrdinal("film_ID"));
                        DateTime starttijd = reader.GetDateTime(reader.GetOrdinal("begintijd"));
                        DateTime eindtijd = reader.GetDateTime(reader.GetOrdinal("eindtijd"));

                        Voorstelling v = new Voorstelling
                        {
                            Id = id,
                            ZaalNummer = zaalNummer,
                            FilmId = filmId,
                            Starttijd = starttijd,
                            Eindtijd = eindtijd
                        };
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
                SqlCommand cmd = new SqlCommand(query,conn);

                cmd.Parameters.AddWithValue("@id", voorstelling.Id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}