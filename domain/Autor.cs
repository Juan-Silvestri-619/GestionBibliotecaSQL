using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Autor
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Pais { get; private set; }
        public bool Activo { get; private set; }

        //Traer información de la base de datos
        public Autor(int id, string nombre, string pais, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Pais = pais;
            Activo = activo;
        }
        //Crear un nuevo autor
        public Autor(string nombre, string pais)
        {
            Nombre = ValidarTexto(nombre);
            Pais = ValidarTexto(pais);
            Activo = true;
        }
        private string ValidarTexto(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Error: no puede estar vacío el contenido");
            return value;
        }
        public void CambiarEstado(bool estado)
        {
            Activo = estado;
        }
    }
}
