using citamedica.Model;
using citamedica.Repository;
using citamedica.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace citamedica.Controllers
{
    public class DiagnosticoController : Controller
    {
        private readonly IDiagnosticoRepository diiagnosticoRepository;

        private readonly DiagnosticoService diiagnosticoService;

        public DiagnosticoController(IDiagnosticoRepository diagnosticoRepository, DiagnosticoService diagnosticoService)
        {

            this.diiagnosticoRepository = diagnosticoRepository;
            this.diiagnosticoService = diagnosticoService;
        }


        [HttpGet("getDiagnostico")]
        public ActionResult<List<Diagnostico>> getAll()
        {
            var diagnostico = diiagnosticoService.GetAll();

            if (diagnostico == null || diagnostico.Count == 0)
            {
                return NotFound("No se encontraron diagnosticos.");
            }

            return Ok(diagnostico);
        }

        [HttpPost("addDiagnostico")]
        public IActionResult AddPaciente([FromBody] Diagnostico diagnostico)
        {
            try
            {
                diiagnosticoService.Añadir(diagnostico);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("El diagnostico ha sido añadido correctamente.");
        }

        [HttpPut("updateDiagnostico")]
        public IActionResult UpdateDiagnostico([FromBody] Diagnostico diagnostico)
        {
            try
            {
                diiagnosticoService.Update(diagnostico);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("El diagnostico ha sido actualizado correctamente.");
        }

        [HttpDelete("deleteDiagnostico")]
        public IActionResult deletePaciente(long id)
        {
            var diagnostico = diiagnosticoService.GetById(id);

            if (diagnostico == null)
            {
                return NotFound();
            }

            try
            {
                diiagnosticoService.DeleteById(id);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"El diagnostico con id {id} ha sido borrado correctamente.");
        }
    }
}
