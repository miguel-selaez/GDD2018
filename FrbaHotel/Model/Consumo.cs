using FrbaHotel.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaHotel.Model
{
    public class Consumo : BaseData
    {
        public int Id { get; set; }
        public Estadia Estadia { get; set; }
        public Consumible Consumible { get; set; }
        public Habitacion Habitacion { get; set; }
        public Reserva Reserva { get; set; }
        public decimal cantidad { get; set; }
        SqlConnection conexion = new SqlConnection(@"Data Source = jeanpierre-pc\sqlserver2012; Initial Catalog = GD1C2018; Integrated Security = True");
        public int retorno;

        public Consumo() { 
        
        }

        public Consumo(DataRow row) {
            Row = row;

            Id = GetValue<int>("id_consumo");
            Estadia = new Estadia(row);
            Consumible = new Consumible(row);
            Habitacion = new Habitacion(row);
            Reserva = new Reserva(row);
            cantidad = GetValue<decimal>("cantidad");
        }

        public Consumo(Estadia estadia, Consumible consumible, Habitacion habitacion, Reserva reserva, decimal cantidad) {
            this.Estadia = estadia;
            this.Consumible = consumible;
            this.Habitacion = habitacion;
            this.Reserva = reserva;
            this.cantidad = cantidad;
        }

        public Consumo(Estadia estadia, Consumible consumible, Habitacion habitacion, decimal cantidad) {
            this.Estadia = estadia;
            this.Consumible = consumible;
            this.Habitacion = habitacion;
            this.cantidad = cantidad;
        }

        public void llenarProductos(ComboBox cb)
        {
        
            conexion.Open();
            SqlCommand cmd = new SqlCommand("NPM.P_Listar_Productos", conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {

                cb.Items.Add(dr["descripcion_cb"].ToString());
            }
            dr.Close();

            conexion.Close();
        }

        public int agregar(Consumo consumo) 
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("NPM.P_Insertar_consumo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@estadia",consumo.Estadia);
            cmd.Parameters.AddWithValue("@habitacion",consumo.Habitacion);
            cmd.Parameters.AddWithValue("@nombre",consumo.Consumible);
            cmd.Parameters.AddWithValue("@cantidad",consumo.cantidad);
            
            retorno = cmd.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
    }
}
