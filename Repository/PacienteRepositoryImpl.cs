using citamedica.Model;
using Microsoft.EntityFrameworkCore;

namespace citamedica.Repository
{
    public class PacienteRepositoryImpl : IPacienteRepository
    {
        private readonly dbContex _context;

        public PacienteRepositoryImpl(DbContext context)
        {
            this._context = (dbContex?)context;
        }

        public void Añadir(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);

            _context.SaveChanges();
        }

        public void DeleteById(long id)
        {
            Paciente paciente = _context.Pacientes.Find(id);

            _context.Pacientes.Remove(paciente);

            _context.SaveChanges();
        }

        public List<Paciente> GetAll() => _context.Pacientes.ToList();

        public Paciente GetById(long id)
        {

            Paciente paciente = _context.Pacientes.Include(c => c.Medicos).FirstOrDefault(d => d.Id_usuario == id);

            return paciente;
        }

        public void Update(Paciente paciente)
        {
            _context.Entry(paciente).State = EntityState.Modified;
            
            _context.SaveChanges();
        }
    }
}
