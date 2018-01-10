using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using BiosManager.Database;
using BiosManager.Models;
using BiosManager.Repositories;

namespace BiosManager.Context.MSSQL
{
    public class MssqlReserveringContext : Database.Database, IReserveringContext
    {
        public void Insert(Reservering reservering)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                StoelRepository SRep = new StoelRepository(new MssqlStoelContext());
                conn.Open();
                string query = "INSERT INTO dbo.reservering (Stoel_ID, datum, prijs) VALUES (@stoel, @datum, @prijs)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@stoel", reservering.Stoelen);
                cmd.Parameters.AddWithValue("@datum", reservering.Voorstelling.Starttijd);
                cmd.Parameters.AddWithValue("@prijs", reservering.Prijs);
                cmd.ExecuteNonQuery();
                string query2 = "Select * FROM dbo.reservering";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                SqlDataReader reader = cmd2.ExecuteReader();
                List<int> IdList = new List<int>();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IdList.Add(reader.GetInt32(reader.GetOrdinal("ID")));

                    }
                }
                foreach (Stoel s in reservering.Voorstelling.Zl.Stoelen)
                {
                    SRep.UpdateStoel(s, IdList.Max());
                }
                conn.Close();
            }
        }

        public List<Reservering> Select(Account acc)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                VoorstellingRepository VRep = new VoorstellingRepository(new MssqlVoorstellingContext());

                conn.Open();
                string query = "SELECT * FROM dbo.reservering WHERE account_ID = @accId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("accId", acc.Id);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Reservering> reserveringen = new List<Reservering>();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Reservering res = new Reservering();
                        res.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                        res.Prijs = reader.GetSqlMoney(reader.GetOrdinal("prijs"));
                        res.Voorstelling = VRep.GetById(reader.GetInt32(reader.GetOrdinal("voorstelling_ID")));
                        reserveringen.Add(res);
                    }
                }
                cmd.ExecuteReader();
                return reserveringen;
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