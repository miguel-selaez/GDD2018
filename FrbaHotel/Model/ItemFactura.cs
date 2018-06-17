using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class ItemFactura
    {
        public int Id { get; set; }
        public Consumo Consumo { get; set; }
        public string Leyenda { get; set; }
        public double Subtotal { get; set; }
        public Factura Factura { get; set; }

    }
}
