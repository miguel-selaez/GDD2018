using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Reserva : BaseData
    {
        public decimal Id { get; set; }
        public Usuario UsuarioCreacion { get; set; }
        public Hotel Hotel { get; set; }
        public Regimen Regimen { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public Decimal TotalReserva { get; set; }
        public EstadoReserva Estado { get; set; }

        private List<HabitacionReservada> _habitaciones;

        public List<HabitacionReservada> Habitaciones
        { 
            get {
                return _habitaciones ?? (_habitaciones = DAO.DAOFactory.HabitacionDAO.GetHabitacionesByReserva(Id));
            }
            set {
                _habitaciones = value;
            }
        }
        
        public Reserva(DataRow row)
        {
            Row = row;

            Id = GetValue<decimal>("id_reserva");
            UsuarioCreacion = new Usuario(row);
            Hotel = new Hotel(row);
            Regimen = new Regimen(row);
            Cliente = new Cliente(row);
            FechaCreacion = GetDate("fecha_creacion");
            FechaInicio = GetDate("fecha_inicio");
            FechaFin = GetDate("fecha_fin");
            TotalReserva = GetValue<decimal>("total_reserva");
            Estado = new EstadoReserva(row);
        }
        public Reserva(decimal id, Usuario usuarioCreacion, Hotel hotel, Regimen regimen, Cliente cliente, DateTime fechaCreacion,
            DateTime fechaInicio, DateTime fechaFin, decimal totalReserva, EstadoReserva estado) {
                Id = id;
                UsuarioCreacion = usuarioCreacion;
                Hotel = hotel;
                Regimen = regimen;
                Cliente = cliente;
                FechaCreacion = fechaCreacion;
                FechaInicio = fechaInicio;
                FechaFin = fechaFin;
                TotalReserva = totalReserva;
                Estado = estado;
        }
    }
}
