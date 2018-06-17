using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Habitacion
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public Hotel Hotel { get; set; }
        public int Piso { get; set; }
        public string frente { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; }
        public bool Baja { get; set; }
    }
}
