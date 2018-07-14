using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class HotelDAO : BaseDAO<Hotel>
    {
        public HotelDAO(DBConnection con) : base(con) { }

        public List<Hotel> GetHotelesByUserId(int Id)
        {
            var list = new List<Hotel>();

            var query = ArmarSentenciaSP("P_Obtener_Hoteles_Asignados", new[] { GetParam(Id) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Hotel(row));
                }
            }
            return list;
        }

        public List<Hotel> GetHoteles(string nombre, string vigencia)
        {
            var list = new List<Hotel>();

            var query = ArmarSentenciaSP("P_Obtener_Hoteles", new[] { GetParam(nombre), GetParamVigencia(vigencia) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Hotel(row));
                }
            }
            return list;
        }
    }
}
