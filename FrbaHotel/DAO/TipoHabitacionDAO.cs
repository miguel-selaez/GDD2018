using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class TipoHabitacionDAO : BaseDAO<Model.TipoHabitacion>
    {
        public TipoHabitacionDAO(DBConnection con) : base(con) { }



        public List<Model.TipoHabitacion> GetTiposHabitacionByHotel(int hotelId)
        {
            var list = new List<TipoHabitacion>();

            var query = ArmarSentenciaSP("P_Obtener_Tipos_Habitacion_x_Hotel", new[] { GetParam(hotelId) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new TipoHabitacion(row));
                }
            }
            return list;
        }
    }
}
