using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class TipoRegimenDAO :BaseDAO<Model.Regimen>
    {
        public TipoRegimenDAO(DBConnection con) : base(con) { }

        public List<Model.Regimen> GetRegimenesByHotel(int hotelId)
        {
            var list = new List<Regimen>();

            var query = ArmarSentenciaSP("P_Obtener_Regimenes_x_Hotel", new[] { 
                GetParam(hotelId)
            });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Regimen(row));
                }
            }
            return list;
        }
    }
}
