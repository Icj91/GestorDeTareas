using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas.Application.DTOs
{
    internal class TareaLocalizadaDTO
    {
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Lugar { get; set; }
    }
}
