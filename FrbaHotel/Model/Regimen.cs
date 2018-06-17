using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Regimen
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public bool Baja { get; set; }
    }
}
