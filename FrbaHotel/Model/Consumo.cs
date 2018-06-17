using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Consumo
    {
        public int Id { get; set; }
        public Estadia Estadia { get; set; }
        public Consumible Consumible { get; set; }
        public Habitacion Habitacion { get; set; }
        public Reserva Reserva { get; set; }
        public int cantidad { get; set; }
    }
}
