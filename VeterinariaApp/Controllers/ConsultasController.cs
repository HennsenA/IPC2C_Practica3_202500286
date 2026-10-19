using Microsoft.AspNetCore.Mvc;
using VeterinariaApp.Models;

namespace VeterinariaApp.Controllers
{
    public class ConsultasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Registro")]//Metodo para registrar un paciente
        public IActionResult Registro(Mascota mascota)
        {
            if (mascota == null)
            {
                return BadRequest("El objeto mascota no puede ser nulo.");
            }

            if (string.IsNullOrEmpty(mascota.nombre) || string.IsNullOrEmpty(mascota.estado) || string.IsNullOrEmpty(mascota.propietario))
            {
                return BadRequest("Los campos Nombre, Estado y Propietario son obligatorios.");
            }

            // Lógica para registrar la mascota en la lista
            Lista lista = new Lista();
            lista.Insertar(mascota);

            return Ok("Mascota registrada exitosamente.");
        }

        [HttpDelete("Eliminar")]//Metodo para eliminar un paciente
        public IActionResult Eliminar(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return BadRequest("El código no puede ser nulo o vacío.");
            }

            // Lógica para eliminar la mascota de la lista
            Lista lista = new Lista();
            lista.Eliminar(codigo);

            return Ok("Mascota eliminada exitosamente.");
        }

        [HttpGet("Buscar")]//Metodo para buscar un paciente
        public IActionResult Buscar(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return BadRequest("El código no puede ser nulo o vacío.");
            }

            // Lógica para buscar la mascota en la lista
            Lista lista = new Lista();
            NodoLista nodoEncontrado = lista.Buscar(codigo);

            if (nodoEncontrado == null)
            {
                return NotFound("Mascota no encontrada.");
            }

            return Ok(nodoEncontrado.Paciente);
        }

        
    }
}