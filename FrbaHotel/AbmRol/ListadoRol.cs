﻿using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class ListadoRol : Form
    {
        private Session _session;

        public ListadoRol(Session session)
        {
            InitializeComponent();
            _session = session;
        }
    }
}
