using citamedica.Model;

namespace citamedica.Repository
{
    //<T> where T : class
    public interface IDiagnosticoRepository
    {

        public List<Diagnostico> GetAll();

        public void Añadir(Diagnostico diagnostico);

        public Diagnostico GetById(long id);

        public void Update(Diagnostico diagnostico);

        public void DeleteById(long id);
    }
}
