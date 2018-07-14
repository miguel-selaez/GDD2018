using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class ReservaDAO : BaseDAO<Model.Reserva>
    {
        public ReservaDAO(DBConnection con) : base(con) { }

        public string SaveOrUpdate(Model.Reserva reserva)
        {
            var query = "DECLARE @id_reserva int;";
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
                GetParam(reserva.Estado),
                "@id_reserva output"
            });

            foreach (var habitacion in reserva.Habitaciones)
            {
                query += ArmarSentenciaSP("P_Guardar_Habitaciones_Reservadas", new[] { "@id_reserva", GetParam(habitacion) });
            }
            query = "SELECT @id_reserva;";
            query = IncluirEnTransaccion(query);

            return Connection.ExecuteSingleResult(query);
        }
    }
}
