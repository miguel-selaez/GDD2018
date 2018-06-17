using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class TipoHabitacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Porcentual { get; set; }
        public bool Baja { get; set; }
    }
}
