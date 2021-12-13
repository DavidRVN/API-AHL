using System.ComponentModel.DataAnnotations;

namespace ApiAHL.Models
{
    public class Usuarios
    {
        [Key]
        public int idusuario { get; set; }
        public string nombre { get; set; }

        public string apellido { get; set; }

        public string usuario { get; set; }

        public string contraseña { get; set; }
        public int rol { get; set; }
    }
}
