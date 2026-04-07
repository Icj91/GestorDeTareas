using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas
{
    public class TareaConSubtarea : Tarea
    {
        public List<string> ListaSubTareas { get; set; }
        public TareaConSubtarea(string titulo) : base(titulo)
        {
            ListaSubTareas = new();
        }

        public void AñadirSubTarea(string subTarea) {
            
            ListaSubTareas.Add(subTarea);
        }

 
        public override void ObtenerDatos()
        {
            Console.WriteLine($"\nTarea:{Titulo} con fecha creacion:{FechaCreacion} \nTiene estas subtareas: ");
            foreach (var subT in ListaSubTareas)
            {
                Console.WriteLine(subT);
            }
        }
    }
}
