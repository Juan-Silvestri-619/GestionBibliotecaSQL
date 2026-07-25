using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace dal.Implementations.SqlServer
{
    public class LibroRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["connSqlServer"].ConnectionString;

        public List<Libro> GetAllBooks()
        {
            List<Libro> books = new List<Libro>();

            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT l.id, l.titulo, l.anioPublicacion, l.disponible , a.nombre " +
                        "FROM libro l " +
                        "INNER JOIN autor a " +
                        "ON a.id = l.autorId;";

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Autor author = new Autor(
                                reader["nombre"].ToString()
                            );

                            Libro book = new Libro(
                                Convert.ToInt32(reader["id"]),
                                reader["titulo"].ToString(),
                                Convert.ToDateTime(reader["anioPublicacion"]),
                                author,
                                Convert.ToBoolean(reader["disponible"])
                            );

                            books.Add(book);
                        }
                    }
                }
            }
            return books;
        }
    }
}
