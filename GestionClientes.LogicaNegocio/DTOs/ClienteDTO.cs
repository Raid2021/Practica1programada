using System.Collections.Generic;

namespace GestionClientes.LogicaNegocio.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;

        // El DTO expone los teléfonos mapeados de la entidad original
        public List<TelefonoDTO> Telefonos { get; set; } = new List<TelefonoDTO>();
    }
}