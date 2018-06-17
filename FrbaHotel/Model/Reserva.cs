using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Reserva
    {
        public int Id { get; set; }
        public Usuario UsuarioCreacion { get; set; }
        public Hotel Hotel { get; set; }
        public Regimen Regimen { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoReserva Estado { get; set; }

        List<Habitacion> Habitaciones;
    }
}
