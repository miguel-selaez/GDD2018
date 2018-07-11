using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class PesonaDAO: BaseDAO<Persona>
    {
        public PesonaDAO(DBConnection con) : base(con) { }

        public string CreateOrUpdateScript(Persona persona){
            var direccionQuery = DAOFactory.DireccionDAO.CreateOrUpdateScript(persona.Direccion);

            var query = direccionQuery;
            query += "DECLARE @id_persona int;";

            query += ArmarSentenciaSP("P_Alta_Persona", new[] { 
                GetParam(persona.Id), 
                GetParam(persona.Nombre), 
                GetParam(persona.Apellido),
                GetParam(persona.FechaNacimiento),
                GetParam(persona.Telefono), 
                GetParam(persona.TipoDocumento),
                GetParam(persona.NumeroDocumento),
                "@id_direccion",
                GetParam(persona.Mail),
                GetParam(persona.Nacionalidad),
                GetParam(persona.Inconsistente),
                "@id_persona output"
            });
            return query;
        } 
    }
}
