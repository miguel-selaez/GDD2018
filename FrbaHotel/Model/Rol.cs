using FrbaHotel.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Rol : BaseData
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Baja { get; set; }

        private List<Funcion> _funciones;

        public List<Funcion> Funciones
        {
            get { return _funciones ?? (_funciones = DAOFactory.FuncionDAO.GetFuncionesByRol(Id)); }
        }

        public Rol(DataRow row) {
            Row = row;

            Id = GetValue<int>("id_rol");
            Descripcion = GetValue<string>("descripcion");
            Baja = GetValue<bool>("baja");
        }
    }
}
