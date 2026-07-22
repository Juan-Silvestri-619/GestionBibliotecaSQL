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
    public class AutorRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["connSqlServer"].ConnectionString;

        public List<Autor> GetAllAuthor()
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
    }
}
