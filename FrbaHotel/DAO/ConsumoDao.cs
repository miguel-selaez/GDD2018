using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class ConsumoDAO : BaseDAO<Consumo>
    {
        public ConsumoDAO(DBConnection con) : base(con) { }

        public void agregarConsumo(string estadia,string producto,string nro_hab,string cantidad)
        {
            var query = ArmarSentenciaSP("P_Registrar_Consumo", 
                    new[] { GetParam(estadia), GetParam(producto), GetParam(nro_hab),
                    GetParam(cantidad)});
            Connection.ExecuteNoQuery(query);
        }

    }
}
