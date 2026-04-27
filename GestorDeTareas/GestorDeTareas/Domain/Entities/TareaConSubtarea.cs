using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas.Domain.Entities
{
    public class TareaConSubtarea : Tarea
    {
        public List<string> ListaSubTareas { get; set; }
       

        public TareaConSubtarea(string titulo) : base(titulo)
        {
            ListaSubTareas = new();
        }

        public void AnadirSubTarea(string subTarea) {
            //validar no hay tareas repetidas
            foreach (var tarea in ListaSubTareas)
            {
                if (tarea == subTarea)
                {
                    throw new ArgumentException($"la tarea: '{tarea}' está repetida");
                }
            }
            ListaSubTareas.Add(subTarea);
        }

 
        public override void ObtenerDatos()
        {
            Console.WriteLine($"\nTarea:{Titulo} con fecha creacion:{FechaCreacion} \nEstado: {Estado}\nTiene estas subtareas: ");
            foreach (var subT in ListaSubTareas)
            {
                Console.WriteLine(subT);
            }
        }
    }
}
