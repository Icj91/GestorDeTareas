using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas
{
    public abstract class Tarea
    {
        public int TareaId { get;  }
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; }
        
        public EstadoTarea Estado { get; set; }

        public Tarea(string titulo)
        {
            FechaCreacion = DateTime.Now;
            

            TareaId = Guid.NewGuid().GetHashCode(); // Genera un ID único para cada tarea
            Titulo = titulo;
            Estado = EstadoTarea.Pendiente;


        }

        public void EditarTituloTarea(string nuevoTitulo) => Titulo = nuevoTitulo;
       

        public void CambiarEstado(EstadoTarea nuevoEstado)
        {
            Estado = nuevoEstado;
        }
        public abstract void ObtenerDatos();

    }
}
