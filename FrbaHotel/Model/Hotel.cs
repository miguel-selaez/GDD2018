﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Hotel : BaseData
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public Direccion Direccion {get; set;}
        public decimal Estrellas { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool Baja { get; set; }

        public Hotel(DataRow row) {
            Row = row;

            Id = GetValue<int>("id_hotel");
            Nombre = GetValue<string>("nombre");
            Mail = GetValue<string>("mail");
            Telefono = GetValue<string>("telefono");
            Direccion = new Direccion(row);
            Estrellas = GetValue<decimal>("estrellas");
            FechaCreacion = GetDate("fecha_creacion");
            Baja = GetValue<bool>("baja");
        }
    }
}