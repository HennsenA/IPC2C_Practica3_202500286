using Microsoft.AspNetCore.Mvc;
using VeterinariaApp.Models;

namespace VeterinariaApp.Controllers
{
    public class ConsultasController : Controller
    {
        private Lista lista;
        public IActionResult Index()
        {
            return View();
        }
        public ConsultasController(Lista Lista)
        {
            lista = Lista;
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
            lista.Eliminar(codigo);

            return Ok("Mascota eliminada exitosamente.");
        }

        [HttpGet("Buscar")]//Metodo para buscar un paciente individual
        public IActionResult Buscar(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return BadRequest("El código no puede ser nulo o vacío.");
            }

            // Lógica para buscar la mascota en la lista
            NodoLista nodoEncontrado = lista.Buscar(codigo);

            if (nodoEncontrado == null)
            {
                return NotFound("Mascota no encontrada.");
            }

            return Ok(nodoEncontrado.Paciente);
        }

        [HttpGet("Lista")]//Metodo para mostrar la lista de pacientes
        public IActionResult Lista()
        {
            string ListaPacientes = lista.ImprimirLista();

            if(ListaPacientes == null || ListaPacientes.Equals(""))
            {
                return NotFound("La lista esta vacia");
            }

            return Ok(ListaPacientes);
        }

        [HttpPatch("Editar")]//Actualizar informacion de un paciente
        public IActionResult Editar(string codigo, string nombre, double peso, string sexo, int edad, string propietario)
        {
            bool estado = lista.EditarInfo(codigo, nombre, peso, sexo, edad, propietario);
            if (!estado)
            {
                return NotFound("No se encontro el paciente");
            }

            return Ok();
        }

        [HttpPut("CambiarEstado")]//Cambiar el estado de sano a enfermo o viceversa
        public IActionResult CambiarEstado(string codigo)
        {
            bool estado = lista.CambiarEstado(codigo);
            if (!estado)
            {
                return NotFound("No se encontro el paciente");
            }
            
            return Ok();
        }

        [HttpPatch("CalcularDosis")]
        public IActionResult CalcularDosis(string codigo, double dosis_por_kg)
        {
            Mascota paciente = lista.Buscar(codigo).Paciente;
            double dosis = paciente.CalculoDosis(dosis_por_kg);
            return Ok(dosis);
        }
    }
}