using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Models;

namespace BiosManager.Context.MSSQL
{
    public class MssqlZaalContext : Database.Database, IZaalContext
    {
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