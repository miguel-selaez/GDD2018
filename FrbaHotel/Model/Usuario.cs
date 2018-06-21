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
            Baja = GetValue<bool>("baja");
            IntentosFallidos = GetValue<int>("intentos_fallidos");
            Persona = new Persona(row);
        }

        public List<Rol> Roles {
            get{ return _roles ?? (_roles = DAOFactory.RolDAO.GetRolesByUserId(Id));}
        }
        public List<Hotel> HotelesAsignados {
            get{ return _hoteles ?? (_hoteles = DAOFactory.HotelDAO.GetHotelesByUserId(Id));}
        }
    }
}
