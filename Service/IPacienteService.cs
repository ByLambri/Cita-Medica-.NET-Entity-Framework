using citamedica.Model;

namespace citamedica.Service
{
    public interface IPacienteService
    {
        public List<Paciente> GetAll();

        public void Añadir(Paciente paciente);

        public Paciente GetById(long id);

        public void Update(Paciente paciente);

        public void DeleteById(long id);

    }
}
