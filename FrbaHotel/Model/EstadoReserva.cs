using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FrbaHotel.Model
{
    public class EstadoReserva : BaseData
    {
        public int Id { get; set; }
        public string Descipcion { get; set; }
        public bool Baja { get; set; }

        public EstadoReserva(DataRow row) {
            Row = row;

            Id = GetValue<int>("id_estado");
            Descipcion = GetValue<string>("descripcion_er");
            Baja = GetValue<bool>("baja_er");
        }
    }
}
