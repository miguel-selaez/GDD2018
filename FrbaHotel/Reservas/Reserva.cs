using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Reservas
{
    public partial class Reserva : Form
    {
        private Model.Session _session;

        public Reserva(Model.Session _session)
        {
            // TODO: Complete member initialization
            this._session = _session;
            InitializeComponent();
        }
    }
}
