using System.ComponentModel.DataAnnotations;

namespace ApiAHL.Models
{
    public class Hoteles
    {
        [Key]
        public int idHotel { get; set; }
        public string nombreHotel { get; set; }

        public string direccionHotel { get; set; }
        public string telefonoHotel { get; set; }

        public string ciudadHotel { get; set; }

        public string categoriaHotel { get; set; }
        public int disponible { get; set; }
    }
}
