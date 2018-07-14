using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class TipoDocumentoDAO : BaseDAO<TipoDocumento>
    {
        public TipoDocumentoDAO(DBConnection con) : base(con) { }

        public List<TipoDocumento> GetTiposDocumento(string descripcion, string vigencia)
        {
            var list = new List<TipoDocumento>();

            var query = ArmarSentenciaSP("P_Obtener_TiposDocumento", new[]{GetParam(descripcion), GetParamVigencia(vigencia)});
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new TipoDocumento(row));
                }
            }
            return list;
        }
    }
}
