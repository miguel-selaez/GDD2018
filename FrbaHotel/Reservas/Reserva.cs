using FrbaHotel.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private List<Model.HabitacionReservada> _habitaciones;
        private Model.Cliente _cliente;
        private Model.Reserva _editObject;

        public Reserva(Model.Session _session)
        {
            this._session = _session;
            InitializeComponent();
            InitValues();
        }

        public Reserva(Model.Session _session, Model.Reserva reserva)
        {
            this._session = _session;
            this._editObject = reserva;
            InitializeComponent();
            InitValues();
            BindReserva();
        }

        private void BindReserva()
        {
            _cliente = _editObject.Cliente;
            btnSelectCliente.Enabled = false;
            txtCliente.Text = _editObject.Cliente.Persona.Nombre + " " + _editObject.Cliente.Persona.Apellido;
            cbHoteles.SelectedIndex = IndexOfHoteles(_editObject.Hotel.Id);
            cbRegimenes.SelectedIndex = IndexOfRegimenes(_editObject.Regimen.Id);
            txtTotalReserva.Text = _editObject.TotalReserva.ToString("0.00");

            _habitaciones = _editObject.Habitaciones;
            BindHabitaciones();

            dtInicio.Value = _editObject.FechaInicio ?? Tools.GetDate();
            dtFin.Value = _editObject.FechaFin ?? Tools.GetDate();
        }

        private int IndexOfRegimenes(int id)
        {
            var list = (List<Model.Regimen>)cbRegimenes.DataSource;
            return list.FindIndex(t => t.Id == id);
        }

        private int IndexOfHoteles(int id)
        {
            var list = (List<Model.Hotel>)cbHoteles.DataSource;
            return list.FindIndex(t => t.Id == id);
        }

        private void InitValues()
        {
            _habitaciones = new List<Model.HabitacionReservada>();
            dtInicio.Value = Tools.GetDate();
            dtFin.Value = Tools.GetDate();

            dtInicio.MinDate = Tools.GetDate();
            dtInicio.MaxDate = Tools.GetDate().AddYears(3);

            dtFin.MinDate = Tools.GetDate();
            dtFin.MaxDate = Tools.GetDate().AddYears(3);

            txtTotalReserva.Text = "0";
            
            var hoteles = new List<Model.Hotel>();
            if (_session.Hotel == null)
            {
                hoteles = DAO.DAOFactory.HotelDAO.GetHoteles("", "Si");
                cbHoteles.Enabled = true;
            }
            else {
                hoteles.Add(_session.Hotel);
            }
            BindCbHoteles(hoteles);

            var regimenes = DAO.DAOFactory.TipoRegimenDAO.GetRegimenesByHotel(hoteles.First().Id);

            if (regimenes.Any())
            {
                BindCbRegimenes(regimenes);
            }
        }

        private void BindCbRegimenes(List<Model.Regimen> regimenes)
        {
            cbRegimenes.DataSource = null;
            cbRegimenes.DataSource = regimenes;
            cbRegimenes.DisplayMember = "Descripcion";
            cbRegimenes.SelectedIndex = 0;
        }
        private void BindCbHoteles(List<Model.Hotel> hoteles)
        {
            cbHoteles.DataSource = null;
            cbHoteles.DataSource = hoteles;
            cbHoteles.DisplayMember = "Nombre";
            cbHoteles.SelectedIndex = 0;
        }

        public void AddHabitacion(Model.Habitacion selectedHabitacion)
        {
            var nueva = new Model.HabitacionReservada(selectedHabitacion, 0);
            _habitaciones.Add(nueva);
            BindHabitaciones();
        }

        private void BindHabitaciones()
        {
            dgHabitaciones.Rows.Clear();

            foreach (Model.HabitacionReservada habitacion in _habitaciones)
            {
                habitacion.TotalHabitacion = CalcularPrecio(habitacion.Habitacion.TipoHabitacion);
                var index = dgHabitaciones.Rows.Add();
                dgHabitaciones.Rows[index].Cells["Numero"].Value = habitacion.Habitacion.Numero.ToString();
                dgHabitaciones.Rows[index].Cells["Piso"].Value = habitacion.Habitacion.Piso.ToString();
                dgHabitaciones.Rows[index].Cells["TipoHabitacion"].Value = habitacion.Habitacion.TipoHabitacion.Descripcion;
                dgHabitaciones.Rows[index].Cells["Ubicacion"].Value = habitacion.Habitacion.Frente == "N" ? "Interior" : "Exterior";
                dgHabitaciones.Rows[index].Cells["Precio"].Value = habitacion.TotalHabitacion.ToString("0.00");
                dgHabitaciones.Rows[index].Cells["Eliminar"].Value = "Eliminar";
            }

            txtTotalReserva.Text = _habitaciones.Sum(h => h.TotalHabitacion).ToString("0.00");
        }

        private decimal CalcularPrecio(Model.TipoHabitacion tipoHabitacion)
        {
            var regimen = (Model.Regimen)cbRegimenes.SelectedValue;
            var hotel = (Model.Hotel) cbHoteles.SelectedValue;
            var incremento = Decimal.Parse(ConfigurationManager.AppSettings["IncremetoEstrellas"]);
            return (tipoHabitacion.Porcentual * regimen.Precio) + (incremento * hotel.Estrellas); 
        }

        public void SetCliente(Model.Cliente cliente) {
            _cliente = cliente;
            txtCliente.Text = cliente.Persona.Nombre + " " + cliente.Persona.Apellido;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Compare(this.dtInicio.Value, dtFin.Value) > 0)
                {
                    throw new ValidateException("La fecha de inicio no puede ser mayor que la de fin.");
                }

                var hotel = (Model.Hotel)cbHoteles.SelectedValue;
                var buscador = new BuscarHabitacion(this, hotel, dtInicio.Value, dtFin.Value);
                buscador.Show();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error:";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();
                var regimen = (Model.Regimen)cbRegimenes.SelectedValue;
                var hotel = (Model.Hotel)cbHoteles.SelectedValue;

                var totalReserva = Decimal.Parse(txtTotalReserva.Text);

                if (_editObject == null || _editObject.Id == 0)
                {
                    _editObject = new Model.Reserva(0, _session.User, hotel, regimen, _cliente, Tools.GetDate(),
                    dtInicio.Value, dtFin.Value, totalReserva, null);
                }
                else
                {
                    _editObject.Hotel = hotel;
                    _editObject.Regimen = regimen;
                    _editObject.FechaInicio = dtInicio.Value;
                    _editObject.FechaFin = dtFin.Value;
                    _editObject.TotalReserva = totalReserva;
                }
                _editObject.Habitaciones = _habitaciones;

                var codigo = DAO.DAOFactory.ReservaDAO.SaveOrUpdate(_editObject, _session.User, Tools.GetDate());

                string message = "Su reserva ha sido guardada con éxito.\n Su código de reserva es : " 
                    + codigo + ". \nGuardelo para realizar el ingreso al hotel y realizar modificaciones." ;
                string caption = "Reserva " + codigo;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                var result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Close();
                }
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
            if (string.IsNullOrEmpty(txtCliente.Text) || string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                throw new ValidateException("El cliente no puede estar vacío.");
            }
            if (DateTime.Compare(this.dtInicio.Value, dtFin.Value) > 0)
            {
                throw new ValidateException("La fecha de inicio no puede ser mayor que la de fin.");
            }
        }

        private void cbRegimenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindHabitaciones();
        }

        private void btnSelectCliente_Click(object sender, EventArgs e)
        {
            var listado = new AbmCliente.ListadoCliente(_session, this);
            listado.Show();
        }

        private void dgHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _habitaciones.RemoveAt(e.RowIndex);
                BindHabitaciones();
            }
        }
    }
}