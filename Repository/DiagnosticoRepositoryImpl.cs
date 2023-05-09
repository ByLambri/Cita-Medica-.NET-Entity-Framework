using citamedica.Model;
using Microsoft.EntityFrameworkCore;

namespace citamedica.Repository
{
    public class DiagnosticoRepositoryImpl : IDiagnosticoRepository
    {
        private readonly dbContex context;

        public DiagnosticoRepositoryImpl(DbContext context)
        {
            this.context = (dbContex?)context;
        }

        public void Añadir(Diagnostico diagnostico)
        {
            context.Diagnosticos.Add(diagnostico);

            context.SaveChanges();
        }

        public void DeleteById(long id)
        {
            Diagnostico diagnostico = context.Diagnosticos.Find(id);

            context.Diagnosticos.Remove(diagnostico);

            context.SaveChanges();
        }

        public List<Diagnostico> GetAll() => context.Diagnosticos.ToList();

        public Diagnostico GetById(long id)
        {
            Diagnostico diagnostico = context.Diagnosticos.Include(c => c.id_Diagnostico).FirstOrDefault();

            return diagnostico;
        }

        public void Update(Diagnostico diagnostico)
        {
            context.Entry(diagnostico).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
