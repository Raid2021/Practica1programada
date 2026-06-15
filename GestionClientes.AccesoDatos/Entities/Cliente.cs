using System.Collections.Generic;

namespace GestionClientes.AccesoDatos.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;

        // Relación requerida: Un cliente puede tener N números de teléfono
        public List<Telefono> Telefonos { get; set; } = new List<Telefono>();
    }
}