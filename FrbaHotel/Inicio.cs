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

namespace FrbaHotel
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenLogin();
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLogin();
        }
        private void OpenLogin() {
            Hide();
            var login = new Login.Login(this);
            login.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {

        }

        public void SetUser(Usuario user)
        { 
        
        }
    }
}
