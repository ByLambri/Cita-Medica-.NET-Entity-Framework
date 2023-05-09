using citamedica.DTO;
using citamedica.Model;
using citamedica.Repository;

namespace citamedica.Service
{
    public class MedicoService : IMedicoService
    {
        private readonly dbContex db;

        private readonly IMedicoRepository _medicoRepository;

        private readonly IPacienteRepository _pacienteRepository;

        public MedicoService(IMedicoRepository medicoRepository, IPacienteRepository pacienteRepository)
        {
            this._medicoRepository = medicoRepository;

            this._pacienteRepository = pacienteRepository;
        }

        public void Añadir(Medico medico)
        {
            var nuevoMedico = new Medico
            {

                numColegiado = medico.numColegiado,
                usuario = medico.usuario,
                nombre = medico.nombre,
                apellidos = medico.apellidos,
                clave = medico.clave

            };

            _medicoRepository.Añadir(nuevoMedico);
        }

            public void DeleteById(long id)
        {
            var medicoExistente = _medicoRepository.GetById(id);
            if (medicoExistente == null)
            {
                throw new ArgumentException("El paciente que se está eliminando no existe.");
            }

            // Eliminar el medico del repositorio
            _medicoRepository.DeleteById(id);
        }

        public List<Medico> GetAll()
        {
            var medico = _medicoRepository.GetAll();
           
            if (medico == null || medico.Count == 0)
            {
                throw new ArgumentException("No se encontro ningun medico.");
            }
            
            return medico;
        }

        public Medico GetById(long id)
        {
            var medico = _medicoRepository.GetById(id);

            if (medico == null)
            {
                throw new ArgumentException("El medico con este ID no existe en el repositorio.");
            }

            return medico;
        }

        public void Update(Medico medicoActualizado)
        {
            var medicoExistente = _medicoRepository.GetById(medicoActualizado.Id_usuario);

            if (medicoExistente == null)
            {
                throw new ArgumentException($"El médico {medicoActualizado.Id_usuario} no existe");
            }

            // Actualizar los campos del médico existente con los nuevos datos
            medicoExistente.numColegiado = medicoActualizado.numColegiado;
            medicoExistente.usuario = medicoActualizado.usuario;
            medicoExistente.nombre = medicoActualizado.nombre;
            medicoExistente.apellidos = medicoActualizado.apellidos;
            medicoExistente.clave = medicoActualizado.clave;

            // Actualizar la relación con los pacientes
            medicoExistente.Pacientes.Clear();
            foreach (var paciente in medicoActualizado.Pacientes)
            {
                var pacienteExistente = _pacienteRepository.GetById(paciente.PacienteId);
                if (pacienteExistente == null)
                {
                    throw new ArgumentException($"El paciente con ID {paciente.PacienteId} no existe");
                }
                medicoExistente.Pacientes.Add(new MedicoPaciente { MedicoId = medicoExistente.Id_usuario, PacienteId = pacienteExistente.Id_usuario });
            }

            _medicoRepository.Update(medicoExistente);
        }
    }
}
