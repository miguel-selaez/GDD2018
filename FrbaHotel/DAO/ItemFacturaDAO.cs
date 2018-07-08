using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class ItemFacturaDAO : BaseDAO<ItemFactura>
    {
        public ItemFacturaDAO(DBConnection con) : base(con) { }

        public override void CreateOrUpdate(ItemFactura item)
        {

        }

        internal List<ItemFactura> GetItemsByFacturaId(int Id)
        {
            throw new NotImplementedException();
        }

        internal List<ItemFactura> GetItemsByFacturaId(decimal Id)
        {
            throw new NotImplementedException();
        }
    }
}
