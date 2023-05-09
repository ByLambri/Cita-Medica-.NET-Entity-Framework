using citamedica.Model;
using citamedica.Repository;
using citamedica.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace citamedica.Controllers
{
    [ApiController]
    [Route("medicos")]
    public class MedicoController : Controller
    {
        private readonly dbContex db;

        private readonly IMedicoRepository mediicoRepository;

        private readonly MedicoService mediicoService;
        public MedicoController(dbContex db, IMedicoRepository medicoRepository, MedicoService medicoService)
        {
            this.db = db;
            this.mediicoRepository = medicoRepository;
            this.mediicoService = medicoService;
        }

        [HttpGet("getMedicos")]
        public ActionResult<List<Medico>> getAll()
        {
            
            return  mediicoService.GetAll();
        }


        [HttpPost("addMedicos")]
        public IActionResult AddMedico([FromBody] Medico medico)
        {
            try
            {
                mediicoService.Añadir(medico);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"El medico {medico.nombre} ha sido añadido correctamente.");
        }

        //[HttpPost("addMedicos")]
        //public ActionResult<Medico> addMedico(Medico medico)
        //{

        //    //.Medicos.Add(medico);
        //    //.SaveChanges();

        //    try
        //    {
        //        mediicoService.Añadir(medico);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    return Ok($"El medico {medico.nombre} ha sido añadido correctamente.");
        //}

        [HttpPut("updateMedico")]
        public IActionResult UpdateMedico([FromBody] Medico medico)
        {
            try
            {
                mediicoService.Update(medico);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"El medico {medico.nombre} ha sido actualizado correctamente.");
        }


        [HttpDelete("deleteMedico")]
        public IActionResult deleteMedico(long id)
        {
            var medico = mediicoService.GetById(id);

            if (medico == null)
            {
                return NotFound();
            }

            try
            {
                mediicoService.DeleteById(id);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"El medico con id {id} ha sido borrado correctamente.");
        }
    }
}
