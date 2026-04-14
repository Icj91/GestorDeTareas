using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas
{
    public abstract class Tarea
    {
        public int TareaId { get; }
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; }
        public EstadoTarea Estado { get; set; }
        public DateTime FechaPresentacion { get; set; }

        public Tarea(string titulo)
        {
            FechaCreacion = DateTime.Now;


            TareaId = Guid.NewGuid().GetHashCode(); // Genera un ID único para cada tarea
            Titulo = titulo;
            Estado = EstadoTarea.Pendiente;

        }

        

        public void EditarTituloTarea(string nuevoTitulo) => Titulo = nuevoTitulo;

        //pasa a completada una vez presentada
        public virtual void PresentarTarea(DateTime fechaPresentacion)
        {
            if (fechaPresentacion <= FechaCreacion) {
                throw new ArgumentException("No puede ser menor que la creacion");

            } 
            FechaPresentacion = fechaPresentacion;
            Estado = EstadoTarea.Completada;

        }
        
        public abstract void ObtenerDatos();

    }
}
