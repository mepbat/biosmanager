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
        public void Update(Stoel stoel, int resId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "UPDATE dbo.stoel (reservering_ID, bezet) SET (@resId, @bezet) WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@resId", resId);
                cmd.Parameters.AddWithValue("@bezet", stoel.Bezet);
                cmd.Parameters.AddWithValue("@id", stoel.Id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Stoel> GetByZaalId(int id)
        {
            List<Stoel> stoelen = new List<Stoel>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                conn.Open();

                string query = "SELECT * FROM dbo.stoel WHERE Zaal_ID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                Stoel s = new Stoel();
                while (reader.Read())
                {
                    s.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                    s.Rij = reader.GetInt32(reader.GetOrdinal("rij"));
                    s.StoelNummer = reader.GetInt32(reader.GetOrdinal("stoelnummer"));
                    s.Bezet = reader.GetBoolean(reader.GetOrdinal("bezet"));
                    stoelen.Add(s);
                }
                conn.Close();
            }
            return stoelen;


        }
        
    }
}