using System.Runtime.InteropServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace citamedica.Model
{
    [Table("diagnosticos")]
    public class Diagnostico
    {
        [Key]
        public long id_Diagnostico { get; set; }

        [Required]
        public String valoracionEspecialista { get; set; }

        [Required]
        public String enfermedad { get; set; }

        public long CitaId { get; set; }

        public Cita cita;

        public Diagnostico(long id, string valoracionEspecialista, string enfermedad, long citaId)
        {
            id_Diagnostico = id;
            this.valoracionEspecialista = valoracionEspecialista;
            this.enfermedad = enfermedad;
            CitaId = citaId;
        }
    }
}
