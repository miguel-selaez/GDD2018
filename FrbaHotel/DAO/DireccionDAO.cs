using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class DireccionDAO : BaseDAO<Direccion>
    {
        public DireccionDAO(DBConnection con) : base(con) { }

        public string CreateOrUpdateScript(Direccion direccion){
            var query = "DECLARE @id_direccion int;";
            query += ArmarSentenciaSP("P_Guardar_Direccion", new[] { 
                GetParam(direccion.Id), 
                GetParam(direccion.Calle),
                GetParam(direccion.NumeroCalle), 
                GetParam(direccion.Piso), 
                GetParam(direccion.Departamento), 
                GetParam(direccion.Ciudad),
                GetParam(direccion.Pais),
                "@id_direccion output"
            });
            return query;
        }
    }
}
