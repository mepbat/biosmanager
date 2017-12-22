using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BiosManager.Models;

namespace BiosManager.Context.MSSQL
{
    public class MssqlStoelContext : Database.Database, IStoelContext
    {
        public void Update(Stoel stoel, bool bezet)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = "UPDATE dbo.stoel (bezet) SET (@bezet) WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@bezet", bezet);
                cmd.Parameters.AddWithValue("@id", stoel.Id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Stoel> Select()
        {
            try
            {
                List<Stoel> stoelen = new List<Stoel>();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM dbo.stoel";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("ID"));
                        int rij = reader.GetInt32(reader.GetOrdinal("rij"));
                        int nummer = reader.GetInt32(reader.GetOrdinal("nummer"));
                        bool bezet = reader.GetBoolean(reader.GetOrdinal("bezet"));
                        int ResID = reader.GetInt32(reader.GetOrdinal("reservering_ID"));

                        Stoel s = new Stoel(id, rij, nummer, bezet);
                        stoelen.Add(s);
                    }
                    conn.Close();
                }
                return stoelen;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Stoel>();
            }
        }

    }
}