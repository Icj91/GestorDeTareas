using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas
{
    public class TareaDto
    {
        
        public int TareaId { get; set; }
        public string? Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public EstadoTarea Estado { get; set; }
        public DateTime FechaPresentacion { get; set; }


        //propiedad de tarea localizada
        public string Lugar { get; set; }

        //propiedad de tarea subtarea
        public List<string> ListaSubTareas { get; set; }

        //propiedad de tarea con plazo
        private DateTime FechaVencimiento { get; set; }
    }
}
