using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Estadia : BaseData
    {
        public int Id { get; set; }
        public Reserva Reserva { get; set; }
        public Usuario UsuarioIngreso { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public Usuario UsuarioSalida { get; set; }
        public DateTime? FechaSalida { get; set; }

        private List<Cliente> _clientes;
        public List<Cliente> Huespedes
        {
            get
            {
                return _clientes ?? (_clientes = DAO.DAOFactory.ClienteDAO.GetClientesxEstadia(Id));
            }
            set
            {
                _clientes = value;
            }
        }

        public Estadia(DataRow row)
        {
            Row = row;

            Id = GetValue<int>("id_estadia");
            Reserva = new Reserva(row);
            UsuarioIngreso = new Usuario(row);
            FechaIngreso = GetDate("fecha_ingreso");
            UsuarioSalida = new Usuario(row);
            FechaSalida = GetDate("fecha_salida");
        }

        public Estadia(int id, Reserva reserva, Usuario usuarioIngreso, DateTime? fechaIngreso,
            Usuario usuarioSalida, DateTime? fechaSalida) {
                Id = id;
                Reserva = reserva;
                UsuarioIngreso = usuarioIngreso;
                FechaIngreso = fechaIngreso;
                FechaSalida = fechaSalida;
        }
    }
}
