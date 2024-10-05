using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParcialApp.Data;
using ParcialApp.Models;

namespace ParcialApp.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly ILogger<TransaccionesController> _logger;
        private readonly ApplicationDbContext _context; // Inyección del contexto de la base de datos

        // Constructor que inyecta el logger y el ApplicationDbContext
        public TransaccionesController(ILogger<TransaccionesController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Asignación del contexto de la base de datos
        }

        // GET: Mostrar formulario para registrar una transacción
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        // POST: Procesar los datos del formulario y registrar la transacción
        [HttpPost]
        public IActionResult Registrar(Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                // Agregar la nueva transacción a la base de datos
                _context.Transacciones.Add(transaccion);
                _context.SaveChanges(); // Guardar los cambios en la base de datos
                return RedirectToAction("Listado"); // Redirigir a la vista de listado de transacciones
            }
            // Si el modelo no es válido, regresar a la vista del formulario con los errores
            return View(transaccion);
        }

        // Método para listar las transacciones (puedes crear la vista correspondiente)
        public IActionResult Listado()
        {
            var transacciones = _context.Transacciones.ToList(); // Obtener las transacciones de la base de datos
            return View(transacciones); // Pasar los datos a la vista
        }

        // Manejo de errores
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}