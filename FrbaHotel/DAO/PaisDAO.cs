using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaHotel.Model;

namespace FrbaHotel.DAO
{
    public class PaisDAO : BaseDAO<Pais>
    {
        public PaisDAO(DBConnection con) : base(con) { }

        public List<Pais> GetPaises()
        {
            var paises = new List<Pais>();
            var baja = false;

            var query = ArmarSentenciaSP("P_Obtener_Paises", new[] { GetParam(baja) });
            var result = Connection.ExecuteQuery(query);

            if(result.Rows.Count > 0)
            {
                foreach(DataRow row in result.Rows)
                {
                    paises.Add(new Pais(row));
                }
            }

            return paises;
        }

    }
}
