using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace citamedica.Model
{
    [Table("pacientes")]
    public class Paciente : Usuario
    {

        [Required]
        public String NSS { get; set; }

        [Required]
        public String numTarjeta { get; set; }

        [Required]
        public String telefono { get; set; }

        [Required]
        public String direccion { get; set; }

        public virtual IList<MedicoPaciente> Medicos { get; set; }

        public virtual IList<Cita> Citas { get; set; }
    }
}
