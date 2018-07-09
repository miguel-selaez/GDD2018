using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class Rol : Form
    {
        private Session _session;
        private Rol _editObject;

        public Rol(Session session)
        {
            InitializeComponent();
            _session = session;
        }
        public Rol(Session session, Rol editRol)
        {
            InitializeComponent();
            _session = session;
            _editObject = editRol;
        }

    }
}
