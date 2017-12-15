using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using BiosManager.Database;
using BiosManager.Models;

namespace BiosManager.Context.MSSQL
{
    public class MssqlReserveringContext : Database.Database, IReserveringContext
    {
        public void Insert(Reservering reservering)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = "INSERT INTO dbo.reservering (Stoel_ID, datum, prijs) VALUES (@stoel, @datum, @prijs)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@stoel", reservering.Stoelen);
                cmd.Parameters.AddWithValue("@datum", reservering.Datum);
                cmd.Parameters.AddWithValue("@prijs", reservering.Prijs);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Reservering> Select()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<Reservering> reserveringen = new List<Reservering>();
                    conn.Open();
                    string query = "SELECT * FROM dbo.reservering";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("ID"));
                        int accountId = reader.GetInt32(reader.GetOrdinal("account_ID"));
                        int voorstellingId = reader.GetInt32(reader.GetOrdinal("voorstelling_ID"));
                        DateTime datum = reader.GetDateTime(reader.GetOrdinal("datum"));
                        SqlMoney prijs = reader.GetSqlMoney(reader.GetOrdinal("prijs"));

                        Reservering res = new Reservering()
                        {
                            Id = id,
                            AccountId = accountId,
                            VoorstellingId = voorstellingId,
                            Datum = datum,
                            Prijs = prijs,
                        };
                        reserveringen.Add(res);
                    }
                    conn.Close();
                    return reserveringen;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Reservering>();
            }
        }

        public void Delete(Reservering reservering)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = "DELETE FROM dbo.reservering WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue(@"id", reservering.Id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}