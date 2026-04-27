using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool EsAdmin { get; set; }

    }
}
