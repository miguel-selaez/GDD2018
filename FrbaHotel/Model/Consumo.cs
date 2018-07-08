using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Consumo : BaseData
    {
        public int Id { get; set; }
        public Estadia Estadia { get; set; }
        public Consumible Consumible { get; set; }
        public Habitacion Habitacion { get; set; }
        public Reserva Reserva { get; set; }
        public decimal cantidad { get; set; }

        public Consumo(DataRow row) {
            Row = row;

            Id = GetValue<int>("id_consumo");
            Estadia = new Estadia(row);
            Consumible = new Consumible(row);
            Habitacion = new Habitacion(row);
            Reserva = new Reserva(row);
            cantidad = GetValue<decimal>("cantidad");
        }
    }
}
