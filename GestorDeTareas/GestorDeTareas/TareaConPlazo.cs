using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas
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

        public override void ObtenerDatos()
        {
            Console.WriteLine($"Tarea:{Titulo} con fecha creacion:{FechaCreacion} \nfecha de vencimiento: {FechaVencimiento}");
        }
    }
}
