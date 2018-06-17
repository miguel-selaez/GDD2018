using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class UsuarioDAO : BaseDAO<Usuario>
    {
        public override void CreateOrUpdate(Usuario user) { 
            
        }

        public Usuario Login(string user, string password)
        {
            return null;
        }

        public List<Rol> GetRoles(int Id)
        {
            return null;
        }

        public List<Hotel> GetHoteles(int Id)
        {
            return null;a 
        }
    }
}
