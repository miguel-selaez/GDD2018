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

                dgHabitaciones.Rows.Clear();
                _result = GetResult();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error de Validación";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        private void BindHabitaciones()
        {
            dgHabitaciones.Rows.Clear();
            var precios = new List<decimal>();

            foreach (Model.Habitacion habitacion in _result.Habitaciones)
            {
                var index = dgHabitaciones.Rows.Add();
                dgHabitaciones.Rows[index].Cells["Numero"].Value = habitacion.Numero.ToString();
                dgHabitaciones.Rows[index].Cells["Piso"].Value = habitacion.Piso.ToString();
                dgHabitaciones.Rows[index].Cells["TipoHabitacion"].Value = habitacion.TipoHabitacion.Descripcion;
                dgHabitaciones.Rows[index].Cells["Ubicacion"].Value = habitacion.Frente == "N" ? "Interior" : "Exterior";
                dgHabitaciones.Rows[index].Cells["Precio"].Value = "";//.ToString("0.00");
            }

            txtTotalReserva.Text = precios.Sum().ToString();
        }

        private Model.Reserva GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
