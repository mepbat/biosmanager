using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Models;
using BiosManager.Repositories;

namespace BiosManager.Context.MSSQL
{
    public class MssqlZaalContext : Database.Database, IZaalContext
    {

        public Zaal GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                StoelRepository SRep = new StoelRepository(new MssqlStoelContext());
                conn.Open();
                string query = "SELECT * FROM dbo.zaal WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("ID", id);
                SqlDataReader reader = cmd.ExecuteReader();
                Zaal z = new Zaal();
                while (reader.Read())
                {
                    z.Id = id;
                    z.Grootte = reader.GetInt32(reader.GetOrdinal("grootte"));
                    z.Nummer = reader.GetInt32(reader.GetOrdinal("nummer"));
                    z.Stoelen = SRep.GetByZaalId(reader.GetInt32(reader.GetOrdinal("ID")));
                }
                conn.Close();
                return z;
            }
        }

        public List<Zaal> Select()
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<Zaal> zalen = new List<Zaal>();
                    conn.Open();
                    string query = "SELECT * FROM dbo.zaal";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("ID"));
                        int nummer = reader.GetInt32(reader.GetOrdinal("nummer"));
                        int grootte = reader.GetInt32(reader.GetOrdinal("grootte"));

                        Zaal z = new Zaal(id, nummer, grootte);
                        zalen.Add(z);
                    }
                    conn.Close();
                    return zalen;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Zaal>();
            }
        }
    }
}