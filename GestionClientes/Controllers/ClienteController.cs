using Microsoft.AspNetCore.Mvc;
using GestionClientes.LogicaNegocio.DTOs;
using GestionClientes.LogicaNegocio.Services;
using System.Collections.Generic;

namespace GestionClientes.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        // Inyección del servicio de lógica de negocio
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // 1. LISTADO DE CLIENTES
        public IActionResult Index()
        {
            var clientes = _clienteService.ObtenerTodosLosClientes();
            return View(clientes);
        }

        // 2. VER DETALLE DE UN CLIENTE
        public IActionResult Details(int id)
        {
            var cliente = _clienteService.ObtenerClientePorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // 3. REGISTRAR CLIENTE (Pantalla)
        public IActionResult Create()
        {
            // Enviamos un DTO vacío con un teléfono inicial para la vista dinámica
            var nuevoCliente = new ClienteDTO();
            nuevoCliente.Telefonos.Add(new TelefonoDTO { Tipo = "Celular" });
            return View(nuevoCliente);
        }

        // REGISTRAR CLIENTE (Procesar formulario)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteDTO clienteDto)
        {
            // Remover teléfonos vacíos enviados por el formulario antes de guardar
            clienteDto.Telefonos.RemoveAll(t => string.IsNullOrWhiteSpace(t.Numero));

            if (ModelState.IsValid)
            {
                _clienteService.GuardarCliente(clienteDto);
                return RedirectToAction(nameof(Index));
            }
            return View(clienteDto);
        }

        // 4. MODIFICAR CLIENTE (Pantalla)
        public IActionResult Edit(int id)
        {
            var cliente = _clienteService.ObtenerClientePorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // MODIFICAR CLIENTE (Procesar cambios)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClienteDTO clienteDto)
        {
            clienteDto.Telefonos.RemoveAll(t => string.IsNullOrWhiteSpace(t.Numero));

            if (ModelState.IsValid)
            {
                _clienteService.ActualizarCliente(clienteDto);
                return RedirectToAction(nameof(Index));
            }
            return View(clienteDto);
        }

        // 5. BORRAR CLIENTE
        public IActionResult Delete(int id)
        {
            var cliente = _clienteService.ObtenerClientePorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // BORRAR CLIENTE (Confirmación)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _clienteService.EliminarCliente(id);
            return RedirectToAction(nameof(Index));
        }
    }
}