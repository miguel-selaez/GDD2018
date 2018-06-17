using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Estadia
    {
        public int Id { get; set; }
        public Reserva Reserva { get; set; }
        public Usuario UsuarioIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Usuario UsuarioSalida { get; set; }
        public DateTime FechaSalida { get; set; }

        List<Cliente> Huespedes;
    }
}
