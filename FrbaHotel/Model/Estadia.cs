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

        List<Cliente> Huespedes;

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
    }
}
