using FrbaHotel.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Reservas
{
    public partial class BuscarHabitacion : Form
    {
        private Model.Hotel _hotel;
        private DateTime _desde;
        private DateTime _hasta;
        private Reserva _reserva;
        private List<Model.Habitacion> _results;

        public BuscarHabitacion(Reserva reserva, Model.Hotel hotel, DateTime desde, DateTime hasta)
        {
            InitializeComponent();
            _hotel = hotel;
            _desde = desde;
            _hasta = hasta;
            _reserva = reserva;
            InitValues();
        }

        private void InitValues()
        {
            var tiposHabitacion = DAO.DAOFactory.TipoHabitacionDAO.GetTiposHabitacionByHotel(_hotel.Id);

            if (tiposHabitacion.Any())
            {
                BindCbTiposHabitacion(tiposHabitacion);
            }
        }

        private void BindCbTiposHabitacion(List<Model.TipoHabitacion> tiposHabitacion)
        {
            cbTipoHabitacion.DataSource = null;
            cbTipoHabitacion.DataSource = tiposHabitacion;
            cbTipoHabitacion.DisplayMember = "Descripcion";
            cbTipoHabitacion.SelectedIndex = 0;
        }

        private void dgHabitacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedHabitacion = _results.ElementAt(e.RowIndex);
            _reserva.AddHabitacion(selectedHabitacion);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgHabitacion.Rows.Clear();
            _results = GetResults();

            foreach (Model.Habitacion habitacion in _results)
            {
                var index = dgHabitacion.Rows.Add();
                dgHabitacion.Rows[index].Cells["Numero"].Value = habitacion.Numero.ToString();
                dgHabitacion.Rows[index].Cells["Piso"].Value = habitacion.Piso.ToString();
                dgHabitacion.Rows[index].Cells["TipoHabitacion"].Value = habitacion.TipoHabitacion.Descripcion;
                dgHabitacion.Rows[index].Cells["Ubicacion"].Value = habitacion.Frente == "N" ? "Interior" : "Exterior";
                dgHabitacion.Rows[index].Cells["Seleccionar"].Value = "Seleccionar";
            }

        }

        private List<Model.Habitacion> GetResults()
        {
            var tipoHabitacion = (Model.TipoHabitacion) cbTipoHabitacion.SelectedValue;
            var fechaActual = Tools.GetDate();
            return DAOFactory.HabitacionDAO.GetHabitacionesxPedido(_hotel.Id, tipoHabitacion.Id, fechaActual, _desde, _hasta);
        }
    }
}
