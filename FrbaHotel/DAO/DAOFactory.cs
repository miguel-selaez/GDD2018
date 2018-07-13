using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public static class DAOFactory
    {
        private static DBConnection _connection = new DBConnection("Hotel");

        private static FuncionDAO _funcionDao;
        private static HotelDAO _hotelDao;
        private static RolDAO _rolDao;
        private static UsuarioDAO _usuarioDao;
        private static ItemFacturaDAO _itemFacturaDao;
        private static TipoDocumentoDAO _tipoDocumentoDao;
        private static PesonaDAO _personaDao;
        private static DireccionDAO _direccionDao;
        private static PaisDAO _paisDao;
        private static ClienteDAO _clienteDao;

        public static FuncionDAO FuncionDAO { get { return _funcionDao ?? (_funcionDao = new FuncionDAO(_connection)); } }

        public static HotelDAO HotelDAO { get { return _hotelDao ?? (_hotelDao = new HotelDAO(_connection)); } }

        public static RolDAO RolDAO { get { return _rolDao ?? (_rolDao = new RolDAO(_connection)); } }

        public static UsuarioDAO UsuarioDAO { get { return _usuarioDao ?? (_usuarioDao = new UsuarioDAO(_connection)); } }

        public static ItemFacturaDAO ItemFacturaDAO { get { return _itemFacturaDao ?? (_itemFacturaDao = new ItemFacturaDAO(_connection)); } }

        public static TipoDocumentoDAO TipoDocumentoDAO { get { return _tipoDocumentoDao ?? (_tipoDocumentoDao = new TipoDocumentoDAO(_connection)); } }

        public static PesonaDAO PersonaDAO { get { return _personaDao ?? (_personaDao = new PesonaDAO(_connection)); } }

        public static DireccionDAO DireccionDAO { get { return _direccionDao ?? (_direccionDao = new DireccionDAO(_connection)); } }

        public static PaisDAO PaisDAO { get { return _paisDao ?? (_paisDao = new PaisDAO(_connection)); } }

        public static ClienteDAO ClienteDAO { get { return _clienteDao ?? (_clienteDao = new ClienteDAO(_connection)); } }
    }
}
