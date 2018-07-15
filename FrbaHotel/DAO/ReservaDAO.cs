using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class ReservaDAO : BaseDAO<Model.Reserva>
    {
        public ReservaDAO(DBConnection con) : base(con) { }

        public string SaveOrUpdate(Model.Reserva reserva, Model.Usuario usuarioMod, DateTime fechaMod)
        {
            var query = "DECLARE @id_reserva numeric(18,0);";
            query += ArmarSentenciaSP("P_Guardar_Reserva", new[] { 
                GetParam(reserva.Id),
                GetParam(reserva.UsuarioCreacion),
                GetParam(reserva.Hotel),
                GetParam(reserva.Regimen),
                GetParam(reserva.Cliente),
                GetParam(reserva.FechaCreacion),
                GetParam(reserva.FechaInicio),
                GetParam(reserva.FechaFin),
                GetParam(reserva.TotalReserva),
                GetParam(usuarioMod),
                GetParam(fechaMod),
                "@id_reserva output"
            });

            foreach (var habitacion in reserva.Habitaciones)
            {
                query += ArmarSentenciaSP("P_Guardar_Habitaciones_Reservadas", new[] {
                    "@id_reserva", 
                    GetParam(habitacion),
                    GetParam(habitacion.TotalHabitacion)
                });
            }
            query += "SELECT @id_reserva;";
            query = IncluirEnTransaccion(query);

            return Connection.ExecuteSingleResult(query);
        }

        public Model.Reserva GetReservaByCode(decimal reservaId )
        {
            List<Model.Reserva> list = new List<Model.Reserva>();

            var query = ArmarSentenciaSP("P_Obtener_Reserva", new[] { GetParam(reservaId) });
            var result = Connection.ExecuteQuery(query);
            
            var reserva = result.Rows.Count > 0 ? new Model.Reserva(result.Rows[0]) : null;

            return reserva;
        }
    }
}
