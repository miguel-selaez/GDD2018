using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaHotel.Model;


namespace FrbaHotel.RegistrarConsumible
{
    public partial class Consumos : Form
    {
        SqlConnection conexion = new SqlConnection(@"Data Source = jeanpierre-pc\sqlserver2012; Initial Catalog = GD1C2018; Integrated Security = True");
        private Session _session;
        public Consumos(Session session)
        {
            InitializeComponent();
            _session = session;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Consumo_Load(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("NPM.P_Listar_Habitaciones_Hotel", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@hotel", _session.Hotel.Id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                combo_habitacion.Items.Add(dr["numero"].ToString());
            }
            dr.Close();

            conexion.Close();

            Consumo c = new Consumo();
            c.llenarProductos(comboBox1);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string estadia = txt_estadia.Text;
            string habitacion = combo_habitacion.Text;
            string nombre = comboBox1.Text;
            string cantidad = txt_cantidad.Text;

            


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_estadia.Text = "";
            combo_habitacion.Text = "";
            comboBox1.Text = null;
            txt_cantidad.Text = "";

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
