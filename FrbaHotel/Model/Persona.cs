using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Persona : BaseData
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public int TipoDocumentoId { get; set; }
        public decimal NumeroDocumento { get; set; }
        public Direccion Direccion { get; set; }
        public string Mail { get; set; }
        public int NacionalidadId { get; set; }
        public bool Inconsistente { get; set; }

        public Persona(DataRow row)
        {
            Row = row;

            Id = GetValue<int>("id_persona");
            Nombre = GetValue<string>("nombre");
            Apellido = GetValue<string>("apellido");
            FechaNacimiento = GetDate("fecha_nacimiento");
            Telefono =GetValue<string>("telefono");
            TipoDocumentoId = GetValue<int>("id_tipo_documento");
            NumeroDocumento = GetValue<decimal>("numero_documento");
            Direccion = new Direccion(row);
            Mail = GetValue<string>("mail");
            NacionalidadId = GetValue<int>("id_nacionalidad");
            Inconsistente = GetValue<bool>("inconsistente");
        }
    }
}
