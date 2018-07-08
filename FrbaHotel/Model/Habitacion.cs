using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Habitacion : BaseData
    {
        public int Id { get; set; }
        public decimal Numero { get; set; }
        public Hotel Hotel { get; set; }
        public decimal Piso { get; set; }
        public string Frente { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; }
        public bool Baja { get; set; }

        public Habitacion(DataRow row)
        {
            Row = row;

            Id = GetValue<int>("id_habitacion");
            Numero = GetValue<decimal>("numero");
            Hotel = new Hotel(row);
            Piso = GetValue<decimal>("piso");
            Frente = GetValue<string>("frente");
            TipoHabitacion = new TipoHabitacion(row);
            Baja = GetValue<bool>("baja_ha");
        }

    }
}
