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
        public Hotel Hotel { get; set; }
        public decimal TotalHabitacion { get; set; }

        public HabitacionReservada(DataRow row) {
            Hotel = new Hotel(row);
            TotalHabitacion = GetValue<decimal>("total_habitacion");
        }

        public HabitacionReservada(Hotel hotel, decimal total) {
            Hotel = hotel;
            TotalHabitacion = total;
        }
    }
}
