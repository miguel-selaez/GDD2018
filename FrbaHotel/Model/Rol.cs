﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Rol
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Baja { get; set; }

        public List<Funcion> Funciones;
    }
}
