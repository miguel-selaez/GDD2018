using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Pais : BaseData
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nacionalidad { get; set; }
        public bool Baja { get; set; }

        public Pais(DataRow row) {
            Row = row;

            Id = GetValue<int>("id_pais");
            Descripcion = GetValue<string>("descripcion_pa");
            Nacionalidad = GetValue<string>("nacionalidad");
            Baja = GetValue<bool>("baja_pa");
        }

    }
}
