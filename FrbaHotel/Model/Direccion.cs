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
        public decimal Piso { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public Pais Pais { get; set; }

        public Direccion(DataRow row)
        {
            Row = row;

            Id = GetValue<int>("id_direccion");
            Calle = GetValue<string>("calle");
            NumeroCalle = GetValue<decimal>("nro_calle");
            Piso = GetValue<decimal>("piso");
            Departamento = GetValue<string>("departamento");
            Ciudad = GetValue<string>("ciudad");
            Pais = new Pais(row);
        }

        public Direccion(string calle, decimal numeroCalle, int piso, string departamento, string ciudad, Pais pais) {
            Calle = calle;
            NumeroCalle = numeroCalle;
            Piso = piso;
            Departamento = departamento;
            Ciudad = ciudad;
            Pais = pais;
        }
    }
}
