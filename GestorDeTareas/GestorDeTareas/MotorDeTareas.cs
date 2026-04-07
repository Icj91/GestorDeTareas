using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas
{
    public class MotorDeTareas
    {
        public void MostrarTodaInformacion(List<Tarea>listaTarea) {

            foreach (var tarea in listaTarea) {
                tarea.ObtenerDatos();
            
            }
        }

    }
}
