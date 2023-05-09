using citamedica.Repository;
using citamedica.Model;

namespace citamedica.Service
{

    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        private readonly IMedicoRepository _medicoRepository;

        private readonly ICitaRepository _citaRepository;

        public PacienteService(IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository, ICitaRepository citaRepository)
        {
            _pacienteRepository = pacienteRepository;

            _medicoRepository = medicoRepository;

            _citaRepository = citaRepository;
        }


        public void Añadir(Paciente paciente)
        {
            var nuevoPaciente = new Paciente()
            {
                NSS = paciente.NSS,
                numTarjeta = paciente.numTarjeta,
                telefono = paciente.telefono,
                direccion = paciente.direccion,
                usuario = paciente.usuario,
                nombre = paciente.nombre,
                apellidos = paciente.apellidos,
                clave = paciente.clave
            };

            // Agregar el nuevo paciente a la base de datos
            _pacienteRepository.Añadir(nuevoPaciente);

        }

        public void DeleteById(long id)
        {
            var pacienteExistente = _pacienteRepository.GetById(id);
            if (pacienteExistente == null)
            {
                throw new ArgumentException("El paciente que se está eliminando no existe.");
            }

            // Eliminar el paciente del repositorio
            _pacienteRepository.DeleteById(id);
        }

        public List<Paciente> GetAll()
        {
            return _pacienteRepository.GetAll();
        }

        public Paciente GetById(long id)
        {
            var paciente = _pacienteRepository.GetById(id);

            if (paciente == null)
            {
                throw new ArgumentException("El paciente con este ID no existe en el repositorio.");
            }

            return paciente;
        }

        public void Update(Paciente pacienteActualizado)
        {
            var pacienteExistente = _pacienteRepository.GetById(pacienteActualizado.Id_usuario);

            if (pacienteExistente == null)
            {
                throw new ArgumentException("El paciente no existe");
            }

            // Actualizar los campos del paciente existente con los nuevos datos
            pacienteExistente.NSS = pacienteActualizado.NSS;
            pacienteExistente.numTarjeta = pacienteActualizado.numTarjeta;
            pacienteExistente.telefono = pacienteActualizado.telefono;
            pacienteExistente.direccion = pacienteActualizado.direccion;

            

            // Actualizar la relación con los médicos
            pacienteExistente.Medicos.Clear();
            foreach (var medico in pacienteActualizado.Medicos)
            {
                var medicoExistente = _medicoRepository.GetById(medico.MedicoId);
                if (medicoExistente == null)
                {
                    throw new ArgumentException($"El médico con ID {medico.MedicoId} no existe");
                }
                pacienteExistente.Medicos.Add(new MedicoPaciente { PacienteId = pacienteExistente.Id_usuario, MedicoId = medicoExistente.Id_usuario });
            }

            // Actualizar la relación con las citas
            pacienteExistente.Citas.Clear();
            foreach (var cita in pacienteActualizado.Citas)
            {
                var citaExistente = _citaRepository.GetById(cita.id_cita);
                if (citaExistente == null)
                {
                    throw new ArgumentException($"La cita con ID {cita.id_cita} no existe");
                }
                pacienteExistente.Citas.Add(citaExistente);
            }

            _pacienteRepository.Update(pacienteExistente);
        }
    }
}
