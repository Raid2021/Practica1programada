using System;
using System.Collections.Generic;
using System.Text;

namespace GestionClientes.AccesoDatos.Entities
{
    public class Telefono
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; // Celular, Casa, Trabajo, etc.
        public int ClienteId { get; set; } // Llave foránea para ligarlo al cliente
    }
}
