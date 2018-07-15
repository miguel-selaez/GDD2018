using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Exceptions;

namespace FrbaHotel.AbmCliente
{
    public partial class ListadoCliente : Form
    {
        private Model.Session _session;
        private List<Model.Cliente> _results;
        private Reservas.Reserva _reserva;
        private RegistrarEstadia.Estadia _estadia;

        public ListadoCliente(Model.Session _session)
        {
            this._session = _session;
            InitializeComponent();
            InitValues();
        }

        public ListadoCliente(Model.Session _session, Reservas.Reserva reserva)
        {
            this._session = _session;
            this._reserva = reserva;
            InitializeComponent();
            InitValues();
        }

        public ListadoCliente(Model.Session _session, RegistrarEstadia.Estadia estadia)
        {
            this._session = _session;
            this._estadia = estadia;
            InitializeComponent();
            InitValues();
        }

        private void InitValues()
        {
            cbVigencia.SelectedIndex = 0;
            var tiposDocumentos = DAO.DAOFactory.TipoDocumentoDAO.GetTiposDocumento("","Si");
            tiposDocumentos.Add(new Model.TipoDocumento(0, "TODOS", false));

            if (tiposDocumentos.Any())
            {
                BindCbTiposDocumento(tiposDocumentos);
            }
        }

        private void BindCbTiposDocumento(List<Model.TipoDocumento> tiposDocumento)
        {
            cbTipoDocumento.DataSource = null;
            cbTipoDocumento.DataSource = tiposDocumento;
            cbTipoDocumento.DisplayMember = "Descripcion";
            cbTipoDocumento.SelectedIndex = 0;
        }

        public List<Model.Cliente> GetResults()
        {
            var tipoDocumento = (Model.TipoDocumento)cbTipoDocumento.SelectedValue;
            var nroDocumento = string.IsNullOrEmpty(txtNroDocumento.Text) ? 0 : decimal.Parse(txtNroDocumento.Text);

            return DAO.DAOFactory.ClienteDAO.GetClientes(
                    tipoDocumento.Descripcion,
                    nroDocumento,
                    txtMail.Text,
                    cbVigencia.SelectedItem.ToString());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(txtNroDocumento.Text, @"[0-9]*"))
                {
                    throw new ValidateException("El Nro de Documento debe estar compuesto por números únicamente.");
                }
                dgClientes.Rows.Clear();
                _results = GetResults();

                foreach (Model.Cliente cliente in _results)
                {
                    var index = dgClientes.Rows.Add();
                    dgClientes.Rows[index].Cells["Apellido"].Value = cliente.Persona.Apellido;
                    dgClientes.Rows[index].Cells["Nombre"].Value = cliente.Persona.Nombre;
                    dgClientes.Rows[index].Cells["Mail"].Value = cliente.Persona.Mail;
                    dgClientes.Rows[index].Cells["Tipo_Documento"].Value = cliente.Persona.TipoDocumento.Descripcion;
                    dgClientes.Rows[index].Cells["Nro_Documento"].Value = cliente.Persona.NumeroDocumento;
                    dgClientes.Rows[index].Cells["Vigencia"].Value = cliente.Baja ? "No" : "Si";
                    dgClientes.Rows[index].Cells["Editar"].Value = "Seleccionar";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error de Validación";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                txtNroDocumento.Clear();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMail.Text = "";
            txtNroDocumento.Text = "";
            cbTipoDocumento.SelectedIndex = 0;
            cbVigencia.SelectedIndex = 0;
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedCliente = _results.ElementAt(e.RowIndex);
                if (_reserva != null)
                {
                    _reserva.SetCliente(selectedCliente);
                    this.Close();
                }
                else if (_estadia != null)
                {
                    _estadia.AddCliente(selectedCliente);
                    this.Close();
                }
                else
                {
                    var nuevo = new Cliente(_session, selectedCliente, this);
                    nuevo.Show();
                }
            }
        }

        public void UpdateClientes()
        {
            btnBuscar.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var nuevo = new Cliente(_session);
            nuevo.Show();
        }
    }
}
