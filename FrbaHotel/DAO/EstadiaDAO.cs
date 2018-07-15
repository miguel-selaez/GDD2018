using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class EstadiaDAO : BaseDAO<Model.Estadia>
    {
        public EstadiaDAO(DBConnection con) : base(con) { }



        public void RegistrarEstadia(Model.Estadia estadia)
        {
            var query = "DECLARE @id_estadia int;";
            query += ArmarSentenciaSP("P_Guardar_Reserva", new[] { 
                GetParam(estadia.Id),
                GetParam(estadia.Reserva),
                GetParam(estadia.UsuarioIngreso),
                GetParam(estadia.FechaIngreso),
                GetParam(estadia.FechaSalida),
                "@id_estadia output"
            });

            foreach (var cliente in estadia.Huespedes)
            {
                query += ArmarSentenciaSP("P_Guardar_Huesped_x_Estadia", new[] {
                    GetParam(cliente.Id),
                    "@id_reserva"
                });
            }
            query = IncluirEnTransaccion(query);

            Connection.ExecuteNoQuery(query);
        }

        public Model.Estadia GetEstadiaxReserva(decimal reservaId)
        {
            List<Model.Estadia> list = new List<Model.Estadia>();

            var query = ArmarSentenciaSP("P_Obtener_Estadia_x_Reserva", new[] { GetParam(reservaId) });
            var result = Connection.ExecuteQuery(query);

            var reserva = result.Rows.Count > 0 ? new Model.Estadia(result.Rows[0]) : null;

            return reserva;
        }
    }
}
