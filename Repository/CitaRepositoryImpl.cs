using citamedica.Model;
using System.Xml.Serialization;
using citamedica.Service;
using Microsoft.EntityFrameworkCore;

namespace citamedica.Repository
{
    
    public class CitaRepositoryImpl : ICitaRepository
    {
        private readonly dbContex context;

        public CitaRepositoryImpl(DbContext context)
        {
            this.context = (dbContex?)context;
        }
        public void Añadir(Cita cita)
        { 
            context.Citas.Add(cita);

            context.SaveChanges();
        }

        public void DeleteById(long id)
        {
            Cita cita = context.Citas.Find(id);

            context.Citas.Remove(cita);

            context.SaveChanges();
        }

        public List<Cita> GetAll()
        {
            return context.Citas.ToList();
        }
        
        public Cita GetById(long id)
        {
            Cita cita = context.Citas.Include(c => c.Diagnostico).FirstOrDefault(d => d.id_cita == id);

            return cita;
        }

        public void Update(Cita cita)
        {
            context.Entry(cita).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
