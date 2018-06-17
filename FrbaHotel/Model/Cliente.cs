using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Cliente 
    {
        public int Id { get; set; }
        public Persona Persona{ get; set; }
        public int Puntos { get; set; }
        public bool Baja { get; set; }


    }
}
