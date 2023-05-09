using citamedica.Model;

namespace citamedica.Repository
{
    public interface IPacienteRepository
    {

        public List<Paciente> GetAll();

        public void Añadir(Paciente paciente);

        public Paciente GetById(long id);

        public void Update(Paciente paciente);

        public void DeleteById(long id);
    }
}
