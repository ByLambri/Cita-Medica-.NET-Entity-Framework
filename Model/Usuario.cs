using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace citamedica.Model
{
    [Table("usuarios")]
    public class Usuario
    {
        public Usuario()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_usuario { get ; set; }

        [Required]
        public String usuario { get; set; }

        [Required]
        public String nombre { get; set; }

        [Required]
        public String apellidos { get; set; }

        [Required]
        public String clave { get; set; }

        public Usuario(long id_usuario, string usuario, string nombre, string apellidos, string clave)
        {
            Id_usuario = id_usuario;
            this.usuario = usuario;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.clave = clave;
        }
    }
}
