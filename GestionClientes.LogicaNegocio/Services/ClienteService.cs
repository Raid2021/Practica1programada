using System.Collections.Generic;
using System.Linq;
using GestionClientes.AccesoDatos.Entities;
using GestionClientes.AccesoDatos.Repositories;
using GestionClientes.LogicaNegocio.DTOs;

namespace GestionClientes.LogicaNegocio.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        // Inyección de dependencias del repositorio de datos
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<ClienteDTO> ObtenerTodosLosClientes()
        {
            var clientesEntidad = _clienteRepository.ObtenerTodos();

            // Mapeo manual de Entidad a DTO
            return clientesEntidad.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Cedula = c.Cedula,
                Nombre = c.Nombre,
                Apellidos = c.Apellidos,
                Telefonos = c.Telefonos.Select(t => new TelefonoDTO
                {
                    Id = t.Id,
                    Numero = t.Numero,
                    Tipo = t.Tipo
                }).ToList()
            }).ToList();
        }

        public ClienteDTO? ObtenerClientePorId(int id)
        {
            var c = _clienteRepository.ObtenerPorId(id);
            if (c == null) return null;

            return new ClienteDTO
            {
                Id = c.Id,
                Cedula = c.Cedula,
                Nombre = c.Nombre,
                Apellidos = c.Apellidos,
                Telefonos = c.Telefonos.Select(t => new TelefonoDTO
                {
                    Id = t.Id,
                    Numero = t.Numero,
                    Tipo = t.Tipo
                }).ToList()
            };
        }

        public void GuardarCliente(ClienteDTO clienteDto)
        {
            var nuevoCliente = new Cliente
            {
                Cedula = clienteDto.Cedula,
                Nombre = clienteDto.Nombre,
                Apellidos = clienteDto.Apellidos,
                Telefonos = clienteDto.Telefonos.Select(t => new Telefono
                {
                    Numero = t.Numero,
                    Tipo = t.Tipo
                }).ToList()
            };

            _clienteRepository.Registrar(nuevoCliente);
        }

        public void ActualizarCliente(ClienteDTO clienteDto)
        {
            var clienteModificado = new Cliente
            {
                Id = clienteDto.Id,
                Cedula = clienteDto.Cedula,
                Nombre = clienteDto.Nombre,
                Apellidos = clienteDto.Apellidos,
                Telefonos = clienteDto.Telefonos.Select(t => new Telefono
                {
                    Id = t.Id,
                    ClienteId = clienteDto.Id,
                    Numero = t.Numero,
                    Tipo = t.Tipo
                }).ToList()
            };

            _clienteRepository.Modificar(clienteModificado);
        }

        public void EliminarCliente(int id)
        {
            _clienteRepository.Borrar(id);
        }
    }
}