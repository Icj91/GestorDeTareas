using GestorDeTareas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas.Domain.Entities
{
    public class TareaConPlazo:Tarea
    {
        public DateTime FechaVencimiento { get; set; }

        public TareaConPlazo(string titulo,DateTime fechaVencimiento):base(titulo)
        {
            if (fechaVencimiento <= FechaCreacion)
            {
                throw new ArgumentException("Fecha fuera de rango");
            }
            FechaVencimiento = fechaVencimiento;
        }

        public void CambiarPlazoVencimiento(DateTime nuevaFechaVencimiento)
        {

            if (nuevaFechaVencimiento < FechaCreacion)
            {
                throw new ArgumentException("Fecha fuera de rango");
            }

            FechaVencimiento = nuevaFechaVencimiento;
        }

        //virtualizamos y añadimos si esta cancelada o completada segun plazo presentacion
        public override void PresentarTarea(DateTime fechaPresentacion) {

            if (fechaPresentacion <= FechaCreacion)
            {
                throw new ArgumentException("No puede ser menor que la creacion");

            }
            FechaPresentacion = fechaPresentacion;

            if (FechaPresentacion > FechaVencimiento)
            {
                Estado = EstadoTarea.Cancelada;
            }
            else {
                Estado = EstadoTarea.Completada;            
            }
        }

        public override void ObtenerDatos()
        {
            if (Estado==EstadoTarea.Completada || Estado==EstadoTarea.Cancelada) { 
                Console.WriteLine($"\nTarea:{Titulo} con fecha creacion:{FechaCreacion} \nfecha de vencimiento: {FechaVencimiento}" +
                    $"\nPresentada: {FechaPresentacion}\nEstado: {Estado}");
            }
            else
            {
                Console.WriteLine($"\nTarea:{Titulo} con fecha creacion:{FechaCreacion} \nfecha de vencimiento: {FechaVencimiento}");

            }

            
        }

        

    }
}
