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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class Facturacion : Form
    {

        SqlConnection conexion = new SqlConnection(@"Data Source = jeanpierre-pc\sqlserver2012; Initial Catalog = GD1C2018; Integrated Security = True");
       
        private Model.Session _session;

        public Facturacion(Model.Session _session)
        {
            // TODO: Complete member initialization
            this._session = _session;
            InitializeComponent();
        }

        private void btn_fact_Click(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("NPM.P_Listar_Consumos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@estadia", txt_estadia.Text);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
