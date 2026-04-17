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
    }
}
