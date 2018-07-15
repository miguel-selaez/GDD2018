using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class HabitacionReservada : BaseData
    {
        public Habitacion Habitacion { get; set; }
        public decimal TotalHabitacion { get; set; }

        public HabitacionReservada(DataRow row) {
            Row = row;

            Habitacion = new Habitacion(row);
            TotalHabitacion = GetValue<decimal>("total_habitacion");
        }

        public HabitacionReservada(Habitacion habitacion, decimal total)
        {
            Habitacion = habitacion;
            TotalHabitacion = total;
        }
    }
}
