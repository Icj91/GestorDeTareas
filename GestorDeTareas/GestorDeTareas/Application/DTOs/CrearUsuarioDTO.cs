using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas.Application.DTOs
{
    public class CrearUsuarioDTO
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool EsAdmin { get; set; }
    }
}
