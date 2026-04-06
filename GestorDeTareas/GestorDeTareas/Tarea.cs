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

        public Tarea(string titulo, DateTime fechaVencimiento)
        {
            FechaCreacion = DateTime.Now;
            if (fechaVencimiento <= FechaCreacion)
            {
                throw new ArgumentException("Fecha fuera de rango");
            }

            TareaId = Guid.NewGuid().GetHashCode(); // Genera un ID único para cada tarea
            Titulo = titulo;
            Estado = EstadoTarea.Pendiente;

            FechaVencimiento = fechaVencimiento;

        }

        public void EditarTarea(string nuevoTitulo, DateTime nuevaFechaVencimiento)
        {

            Titulo = nuevoTitulo;
            if (nuevaFechaVencimiento < FechaCreacion) {
                throw new ArgumentException("Fecha fuera de rango");
            }

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
