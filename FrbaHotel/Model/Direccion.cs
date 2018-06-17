﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Model
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int NumeroCalle { get; set; }
        public int Piso { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public Pais Pais { get; set; }
    }
}
