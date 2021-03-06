﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Database;
using BiosManager.Models;

namespace BiosManager.Context.MSSQL
{
    public class MssqlFilmContext : Database.Database, IFilmContext
    {
        public void Insert(Film film)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = "INSERT INTO dbo.film (naam, beschrijving, lengte, rating) VALUES (@naam, @beschrijving, @lengte, @rating)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@naam", film.Naam);
                cmd.Parameters.AddWithValue("@beschrijving", film.Beschrijving);
                cmd.Parameters.AddWithValue("@lengte", film.Lengte);
                cmd.Parameters.AddWithValue("@rating", film.Rating);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Film> Select()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<Film> films = new List<Film>();
                    conn.Open();
                    string query = "SELECT * FROM dbo.film";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("ID"));
                        string naam = reader.GetString(reader.GetOrdinal("naam"));
                        string genres = reader.GetString(reader.GetOrdinal("genre"));
                        string beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
                        int lengte = reader.GetInt32(reader.GetOrdinal("lengte"));
                        decimal rating = reader.GetDecimal(reader.GetOrdinal("rating"));
                        int jaar = reader.GetInt32(reader.GetOrdinal("jaar"));

                        Film f = new Film(id, naam, beschrijving, genres, lengte, rating, jaar);

                        films.Add(f);
                    }
                    conn.Close();
                    return films;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Film>();
            }
        }

        public Film GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM dbo.film WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("ID", id);
                SqlDataReader reader = cmd.ExecuteReader();
                Film f = new Film();
                while (reader.Read())
                {
                    f.Naam = reader.GetString(reader.GetOrdinal("naam"));
                    f.Genres = reader.GetString(reader.GetOrdinal("genre"));
                    f.Beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
                    f.Lengte = reader.GetInt32(reader.GetOrdinal("lengte"));
                    f.Rating = reader.GetDecimal(reader.GetOrdinal("rating"));
                    f.Jaar = reader.GetInt32(reader.GetOrdinal("jaar"));
                    f.Id = id;
                }
                conn.Close();
                return f;
            }
        }

        public void Delete(Film film)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM dbo.film WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue(@"id", film.Id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}