using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace citamedica.Model
{
    [Table ("citas")]
    public class Cita
    {
        

        [Key]
        public long id_cita {  get; set; }

        [Required]
        public DateTime fechaHora { get; set; }

        [Required]
        public String motivoCita { get; set; }

        public long MedicoId { get; set; }

        public virtual Medico Medico { get; set; }

        public long PacienteId { get; set; }

        public virtual Paciente Paciente { get; set; }

        public Diagnostico? Diagnostico;
    }
}
