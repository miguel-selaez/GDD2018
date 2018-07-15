using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class HabitacionDAO : BaseDAO<Model.Habitacion>
    {
        public HabitacionDAO(DBConnection con) : base(con) { }

        public List<Model.Habitacion> GetHabitacionsXHotel(Hotel hotel, string vigencia)
        {
            var list = new List<Habitacion>();

            var query = ArmarSentenciaSP("P_Obtener_Habitaciones_x_Hotel", new[] { GetParam(hotel.Id), GetParamVigencia(vigencia) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Habitacion(row));
                }
            }

            return list;
        }

        public List<Model.Habitacion> GetHabitacionesxPedido(int hotelId, decimal tipoHabitacion, DateTime actual,DateTime desde, DateTime hasta)
        {
            var list = new List<Habitacion>();

            var query = ArmarSentenciaSP("P_Obtener_Habitaciones_x_Pedido", new[] { 
                GetParam(hotelId),
                GetParam(tipoHabitacion),
                GetParam(actual),
                GetParam(desde),
                GetParam(hasta)
            });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Habitacion(row));
                }
            }
            return list;
        }

        public List<HabitacionReservada> GetHabitacionesByReserva(decimal reservaId)
        {
            var list = new List<HabitacionReservada>();

            var query = ArmarSentenciaSP("P_Obtener_Habitaciones_x_Reserva", new[] { GetParam(reservaId) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new HabitacionReservada(row));
                }
            }
            return list;
        }
    }
}
