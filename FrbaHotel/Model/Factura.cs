using FrbaHotel.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Factura : BaseData
    {
        public decimal Id { get; set; }
        public Estadia Estadia { get; set; }
        public Cliente Cliente { get; set; }
        public int DiasAlojamiento { get; set; }
        public int DiasFaltantes { get; set; }
        public DateTime? FechaFacturacion { get; set; }
        public TipoPago TipoPago { get; set; }
        public decimal Total { get; set; }

        private List<ItemFactura> _items;

        public List<ItemFactura> Items {
            get { return _items ?? (_items = DAOFactory.ItemFacturaDAO.GetItemsByFacturaId(Id)); }
        }

        public Factura(DataRow row) {
            Row = row;

            Id = GetValue<decimal>("id_factura");
            Estadia = new Estadia(row);
            Cliente = new Cliente(row);
            DiasAlojamiento = GetValue<int>("dias_alojamiento");
            DiasFaltantes = GetValue<int>("dias_faltantes");
            FechaFacturacion = GetDate("fecha_facturacion");
            TipoPago = new TipoPago(row);
            Total = GetValue<decimal>("total_factura");
        }


    }
}
