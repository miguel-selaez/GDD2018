using FrbaHotel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public bool Baja { get; set; }
        public int IntentosFallidos { get; set; }
        public Persona Persona { get; set; }

        private List<Rol> _roles;
        private List<Hotel> _hoteles;

        public List<Rol> Roles {
            get{ return _roles ?? (_roles = DAOFactory.UsuarioDAO.GetRoles(Id));}
        }
        public List<Hotel> HotelesAsignados {
            get{ return _hoteles ?? (_hoteles = DAOFactory.UsuarioDAO.GetHoteles(Id));}
        }
    }
}
