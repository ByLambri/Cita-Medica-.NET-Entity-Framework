using citamedica.Model;
using Microsoft.EntityFrameworkCore;

namespace citamedica.Repository
{
    public class MedicoRepositoryImpl : IMedicoRepository
    {
        private readonly dbContex context;
        public void Añadir(Medico medico)
        {
           context.Medicos.Add(medico);

           context.SaveChanges();
        }

        public void DeleteById(long id)
        {
            Medico medico = context.Medicos.Find(id);

            context.Medicos.Remove(medico);

            context.SaveChanges();
        }

        public List<Medico> GetAll() => context.Medicos.ToList();

        public Medico GetById(long id)
        {
            Medico medico= context.Medicos.Include(c => c.Pacientes).FirstOrDefault(d => d.Id_usuario == id);

            return medico;
        }

        public void Update(Medico medico)
        {
            context.Entry(medico).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
