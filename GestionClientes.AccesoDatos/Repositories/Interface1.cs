using System.Collections.Generic;
using GestionClientes.AccesoDatos.Entities;

namespace GestionClientes.AccesoDatos.Repositories
{
    public interface IClienteRepository
    {
        List<Cliente> ObtenerTodos();
        Cliente? ObtenerPorId(int id);
        void Registrar(Cliente cliente);
        void Modificar(Cliente cliente);
        void Borrar(int id);
    }
}