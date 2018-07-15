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
    public partial class BuscarReserva : Form
    {
        private Model.Session _session;
        private Model.Reserva _result;

        public BuscarReserva(Model.Session _session)
        {
            this._session = _session;
            InitializeComponent();
            InitValues();
        }

        private void InitValues()
        {
            dtInicio.Value = Tools.GetDate();
            dtFin.Value = Tools.GetDate();

            txtTotalReserva.Text = "0";
            btnModificar.Enabled = false;
            btnEstadia.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    throw new ValidateException("El código no puede estar vacío.");
                }

                _result = GetResult();
                if (_result == null)
                {
                    BindReserva();
                    BindHabitaciones();
                }
                else {
                    string message = "El código que ingreso no corresponde con ninguno en nuestro sistema. \n Vuelva a intentar.";
                    string caption = "Reserva";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error de Validación";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        private void BindReserva()
        {
            txtCliente.Text = _result.Cliente.Persona.Nombre + " " +_result.Cliente.Persona.Apellido;
            txtHotel.Text = _result.Hotel.Nombre;
            txtRegimen.Text = _result.Regimen.Descripcion;
            txtTotalReserva.Text = _result.TotalReserva.ToString("0.00");
            txtEstado.Text = _result.Estado.Descipcion;

            dtInicio.Value = _result.FechaInicio ?? Tools.GetDate();
            dtFin.Value = _result.FechaFin ?? Tools.GetDate();

            btnModificar.Enabled = 
                (_result.Estado.Descipcion == "CORRECTA" || _result.Estado.Descipcion == "MODIFICADA")
                && _result.FechaInicio > Tools.GetDate();
            btnEstadia.Enabled =
                (_result.Estado.Descipcion == "CORRECTA"
                || _result.Estado.Descipcion == "MODIFICADA"
                || _result.Estado.Descipcion == "CON INGRESO")
                && Tools.GetDate() >= _result.FechaInicio
                && Tools.GetDate() <= _result.FechaFin;
            btnCancelar.Enabled = btnModificar.Enabled;
        }

        private void BindHabitaciones()
        {
            dgHabitaciones.Rows.Clear();
            var precios = new List<decimal>();

            foreach (Model.HabitacionReservada habitacion in _result.Habitaciones)
            {
                var index = dgHabitaciones.Rows.Add();
                dgHabitaciones.Rows[index].Cells["Numero"].Value = habitacion.Habitacion.Numero.ToString();
                dgHabitaciones.Rows[index].Cells["Piso"].Value = habitacion.Habitacion.Piso.ToString();
                dgHabitaciones.Rows[index].Cells["TipoHabitacion"].Value = habitacion.Habitacion.TipoHabitacion.Descripcion;
                dgHabitaciones.Rows[index].Cells["Ubicacion"].Value = habitacion.Habitacion.Frente == "N" ? "Interior" : "Exterior";
                dgHabitaciones.Rows[index].Cells["Precio"].Value = habitacion.TotalHabitacion.ToString("0.00");
            }
        }

        private Model.Reserva GetResult()
        {
            var reservaId = decimal.Parse(txtCodigo.Text);
            return DAO.DAOFactory.ReservaDAO.GetReservaByCode(reservaId);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var form = new CancelarReserva.CancelarReserva(_session, _result);
            form.Show();
        }

        private void btnEstadia_Click(object sender, EventArgs e)
        {
            var form = new RegistrarEstadia.Estadia(_session, _result);
            form.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var form = new Reservas.Reserva(_session, _result);
            form.Show();
        }
    }
}
