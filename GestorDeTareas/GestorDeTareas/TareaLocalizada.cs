using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas
{
    public class TareaLocalizada : Tarea
    {
        public string Lugar { get; set; }

        public TareaLocalizada(string titulo, string lugar):base(titulo)
        {
            //España no deja
            if (lugar == "España")
            {
                throw new ArgumentException("España no esta permitido");

            }
            Lugar = lugar;
        }
        public void CambiarRegion(string lugar){
            if (lugar == "España")
            {
                throw new ArgumentException("España no esta permitido");

            }
            Lugar = lugar;
        }

        public override void ObtenerDatos()
        {
            Console.WriteLine($"\nTarea:{Titulo} con fecha creacion:{FechaCreacion} \nEstado: {Estado}\nLugar: {Lugar}");
        }
    }
}
