using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class ItemFactura : BaseData
    {
        public int Id { get; set; }
        public Consumo Consumo { get; set; }
        public string Leyenda { get; set; }
        public decimal Subtotal { get; set; }
        public Factura Factura { get; set; }

        public ItemFactura(DataRow row) {
            Row = row;

            Id = GetValue<int>("id_item_factura");
            Consumo = new Consumo(row);
            Leyenda = GetValue<string>("leyenda");
            Subtotal = GetValue<decimal>("subtotal");
            Factura = new Factura(row);
        }
    }
}
