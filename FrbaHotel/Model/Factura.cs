using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Factura
    {
        public int Id { get; set; }
        public Estadia Estadia { get; set; }
        public Cliente Cliente { get; set; }
        public int DiasAlojamiento { get; set; }
        public int DiasFaltantes { get; set; }
        public DateTime FechaFacturacion { get; set; }
        public TipoPago TipoPago { get; set; }
        public double Total { get; set; }

        List<ItemFactura> Items;
    }
}
