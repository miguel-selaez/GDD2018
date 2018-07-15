using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class Habitacion : Form
    {
        private Model.Session _session;

        public Habitacion(Model.Session _session)
        {
            // TODO: Complete member initialization
            this._session = _session;
            InitializeComponent();
           // InitValues();
        }

        public void InitValues()
        {
            var pisosHotel = DAO.DAOFactory.HabitacionDAO.GetHabitacionsXHotel(_session.Hotel, "No");
            IList<decimal> pisos = new List<decimal>();

            if (pisosHotel.Any())
            {
                BindCbPisos(pisosHotel);
            }
        }

        private void BindCbPisos(List<Model.Habitacion> pisos)
        {
            cbPiso.DataSource = null;
            cbPiso.DataSource = pisos;
            cbPiso.DisplayMember = "piso";
            cbPiso.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
