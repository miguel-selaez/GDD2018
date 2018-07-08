using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Consumible : BaseData
    {
        public decimal Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public Consumible(DataRow row) {
            Row = row;

            Id = GetValue<decimal>("id_consumible");
            Descripcion = GetValue<string>("descripcion_cb");
            Precio = GetValue<decimal>("precio");
        }
    }
}
