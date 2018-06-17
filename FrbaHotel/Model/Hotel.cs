using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public Direccion Direccion {get; set;}
        public int Estrellas { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Baja { get; set; }
    }
}
