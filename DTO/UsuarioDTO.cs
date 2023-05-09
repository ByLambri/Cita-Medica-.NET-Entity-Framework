using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace citamedica.DTO
{
    public class UsuarioDTO
    {

        
        public long Id_usuario { get; set; }

        public String usuario { get; set; }
                
        public String nombre { get; set; }

        public String apellidos { get; set; }

        public String clave { get; set; }

        public UsuarioDTO(long id_usuario, string usuario, string nombre, string apellidos, string clave)
        {
            Id_usuario = id_usuario;
            this.usuario = usuario;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.clave = clave;
        }
    }
}
