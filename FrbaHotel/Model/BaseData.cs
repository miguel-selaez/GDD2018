using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public abstract class BaseData
    {
        public DataRow Row {get; set;}

        public T GetValue<T>(string name)
        {
            return Row[name] != DBNull.Value ? (T)Row[name] : default(T);
        }

        public DateTime? GetDate(string name) {
            if (Row[name] != DBNull.Value)
            {
                var dateString = Row[name].ToString();
                return Tools.ToDisplayTime(dateString);
            }
            return null;
        }
    }
}
