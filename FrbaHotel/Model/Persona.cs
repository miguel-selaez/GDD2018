using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public Direccion Direccion { get; set; }
        public string Mail { get; set; }
        public Pais Nacionalidad { get; set; }
        public bool Inconsistente { get; set; }
    }
}
