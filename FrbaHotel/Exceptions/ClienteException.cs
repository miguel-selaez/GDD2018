﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Exceptions
{
    class ClienteException : Exception
    {
        public ClienteException(string message) :

        base("Error: " + message) { }
    }
}
