using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Libro
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public DateTime AnioPublicacion { get; private set; }
        public Autor Autor { get; private set; }
        public bool Disponible { get; private set; }

        //Traer información de base de datos
        public Libro(int id, string titulo, DateTime anio, Autor autor,  bool disponible)
        {
            Id = id;
            Titulo = titulo;
            AnioPublicacion = anio;
            Autor = autor;
            Disponible = disponible;
        }
        //Crear un nuevo libro
        public Libro(string titulo, DateTime anio, Autor autor)
        {
            Titulo = ValidarTitulo(titulo);
            AnioPublicacion = ValidarAnio(anio);
            Autor = ValidarAutor(autor);
            Disponible = true;
        }

        private string ValidarTitulo(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Error: el título no puede estar vacío");
            
            return value;
        }
        private DateTime ValidarAnio(DateTime anio)
        {
            if (anio == default)
                throw new Exception("Error: debe ingresar una fecha de publicación");

            if (anio > DateTime.Today)
                throw new Exception("Error: la fecha de publicación no puede ser futura");

            return anio;
        }
        private Autor ValidarAutor(Autor autor)
        {
            if (autor == null)
                throw new Exception("Error: autor vacío");
            return autor;
        }
        public void CambiarDisponibilidad(bool estado)
        {
            Disponible = estado;
        }
    }
}
