using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class TipoPago : BaseData
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Baja { get; set; }

        public TipoPago(DataRow row)
        {
            Row = row;

            Id = GetValue<int>("id_tipo_pago");
            Descripcion = GetValue<string>("descripcion_tp");
            Baja = GetValue<bool>("baja_tp");
        }
    }
}
