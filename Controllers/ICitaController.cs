using citamedica.Model;
using Microsoft.AspNetCore.Mvc;

namespace citamedica.Controllers
{
    public interface ICitaController
    {
        IActionResult AddPaciente([FromBody] Diagnostico diagnostico);
        IActionResult AddPaciente([FromBody] Diagnostico diagnostico);
        IActionResult deletePaciente(long id);
        IActionResult deletePaciente(long id);
        ActionResult<List<Diagnostico>> getAll();
        ActionResult<List<Diagnostico>> getAll();
        IActionResult UpdateDiagnostico([FromBody] Diagnostico diagnostico);
        IActionResult UpdateDiagnostico([FromBody] Diagnostico diagnostico);
    }
}