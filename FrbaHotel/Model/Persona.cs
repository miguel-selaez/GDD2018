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
        public TipoDocumento TipoDocumento { get; set; }
        public decimal NumeroDocumento { get; set; }
        public Direccion Direccion { get; set; }
        public string Mail { get; set; }
        public Pais Nacionalidad { get; set; }
        public bool Inconsistente { get; set; }

        public Persona(DataRow row)
        {
            Row = row;

            Id = GetValue<int>("id_persona");
            Nombre = GetValue<string>("nombre");
            Apellido = GetValue<string>("apellido");
            FechaNacimiento = GetDate("fecha_nacimiento");
            Telefono =GetValue<string>("telefono");
            TipoDocumento = new TipoDocumento(row);
            NumeroDocumento = GetValue<decimal>("numero_documento");
            Direccion = new Direccion(row);
            Mail = GetValue<string>("mail");
            Nacionalidad = new Pais(row);
            Inconsistente = GetValue<bool>("inconsistente");
        }

        public Persona(string nombre, string apellido, DateTime fechaNacimiento, string telefono,
            TipoDocumento tipoDocumento, decimal numeroDocumento, Direccion direccion, string mail,
            Pais nacionalidad, bool inconsistente) {
                Nombre = nombre;
                Apellido = apellido;
                FechaNacimiento = fechaNacimiento;
                Telefono = telefono;
                TipoDocumento = tipoDocumento;
                NumeroDocumento = numeroDocumento;
                Direccion = direccion;
                Mail = mail;
                Nacionalidad = nacionalidad;
                Inconsistente = inconsistente;
        }
    }
}
