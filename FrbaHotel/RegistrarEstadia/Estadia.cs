using FrbaHotel.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarEstadia
{
    public partial class Estadia : Form
    {
        private Model.Session _session;
        private Model.Reserva _reserva;
        private List<Model.Cliente> _clientes = new List<Model.Cliente>();
        private Model.Estadia _editObject;

        public Estadia(Model.Session session, Model.Reserva reserva)
        {
            this._session = session;
            this._reserva = reserva;
            InitializeComponent();
            BindReserva();
        }

        private void BindReserva()
        {
            txtCodigo.Text = _reserva.Id.ToString();
            txtCliente.Text = _reserva.Cliente.Persona.Nombre + " " + _reserva.Cliente.Persona.Apellido;

            txtCodigo.ReadOnly = true;
            txtCliente.ReadOnly = true;

            _editObject = GetEstadiaxReserva();
            if (_editObject != null)
            {
                _clientes = _editObject.Huespedes;
                dtFin.Visible = true;
                lblCheckout.Visible = true;
                btnAddClientes.Enabled = false;
            }

            BindClientes();
        }

        private Model.Estadia GetEstadiaxReserva()
        {
            return DAO.DAOFactory.EstadiaDAO.GetEstadiaxReserva(_reserva.Id);
        }

        private void BindClientes()
        {
            dgClientes.Rows.Clear();
            
            foreach (Model.Cliente cliente in _clientes)
            {
                var index = dgClientes.Rows.Add();
                dgClientes.Rows[index].Cells["Apellido"].Value = cliente.Persona.Apellido;
                dgClientes.Rows[index].Cells["Nombre"].Value = cliente.Persona.Nombre;
                dgClientes.Rows[index].Cells["Mail"].Value = cliente.Persona.Mail;
                dgClientes.Rows[index].Cells["Tipo_Documento"].Value = cliente.Persona.TipoDocumento.Descripcion;
                dgClientes.Rows[index].Cells["Nro_Documento"].Value = cliente.Persona.NumeroDocumento;
                dgClientes.Rows[index].Cells["Eliminar"].Value = "Eliminar";
            }
        }

        private void btnAddClientes_Click(object sender, EventArgs e)
        {
            var formClientes = new AbmCliente.ListadoCliente(_session, this);
            formClientes.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();

                if (_editObject == null || _editObject.Id == 0)
                {
                    _editObject = new Model.Estadia(0, _reserva, _session.User, Tools.GetDate(), null, null);
                    _clientes.Add(_reserva.Cliente);
                }
                else
                {
                    _editObject.UsuarioSalida = _session.User;
                    _editObject.Reserva = _reserva;
                    _editObject.FechaSalida = dtFin.Value;
                }
                _editObject.Huespedes = _clientes;

                DAO.DAOFactory.EstadiaDAO.RegistrarEstadia(_editObject);

                Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error:";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        private void ValidateForm()
        {
            if (_editObject != null && DateTime.Compare(this.dtInicio.Value, dtFin.Value) > 0)
            {
                throw new ValidateException("La fecha de inicio no puede ser mayor que la de fin.");
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _clientes.RemoveAt(e.RowIndex);
                BindClientes();
            }
        }

        internal void AddCliente(Model.Cliente selectedCliente)
        {
            _clientes.Add(selectedCliente);
            BindClientes();
        }
    }
}
