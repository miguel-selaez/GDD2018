using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Direccion : BaseData
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public decimal NumeroCalle { get; set; }
        public int Piso { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public int IdPais { get; set; }

        public Direccion(DataRow row)
        {
            Row = row;

            Id = GetValue<int>("id_direccion");
            Calle = GetValue<string>("calle");
            NumeroCalle = GetValue<decimal>("nro_calle");
            Piso = GetValue<int>("piso");
            Departamento = GetValue<string>("departamento");
            Ciudad = GetValue<string>("ciudad");
            IdPais = GetValue<int>("id_pais");
        }
    }
}
