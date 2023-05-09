using System.ComponentModel.DataAnnotations;

namespace citamedica.DTO
{
    public class DiagnosticoDTO
    {

        
        public long id_Diagnostico { get; set; }

        public String valoracionEspecialista { get; set; }

        public String enfermedad { get; set; }
    }
}
