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
    public partial class Reserva : Form
    {
        private Model.Session _session;

        public Reserva(Model.Session _session)
        {
            this._session = _session;
            InitializeComponent();
            InitValues();
        }

        private void InitValues()
        {
            dtDesde.Value = Tools.GetDate();
            dtHasta.Value = Tools.GetDate();

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
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var hotel = (Model.Hotel) cbHoteles.SelectedValue;
            var buscador = new BuscarHabitacion(this, hotel, dtDesde.Value, dtHasta.Value);
            buscador.Show();
        }
    }
}