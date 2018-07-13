using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class TipoHabitacion : BaseData
    {
        public decimal Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Porcentual { get; set; }
        public bool Baja { get; set; }

        public TipoHabitacion(DataRow row)
        {
            Row = row;

            Id = GetValue<decimal>("id_tipo_habitacion");
            Descripcion = GetValue<string>("descripcion_th");
            Porcentual = GetValue<decimal>("porcentual");
            Baja = GetValue<bool>("baja_th");
        }
    }
}
