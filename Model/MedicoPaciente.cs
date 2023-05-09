using System.ComponentModel.DataAnnotations;

namespace citamedica.Model
{
    public class MedicoPaciente
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public long MedicoId { get; set; }
        public virtual Medico Medico { get; set; }

        [Required]
        public long PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }


    }
}
