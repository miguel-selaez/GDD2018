using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Regimen : BaseData
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Baja { get; set; }

        public Regimen(DataRow row) {
            Row = row;

            Id = GetValue<int>("id_regimen");
            Descripcion = GetValue<string>("descripcion_r");
            Precio = GetValue<decimal>("precio");
            Baja = GetValue<bool>("baja_r");
        }
    }
}
