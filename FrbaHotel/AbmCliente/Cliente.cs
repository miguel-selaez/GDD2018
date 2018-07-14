using System.Text.RegularExpressions;
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

namespace FrbaHotel.AbmCliente
{
    public partial class Cliente : Form
    {
        private Model.Session _session;
        private Model.Cliente _editObject;
        private ListadoCliente _listado;


        public Cliente(Model.Session session)
        {
            this._session = session;
            InitializeComponent();
            InitValues();
        }

        public Cliente(Model.Session session, Model.Cliente selectedCliente, ListadoCliente listadoCliente)
        {
            this._session = session;
            this._editObject = selectedCliente;
            this._listado = listadoCliente;
            InitializeComponent();
            InitValues();
            BindCliente();
        }

        private void InitValues()
        {
            dtFechaNacimiento.Value = Tools.GetDate();
            dtFechaNacimiento.MaxDate = Tools.GetDate().AddYears(18);
            var tiposDocumento = DAO.DAOFactory.TipoDocumentoDAO.GetTiposDocumento("", "Si");

            if (tiposDocumento.Any())
            {
                BindCbTiposDocumento(tiposDocumento);
            }
        }

        private void ValidarComponentes()
        {
        }

        private int IndexOfBindTipoDocumento(int id)
        {
            var list = (List<Model.TipoDocumento>)cbTipoDocumento.DataSource;
            return list.FindIndex(t => t.Id == id);
        }

        private void BindCliente()
        {
            txtNombre.Text = _editObject.Persona.Nombre;
            txtApellido.Text = _editObject.Persona.Apellido;
            cbTipoDocumento.SelectedIndex = IndexOfBindTipoDocumento(_editObject.Persona.TipoDocumento.Id);
            txtNroDocumento.Text = _editObject.Persona.NumeroDocumento.ToString();
            txtMail.Text = _editObject.Persona.Mail;
            txtTelefono.Text = _editObject.Persona.Telefono;
            txtNacionalidad.Text = _editObject.Persona.Nacionalidad.Descripcion;
            dtFechaNacimiento.Value = _editObject.Persona.FechaNacimiento ?? Tools.GetDate();
            txtCalle.Text = _editObject.Persona.Direccion.Calle;
            txtAltura.Text = _editObject.Persona.Direccion.NumeroCalle.ToString();
            txtPiso.Text = _editObject.Persona.Direccion.Piso.ToString();
            txtDepartamento.Text = _editObject.Persona.Direccion.Departamento;
            txtCiudad.Text = _editObject.Persona.Direccion.Ciudad;
            txtPais.Text = _editObject.Persona.Direccion.Pais.Descripcion;
            rbNo.Checked = _editObject.Baja;
            rbSi.Checked = !_editObject.Baja;
        }

        private void BindCbTiposDocumento(List<Model.TipoDocumento> tiposDocumento)
        {
            cbTipoDocumento.DataSource = null;
            cbTipoDocumento.DataSource = tiposDocumento;
            cbTipoDocumento.DisplayMember = "Descripcion";
            cbTipoDocumento.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();
                var vigente = rbNo.Checked ? true : false;


                if (_editObject == null || _editObject.Id == 0)
                {
                    var direccion = new Model.Direccion(
                        txtCalle.Text,
                        Decimal.Parse(txtAltura.Text),
                        int.Parse(txtPiso.Text),
                        txtDepartamento.Text,
                        txtCiudad.Text,
                        DAO.DAOFactory.PaisDAO.GetPaises().Where(pais => pais.isName(txtPais.Text)).First());

                    var datosPersona = new Model.Persona(
                        txtNombre.Text,
                        txtApellido.Text,
                        dtFechaNacimiento.Value,
                        txtTelefono.Text,
                        (Model.TipoDocumento)cbTipoDocumento.SelectedValue,
                        Decimal.Parse(txtNroDocumento.Text),
                        direccion,
                        txtMail.Text,
                        DAO.DAOFactory.PaisDAO.GetPaises().Where(pais => pais.isNacionalidad(txtNacionalidad.Text)).First(),
                        false);
                    _editObject = new Model.Cliente(datosPersona, vigente);
                }

                else
                {
                    _editObject.Baja = vigente;
                    _editObject.Persona.Nombre = txtNombre.Text;
                    _editObject.Persona.Apellido = txtApellido.Text;
                    _editObject.Persona.Mail = txtMail.Text;
                    _editObject.Persona.Telefono = txtTelefono.Text;
                    _editObject.Persona.TipoDocumento = (Model.TipoDocumento)cbTipoDocumento.SelectedValue;
                    _editObject.Persona.NumeroDocumento = Decimal.Parse(txtNroDocumento.Text);
                    _editObject.Persona.FechaNacimiento = dtFechaNacimiento.Value;
                    _editObject.Persona.Direccion.Calle = txtCalle.Text;
                    _editObject.Persona.Direccion.NumeroCalle = Decimal.Parse(txtAltura.Text);
                    _editObject.Persona.Direccion.Piso = Decimal.Parse(txtPiso.Text);
                    _editObject.Persona.Direccion.Departamento = txtDepartamento.Text;
                    _editObject.Persona.Direccion.Ciudad = txtCiudad.Text;
                    _editObject.Persona.Direccion.Pais = DAO.DAOFactory.PaisDAO.GetPaises().Where(pais => pais.isName(txtPais.Text)).First();
                }
                DAO.DAOFactory.ClienteDAO.CreateOrUpdate(_editObject);

                if (_listado != null)
                    _listado.UpdateClientes();

                Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error de Validación";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        private void ValidateForm()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                throw new ValidateException("El nombre no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                throw new ValidateException("El apellido no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(txtNroDocumento.Text) || string.IsNullOrWhiteSpace(txtNroDocumento.Text))
            {
                throw new ValidateException("El Nro de Documento no puede estar vacío.");
            }
            if (!Regex.IsMatch(txtNroDocumento.Text, @"[0-9]+"))
            {
                throw new ValidateException("El Nro de Documento debe estar compuesto por números únicamente.");
            }
            if (string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrWhiteSpace(txtMail.Text))
            {
                throw new ValidateException("El mail no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                throw new ValidateException("El teléfono no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(txtNacionalidad.Text) || string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                throw new ValidateException("La nacionalidad no puede estar vacía.");
            }
            if (string.IsNullOrEmpty(txtCalle.Text) || string.IsNullOrWhiteSpace(txtCalle.Text))
            {
                throw new ValidateException("La calle no puede estar vacía.");
            }
            if (string.IsNullOrEmpty(txtAltura.Text) || string.IsNullOrWhiteSpace(txtAltura.Text))
            {
                throw new ValidateException("La altura no puede estar vacía.");
            }
            if (string.IsNullOrEmpty(txtPais.Text) || string.IsNullOrWhiteSpace(txtPais.Text))
            {
                throw new ValidateException("El país no puede estar vacío.");
            } 
            if (rbSi.Checked == false && rbNo.Checked == false)
            {
                throw new ValidateException("Debe seleccionar la vigencia del usuario");
            }
            if(DateTime.Compare(dtFechaNacimiento.Value, Tools.GetDate()) > 0)
            {
                throw new ValidateException("La fecha de nacimiento no puede ser mayor a la actual");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
