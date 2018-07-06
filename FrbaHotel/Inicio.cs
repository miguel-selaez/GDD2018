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
        private Session _session;

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

        public void SetSession(Usuario user, Hotel hotel, Rol rol)
        {
            _session = new Session() { 
                User = user, 
                Main = this,
                Hotel = hotel,
                Rol = rol
            };

            SetMenu();
        }

        private void SetMenu()
        {
            var menuCreator = new MenuCreator(_session);

            foreach (var funcion in _session.Rol.Funciones)
            {
                var itemFuncion = menuCreator.GetItemMenu(funcion);
                mainMenu.MdiWindowListItem = itemFuncion;
                mainMenu.Items.Add(itemFuncion);
            }   

            // Dock the MenuStrip to the top of the form.
            mainMenu.Dock = DockStyle.Top;

            // The Form.MainMenuStrip property determines the merge target.
            this.MainMenuStrip = mainMenu;
        }
    }
}
