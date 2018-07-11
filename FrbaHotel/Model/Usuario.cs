using FrbaHotel.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Usuario : BaseData
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public bool Baja { get; set; }
        public int IntentosFallidos { get; set; }
        public Persona Persona { get; set; }

        private List<Rol> _roles;
        private List<Hotel> _hoteles;

        public Usuario(DataRow row)
        {
            Row = row;

            Id = GetValue<int>("id_usuario");
            NombreUsuario = GetValue<string>("nombre_usuario");
            Password = GetValue<string>("pass");
            Baja = GetValue<bool>("baja_u");
            IntentosFallidos = GetValue<int>("intentos_fallidos");
            Persona = new Persona(row);
        }
        public Usuario(string nombreUsuario, string password, bool baja, Persona persona, List<Rol> roles, List<Hotel> hoteles) {
            NombreUsuario = nombreUsuario;
            Password = password;
            Baja = baja;
            Persona = persona;
            Roles = roles;
            HotelesAsignados = hoteles;
        }

        public List<Rol> Roles {
            get{ return _roles ?? (_roles = DAOFactory.RolDAO.GetRolesByUserId(Id));}
            set { _roles = value; }
        }
        public List<Hotel> HotelesAsignados {
            get{ return _hoteles ?? (_hoteles = DAOFactory.HotelDAO.GetHotelesByUserId(Id));}
            set { _hoteles = value; }
        }

        public List<Funcion> Funciones{
            get { return Roles.SelectMany(r => r.Funciones).ToList(); }
        }
    }
}
