using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace citamedica.Model
{
    [Table("medicos")]
    public class Medico : Usuario
    {
        

        public Medico()
        {
        }

        [Required]
        public String numColegiado { get; set; }

        private IList<MedicoPaciente>? pacientes;

        public virtual IList<MedicoPaciente> Pacientes { get; set; }

        public virtual IList<Cita> Citas { get; set; }

    }
}
