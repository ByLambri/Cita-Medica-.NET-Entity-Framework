using citamedica.Model;
using citamedica.Repository;
using citamedica.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace citamedica.Controllers
{
    [ApiController]
    [Route("pacientes")]
    public class PacienteController : Controller
    {
        

        private readonly IPacienteRepository paciienteRepository;

        private readonly PacienteService paciienteService;

        public PacienteController( IPacienteRepository pacienteRepository, PacienteService pacienteService) 
        {

            this.paciienteRepository = pacienteRepository;
            this.paciienteService = pacienteService;
        }


        [HttpGet("getPacientes")]
        public ActionResult<List<Paciente>> getAll()
        {
            var pacientes = paciienteService.GetAll();

            if (pacientes == null || pacientes.Count == 0)
            {
                return NotFound("No se encontraron pacientes.");
            }

            return Ok(pacientes);
        }

        [HttpPost("addPaciente")]
        public IActionResult AddPaciente([FromBody] Paciente paciente)
        {
            try
            {
                paciienteService.Añadir(paciente);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"El paciente {paciente.nombre} ha sido añadido correctamente.");
        }

        [HttpPut("updatePaciente")]
        public IActionResult UpdatePaciente([FromBody] Paciente paciente)
        {
            try
            {
                paciienteService.Update(paciente);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"El paciente {paciente.nombre} ha sido actualizado correctamente.");
        }

        [HttpDelete("deletePaciente")]
        public IActionResult deletePaciente(long id)
        {
            var paciente = paciienteService.GetById(id);

            if (paciente == null)
            {
                return NotFound();
            }

            try
            {
                paciienteService.DeleteById(id);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"El paciente con id {id} ha sido borrado correctamente.");
        }
    }
}
