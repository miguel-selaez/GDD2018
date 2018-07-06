using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class BajaHotel : Form
    {
        private Model.Session _session;

        public BajaHotel(Model.Session _session)
        {
            // TODO: Complete member initialization
            this._session = _session;
            InitializeComponent();
        }
    }
}
