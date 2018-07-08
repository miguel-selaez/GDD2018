using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class FuncionDAO : BaseDAO<Funcion>
    {
        public FuncionDAO(DBConnection con) : base(con) { }

        public List<Funcion> GetFuncionesByRol(int rolId)
        {
            var list = new List<Funcion>();

            var query = ArmarSentenciaSP("P_Obtener_Funciones_x_Rol", new[] { GetParam(rolId) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Funcion(row));
                }
            }
            return list;
        }
    }
}
