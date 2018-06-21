using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class UsuarioDAO : BaseDAO<Usuario>
    {
        public override void CreateOrUpdate(Usuario user) { 
            
        }

        public Usuario Login(string user, string password)
        {
            var query = ArmarSentenciaSP("P_LOGIN", new [] { 
                GetParam(user), 
                GetParam(password) 
            });
            var result = Connection.ExecuteQuery(query);
            return result.Rows.Count > 0 ? new Usuario(result.Rows[0]) : null;
        }
    }
}
