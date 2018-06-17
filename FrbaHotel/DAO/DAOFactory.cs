using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public static class DAOFactory
    {
        private static FuncionDAO _funcionDao;
        private static HotelDAO _hotelDao;
        private static RolDAO _rolDao;
        private static UsuarioDAO _usuarioDao;

        public static FuncionDAO FuncionDAO { get { return _funcionDao ?? (_funcionDao = new FuncionDAO()); } }

        public static HotelDAO HotelDAO { get { return _hotelDao ?? (_hotelDao = new HotelDAO()); } }

        public static RolDAO RolDAO { get { return _rolDao ?? (_rolDao = new RolDAO()); } }

        public static UsuarioDAO UsuarioDAO { get { return _usuarioDao ?? (_usuarioDao = new UsuarioDAO()); } }
    }
}
