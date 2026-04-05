using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas
{
    public class Tarea
    {
        public int TareaId { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public EstadoTarea Estado { get; set; } 

        public Tarea(string titulo,DateTime fechaVencimiento)
        {
            TareaId = Guid.NewGuid().GetHashCode(); // Genera un ID único para cada tarea
            Titulo = titulo;
            Estado=EstadoTarea.Pendiente; 
            FechaCreacion = DateTime.Now;
            FechaVencimiento = fechaVencimiento;


        }

        public void EditarTarea(string nuevoTitulo, DateTime nuevaFechaVencimiento)
        {
            Titulo = nuevoTitulo;
            FechaVencimiento = nuevaFechaVencimiento;
        }

        public void CambiarEstado(EstadoTarea nuevoEstado)
        {
            Estado = nuevoEstado;
        }
         public override string ToString()
        {
            return $"ID: {TareaId}, Título: {Titulo}, Estado: {Estado}, Fecha de Creación: {FechaCreacion}, Fecha de Vencimiento: {FechaVencimiento}";
        }

    }
}
