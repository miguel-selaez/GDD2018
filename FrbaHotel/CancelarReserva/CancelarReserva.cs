using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.CancelarReserva
{
    public partial class CancelarReserva : Form
    {
        private Model.Session _session;
        private Model.Reserva _reserva;

        public CancelarReserva(Model.Session session, Model.Reserva reserva)
        {
            _session = session;
            _reserva = reserva;
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
