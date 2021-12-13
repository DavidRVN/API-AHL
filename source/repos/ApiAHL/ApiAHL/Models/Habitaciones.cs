using System.ComponentModel.DataAnnotations;

namespace ApiAHL.Models
{
    public class Habitaciones
    {   
        [Key]
        public int idHabitacion { get; set; }
        public string tpHabitacion { get; set; }
        public string precioHabitacion { get; set; }
        public string tipoMoneda { get; set; }
        public int disponibilidad { get; set; }
        public int hotelasignado { get; set; }

    }
}
