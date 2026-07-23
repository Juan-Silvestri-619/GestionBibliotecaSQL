using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace dal.Implementations.SqlServer
{
    public class AutorRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["connSqlServer"].ConnectionString;

        public List<Autor> GetAllAuthors()
        {
            List<Autor> autores = new List<Autor>();

            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM autor";

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Autor autor = new Autor(
                                Convert.ToInt32(reader["id"]),
                                reader["nombre"].ToString(),
                                reader["pais"].ToString(),
                                Convert.ToBoolean(reader["activo"])
                                );

                            autores.Add(autor);
                            
                        }
                    }
                }
                return autores;
            }
        }
        public Autor GetById(int id) 
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, nombre, pais, activo " +
                        "FROM autor " +
                        "WHERE id=@id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Autor(
                                Convert.ToInt32(reader["id"]),
                                reader["nombre"].ToString(),
                                reader["pais"].ToString(),
                                Convert.ToBoolean(reader["activo"])
                                );
                        }
                    }
                }
            }
            return null;
        }
        public void AddAuthor(Autor autor)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO autor(nombre, pais) " +
                        "VALUES(@nombre, @pais)";

                    cmd.Parameters.AddWithValue("@nombre", autor.Nombre);
                    cmd.Parameters.Add("@pais", SqlDbType.VarChar, 50).Value = autor.Pais;

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateAuthor(Autor autor)
        {
            using(SqlConnection conn =new SqlConnection(_connectionString))
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE autor " +
                        "SET nombre=@nombre, pais=@pais " +
                        "WHERE id=@id;";

                    cmd.Parameters.AddWithValue("@id", autor.Id);
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = autor.Nombre;
                    cmd.Parameters.Add("@pais", SqlDbType.VarChar, 50).Value = autor.Pais;

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateActive(Autor autor)
        {
            using(SqlConnection conn =new SqlConnection(_connectionString))
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE autor " +
                        "SET activo=@activo " +
                        "WHERE id=@id";

                    cmd.Parameters.AddWithValue("@id", autor.Id);
                    cmd.Parameters.AddWithValue("@activo", autor.Activo);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteAuthor(int id)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE " +
                        "FROM autor " +
                        "WHERE id=@id";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
