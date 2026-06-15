using System.Collections.Generic;
using System.Linq;
using GestionClientes.AccesoDatos.Entities;

namespace GestionClientes.AccesoDatos.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        // Lista estática que actuará como persistencia de datos durante la ejecución
        private static readonly List<Cliente> _clientes = new List<Cliente>();
        private static int _nextId = 1;

        public List<Cliente> ObtenerTodos()
        {
            return _clientes;
        }

        public Cliente? ObtenerPorId(int id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        public void Registrar(Cliente cliente)
        {
            cliente.Id = _nextId++;
            _clientes.Add(cliente);
        }

        public void Modificar(Cliente clienteModificado)
        {
            var cliente = ObtenerPorId(clienteModificado.Id);
            if (cliente != null)
            {
                cliente.Cedula = clienteModificado.Cedula;
                cliente.Nombre = clienteModificado.Nombre;
                cliente.Apellidos = clienteModificado.Apellidos;
                cliente.Telefonos = clienteModificado.Telefonos; // Actualiza la lista ligada de N teléfonos
            }
        }

        public void Borrar(int id)
        {
            var cliente = ObtenerPorId(id);
            if (cliente != null)
            {
                // Al remover al cliente de la lista, mueren sus teléfonos ligados automáticamente
                _clientes.Remove(cliente);
            }
        }
    }
}