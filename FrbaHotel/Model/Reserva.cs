using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Reserva : BaseData
    {
        public int Id { get; set; }
        public Usuario UsuarioCreacion { get; set; }
        public Hotel Hotel { get; set; }
        public Regimen Regimen { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public EstadoReserva Estado { get; set; }

        List<Habitacion> Habitaciones;
        
        public Reserva(System.Data.DataRow row)
        {
            Row = row;

            Id = GetValue<int>("id_reserva");
            UsuarioCreacion = new Usuario(row);
            Hotel = new Hotel(row);
            Regimen = new Regimen(row);
            Cliente = new Cliente(row);
            FechaCreacion = GetDate("fecha_creacion");
            FechaInicio = GetDate("fecha_inicio");
            FechaFin = GetDate("fecha_fin");
            Estado = new EstadoReserva(row);
        }
    }
}
