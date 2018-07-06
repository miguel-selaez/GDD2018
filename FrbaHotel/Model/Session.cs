using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Session
    {
        public Usuario User { get; set; }
        public Inicio Main { get; set; }
        public Hotel Hotel { get; set; }
        public Rol Rol { get; set; }
    }
}
