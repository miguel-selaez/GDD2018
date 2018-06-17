using System;

namespace FrbaHotel.Exceptions
{
    public class DBConnectionException : Exception
    {
        public DBConnectionException(string message) :
            
            base( "Error de Base Datos: " + message )
        { }

    }
}