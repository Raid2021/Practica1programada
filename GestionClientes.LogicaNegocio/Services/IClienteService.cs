using System.Collections.Generic;
using GestionClientes.LogicaNegocio.DTOs;

namespace GestionClientes.LogicaNegocio.Services
{
    public interface IClienteService
    {
        List<ClienteDTO> ObtenerTodosLosClientes();
        ClienteDTO? ObtenerClientePorId(int id);
        void GuardarCliente(ClienteDTO clienteDto);
        void ActualizarCliente(ClienteDTO clienteDto);
        void EliminarCliente(int id);
    }
}