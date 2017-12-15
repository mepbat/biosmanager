using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Models;
using BiosManager.Database;


namespace BiosManager.Context.MSSQL
{
    public class MssqlAccountContext : Database.Database , IAccountContext
    {
        public void Insert(Account account)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO dbo.account (email, wachtwoord, admin) VALUES (@email, @wachtwoord, @admin)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", account.Email);
                    cmd.Parameters.AddWithValue("@wachtwoord", account.Wachtwoord);
                    cmd.Parameters.AddWithValue("@admin", account.Admin);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

        }

        public List<Account> Select()
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<Account> accounts = new List<Account>();
                    conn.Open();
                    string query = "SELECT * FROM dbo.account";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("ID"));
                        string email = reader.GetString(reader.GetOrdinal("email"));
                        string wachtwoord = reader.GetString(reader.GetOrdinal("wachtwoord"));
                        bool admin = reader.GetBoolean(reader.GetOrdinal("admin"));

                        Account acc = new Account
                        {
                            Id = id,
                            Email = email,
                            Wachtwoord = wachtwoord,
                            Admin = admin
                        };
                        accounts.Add(acc);
                    }
                    conn.Close();
                    return accounts;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Account>();
            }
        }

        public void Update(Account account, string nieuwWachtwoord)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE dbo.account (wachtwoord) SET (@nieuwwachtwoord) WHERE id = (@id)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nieuwwachtwoord", nieuwWachtwoord);
                    cmd.Parameters.AddWithValue("@id", account.Id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

        }
    }
}