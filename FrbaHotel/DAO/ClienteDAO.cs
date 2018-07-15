using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FrbaHotel.Model;

namespace FrbaHotel.DAO
{
    public class ClienteDAO : BaseDAO<Cliente>
    {
        public ClienteDAO(DBConnection con) : base(con) { }

        public void CreateOrUpdate(Cliente cliente)
        {
            var personaQuery = DAOFactory.PersonaDAO.CreateOrUpdateScript(cliente.Persona);

            var query = personaQuery;
            query += "DECLARE @id_cliente int;";
            query += ArmarSentenciaSP("P_Guardar_Cliente", new[] {
                GetParam(cliente.Id),
                "@id_persona",
                GetParam(cliente.Baja),
                "@id_cliente output"
            });
            
            query = IncluirEnTransaccion(query);

            Connection.ExecuteQuery(query);
        }

        public List<Cliente> GetClientes(string tipoDocumento, decimal numeroDocumento, string mail, string vigencia)
        {
            var list = new List<Cliente>();

            var query = ArmarSentenciaSP("P_Obtener_Clientes", new[] { GetParam(tipoDocumento), GetParam(numeroDocumento), GetParam(mail), GetParamVigencia(vigencia) });
            var result = Connection.ExecuteQuery(query);
            
            if(result.Rows.Count > 0)
            {
                foreach(DataRow row in result.Rows)
                {
                    list.Add(new Cliente(row));
                }
            }
            return list;
        }

        public List<Cliente> GetClientesxEstadia(int estadiaId)
        {
            var list = new List<Cliente>();

            var query = ArmarSentenciaSP("P_Obtener_Huespedes_x_Estadia", new[] { GetParam(estadiaId) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Cliente(row));
                }
            }
            return list;
        }
    }
}
