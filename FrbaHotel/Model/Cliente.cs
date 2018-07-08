using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Cliente : BaseData
    {
        public int Id { get; set; }
        public Persona Persona{ get; set; }
        public int Puntos { get; set; }
        public bool Baja { get; set; }

        public Cliente(DataRow row) {
            Row = row;

            Id = GetValue<int>("id_cliente");
            Persona = new Persona(row);
            Puntos = GetValue<int>("puntos");
            Baja = GetValue<bool>("baja_cl");
        }

    }
}
