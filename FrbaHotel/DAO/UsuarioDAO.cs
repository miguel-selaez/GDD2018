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
            throw new NotImplementedException();
        }

        public List<Rol> GetRoles(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetHoteles(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
