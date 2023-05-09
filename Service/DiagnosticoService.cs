using citamedica.DTO;
using citamedica.Model;
using citamedica.Repository;

namespace citamedica.Service
{
    public class DiagnosticoService : IDiagnosticoService
 {
        private readonly IDiagnosticoRepository _diagnosticoRepository;

        private readonly ICitaRepository _citaRepository;
   
        public DiagnosticoService(IDiagnosticoRepository diagnosticoRepository, ICitaRepository citaRepository)
        {
            _diagnosticoRepository = diagnosticoRepository;
            _citaRepository = citaRepository;
        }

        
        public void Añadir(Diagnostico diagnostico)
        {

            var nuevoDiagnostico = new Diagnostico(
                    diagnostico.id_Diagnostico,
                    diagnostico.valoracionEspecialista,
                    diagnostico.enfermedad,
                    diagnostico.CitaId
                );

            _diagnosticoRepository.Añadir( nuevoDiagnostico );

        }

        public void DeleteById(long id)
        {
            var diagnosticoExistente = _diagnosticoRepository.GetById(id);
            if (diagnosticoExistente == null)
            {
                throw new ArgumentException("El diagnóstico que se está eliminando no existe en el repositorio.");
            }

            // Eliminar el diagnóstico del repositorio
            _diagnosticoRepository.DeleteById(id);
        }

        public List<Diagnostico> GetAll()
        {
            return _diagnosticoRepository.GetAll();
        }

        
        public Diagnostico GetById(long id)
        {
                var diagnostico = _diagnosticoRepository.GetById(id);

                if (diagnostico == null)
                {
                    throw new ArgumentException("El diagnóstico con este  ID  no existe en el repositorio.");
                }

                return diagnostico;
        }
        

        public void Update(Diagnostico diagnostico)
        {
            var diagnosticoExistente = _diagnosticoRepository.GetById(diagnostico.id_Diagnostico);
            if (diagnosticoExistente == null)
            {
                throw new ArgumentException("El diagnóstico  no existe en el repositorio.");
            }

            // Validar que la cita médica asociada existe en el repositorio
            var cita = _citaRepository.GetById(diagnostico.CitaId);

            if (cita == null)
            {
                throw new ArgumentException("No hay ninguna cita asociada.");
            }

            // Actualizo el diagnóstico en el repositorio
            diagnosticoExistente.valoracionEspecialista = diagnostico.valoracionEspecialista;
            diagnosticoExistente.enfermedad = diagnostico.enfermedad;
            diagnosticoExistente.CitaId = diagnostico.CitaId;

            _diagnosticoRepository.Update(diagnosticoExistente);
        }
    }
}
