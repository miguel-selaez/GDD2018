using FrbaHotel.DAO;
using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace FrbaHotel.RegistrarConsumible
{
    public partial class ListadoConsumos :Form
    {
        SqlConnection conexion = new SqlConnection(@"Data Source = jeanpierre-pc\sqlserver2012; Initial Catalog = GD1C2018; Integrated Security = True");
       
        private Session _session;
        public ListadoConsumos(Session session)
        {
            InitializeComponent();
            _session = session;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("NPM.P_Listar_Consumos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", txt_reserva.Text);
            cmd.Parameters.AddWithValue("@habitacion", txt_habitacion.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgConsumos.DataSource = dt;
            conexion.Close();
                        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_reserva.Text = "";
            txt_habitacion.Text = "";
            dgConsumos.DataSource = null;
        }

    }
}
