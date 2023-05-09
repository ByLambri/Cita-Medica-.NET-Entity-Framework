using citamedica.Model;


namespace citamedica.DTO
{
    public class MedicoDTO
    {
        public MedicoDTO()
        {
        }

        public MedicoDTO(string numColegiado, List<Paciente> pacientes)
        {
            this.numColegiado = numColegiado;
            this.pacientes = pacientes;
        }

        public MedicoDTO(long id_usuario, string usuario, string nombre, string apellidos, string clave, String numColegiado)
        {
        }

   
        public String numColegiado { get; set; }

        public virtual List<Paciente> pacientes { get; set; }

        


    }
}
