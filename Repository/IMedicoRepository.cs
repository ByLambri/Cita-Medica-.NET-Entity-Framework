
using citamedica.Model;

namespace citamedica.Repository
{
    public interface IMedicoRepository
    {

        public List<Medico> GetAll();

        public void Añadir(Medico medico);

        public Medico GetById(long id);

        public void Update(Medico medico);

        public void DeleteById(long id);


    }
}
