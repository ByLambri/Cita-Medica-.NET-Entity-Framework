using citamedica.Model;

namespace citamedica.Service
{
    public interface ICitaService
    {

        public List<Cita> GetAll();

        public void Añadir(Cita cita);

        public Cita GetById(long id);

        public void Update(Cita cita);

        public void DeleteById(long id);
    }
}
