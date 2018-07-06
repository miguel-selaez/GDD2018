﻿using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    public class MenuCreator
    {
        private Session _session;

        public MenuCreator(Session sesion)
        {
            _session = sesion;
        }

        public ToolStripMenuItem GetItemMenu(Funcion funcion)
        {
            ToolStripMenuItem itemMenu = new ToolStripMenuItem();

            switch (funcion.Descripcion) { 
                case "ABM ROL":
                    itemMenu.Text = "Rol";

                    ToolStripMenuItem listadoRol = new ToolStripMenuItem("Listado", null, new EventHandler(listadoRol_Click));
                    itemMenu.DropDownItems.Add(listadoRol);

                    ToolStripMenuItem nuevoRol = new ToolStripMenuItem("Nuevo", null, new EventHandler(nuevoRol_Click));
                    itemMenu.DropDownItems.Add(nuevoRol);
                    break;
                case "ABM USUARIO":
                    itemMenu.Text = "Usuario";
                    ToolStripMenuItem listadoUsuario = new ToolStripMenuItem("Listado", null, new EventHandler(listadoUsuario_Click));
                    itemMenu.DropDownItems.Add(listadoUsuario);

                    ToolStripMenuItem nuevoUsuario = new ToolStripMenuItem("Nuevo", null, new EventHandler(nuevoUsuario_Click));
                    itemMenu.DropDownItems.Add(nuevoUsuario);
                    break;
                case "ABM CLIENTE":
                    itemMenu.Text = "Cliente";
                    ToolStripMenuItem listadoCliente = new ToolStripMenuItem("Listado", null, new EventHandler(listadoCliente_Click));
                    itemMenu.DropDownItems.Add(listadoCliente);

                    ToolStripMenuItem nuevoCliente = new ToolStripMenuItem("Nuevo", null, new EventHandler(nuevoCliente_Click));
                    itemMenu.DropDownItems.Add(nuevoCliente);
                    break;
                case "ABM HOTEL":
                    itemMenu.Text = "Hotel";
                    ToolStripMenuItem listadoHotel = new ToolStripMenuItem("Listado", null, new EventHandler(listadoHotel_Click));
                    itemMenu.DropDownItems.Add(listadoHotel);

                    ToolStripMenuItem nuevoHotel = new ToolStripMenuItem("Nuevo", null, new EventHandler(nuevoHotel_Click));
                    itemMenu.DropDownItems.Add(nuevoHotel);

                    ToolStripMenuItem bajaHotel = new ToolStripMenuItem("Baja", null, new EventHandler(bajaHotel_Click));
                    itemMenu.DropDownItems.Add(bajaHotel);
                    break;
                case "ABM HABITACION":
                    itemMenu.Text = "Habitación";
                    ToolStripMenuItem listadoHabitacion = new ToolStripMenuItem("Listado", null, new EventHandler(listadoHabitacion_Click));
                    itemMenu.DropDownItems.Add(listadoHabitacion);

                    ToolStripMenuItem nuevaHabitacion = new ToolStripMenuItem("Nuevo", null, new EventHandler(nuevaHabitacion_Click));
                    itemMenu.DropDownItems.Add(nuevaHabitacion);
                    break;
                case "ABM REGIMEN":
                    itemMenu.Text = "Régimen";
                    break;
                case "ABM RESERVA":
                    itemMenu.Text = "Reserva";
                    ToolStripMenuItem listadoReserva = new ToolStripMenuItem("Listado", null, new EventHandler(listadoReserva_Click));
                    itemMenu.DropDownItems.Add(listadoReserva);

                    ToolStripMenuItem nuevaReserva = new ToolStripMenuItem("Nuevo", null, new EventHandler(nuevaReserva_Click));
                    itemMenu.DropDownItems.Add(nuevaReserva);

                    ToolStripMenuItem cancelaReserva = new ToolStripMenuItem("Cancelar", null, new EventHandler(cancelaReserva_Click));
                    itemMenu.DropDownItems.Add(cancelaReserva);
                    break;
                case "REGISTRAR ESTADIA":
                    itemMenu.Text = "Estadia";
                    ToolStripMenuItem listadoEstadia = new ToolStripMenuItem("Listado", null, new EventHandler(listadoEstadia_Click));
                    itemMenu.DropDownItems.Add(listadoEstadia);

                    ToolStripMenuItem nuevaEstadia = new ToolStripMenuItem("Check-In", null, new EventHandler(nuevaEstadia_Click));
                    itemMenu.DropDownItems.Add(nuevaEstadia);
                    break;
                case "REGISTRAR CONSUMOS":
                    itemMenu.Text = "Consumos";
                    ToolStripMenuItem listadoConsumos = new ToolStripMenuItem("Listado", null, new EventHandler(listadoConsumos_Click));
                    itemMenu.DropDownItems.Add(listadoConsumos);

                    ToolStripMenuItem nuevoConsumo = new ToolStripMenuItem("Registrar", null, new EventHandler(nuevoConsumo_Click));
                    itemMenu.DropDownItems.Add(nuevoConsumo);

                    ToolStripMenuItem facturacion = new ToolStripMenuItem("Facturación", null, new EventHandler(facturacion_Click));
                    itemMenu.DropDownItems.Add(facturacion);
                    break;
                case "LISTADO ESTADISTICO":
                    itemMenu = new ToolStripMenuItem("Estadísticas", null, new EventHandler(estadisticas_Click));
                    break;
            }
           
            ((ToolStripDropDownMenu)(itemMenu.DropDown)).ShowImageMargin = false;
            ((ToolStripDropDownMenu)(itemMenu.DropDown)).ShowCheckMargin = true;

            return itemMenu;
        }

        private void cancelaReserva_Click(object sender, EventArgs e)
        {
            var cancelacion = new CancelarReserva.CancelarReserva(_session);
            _session.Main.Hide();
            cancelacion.Show();
        }

        private void bajaHotel_Click(object sender, EventArgs e)
        {
            var baja = new AbmHotel.BajaHotel(_session);
            _session.Main.Hide();
            baja.Show();
        }

        private void estadisticas_Click(object sender, EventArgs e)
        {
            var estadisticas = new ListadoEstadistico.Estadisticas(_session);
            _session.Main.Hide();
            estadisticas.Show();
        }

        private void facturacion_Click(object sender, EventArgs e)
        {
            var facturacion = new RegistrarConsumible.Facturacion(_session);
            _session.Main.Hide();
            facturacion.Show();
        }

        private void nuevoConsumo_Click(object sender, EventArgs e)
        {
            var nuevo = new RegistrarConsumible.Consumo(_session);
            _session.Main.Hide();
            nuevo.Show();
        }

        private void listadoConsumos_Click(object sender, EventArgs e)
        {
            var listado = new RegistrarConsumible.ListadoConsumos(_session);
            _session.Main.Hide();
            listado.Show();
        }

        private void nuevaEstadia_Click(object sender, EventArgs e)
        {
            var nuevo = new RegistrarEstadia.Estadia(_session);
            _session.Main.Hide();
            nuevo.Show();
        }

        private void listadoEstadia_Click(object sender, EventArgs e)
        {
            var listado = new RegistrarEstadia.ListadoEstadia(_session);
            _session.Main.Hide();
            listado.Show();
        }

        private void nuevaReserva_Click(object sender, EventArgs e)
        {
            var nuevo = new Reservas.Reserva(_session);
            _session.Main.Hide();
            nuevo.Show();
        }

        private void listadoReserva_Click(object sender, EventArgs e)
        {
            var listado = new Reservas.ListadoReserva(_session);
            _session.Main.Hide();
            listado.Show();
        }

        private void nuevaHabitacion_Click(object sender, EventArgs e)
        {
            var nuevo = new AbmHabitacion.Habitacion(_session);
            _session.Main.Hide();
            nuevo.Show();
        }

        private void listadoHabitacion_Click(object sender, EventArgs e)
        {
            var listado = new AbmHabitacion.ListadoHabitacion(_session);
            _session.Main.Hide();
            listado.Show();
        }

        private void nuevoHotel_Click(object sender, EventArgs e)
        {
            var nuevo = new AbmHotel.Hotel(_session);
            _session.Main.Hide();
            nuevo.Show();
        }

        private void listadoHotel_Click(object sender, EventArgs e)
        {
            var listado = new AbmHotel.ListadoHotel(_session);
            _session.Main.Hide();
            listado.Show();
        }

        private void nuevoCliente_Click(object sender, EventArgs e)
        {
            var nuevo = new AbmCliente.Cliente(_session);
            _session.Main.Hide();
            nuevo.Show();
        }

        private void listadoCliente_Click(object sender, EventArgs e)
        {
            var listado = new AbmCliente.ListadoCliente(_session);
            _session.Main.Hide();
            listado.Show();
        }

        private void nuevoUsuario_Click(object sender, EventArgs e)
        {
            var nuevo = new AbmUsuario.Usuario(_session);
            _session.Main.Hide();
            nuevo.Show();
        }

        private void listadoUsuario_Click(object sender, EventArgs e)
        {
            var listado = new AbmUsuario.ListadoUsuario(_session);
            _session.Main.Hide();
            listado.Show();
        }

        private void nuevoRol_Click(object sender, EventArgs e)
        {
            var nuevoRol = new AbmRol.Rol(_session);
            _session.Main.Hide();
            nuevoRol.Show();
        }

        private void listadoRol_Click(object sender, EventArgs e)
        {
            var listado = new AbmRol.ListadoRol(_session);
            _session.Main.Hide();
            listado.Show();
        }
    }
}