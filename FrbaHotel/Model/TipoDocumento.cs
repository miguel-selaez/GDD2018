using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class TipoDocumento : BaseData
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Baja { get; set; }

        public TipoDocumento(DataRow row)
        {
            Row = row;

            Id = GetValue<int>("id_tipo_documento");
            Descripcion = GetValue<string>("descripcion_td");
            Baja = GetValue<bool>("baja_td");
        }

        public TipoDocumento(int id, string descripcion, bool baja)
        {
            Id = id;
            Descripcion = descripcion;
            Baja = baja;
        }

    }
}
