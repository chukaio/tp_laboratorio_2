using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InsertarSQLExcepcion : Exception
    {
        public InsertarSQLExcepcion(string mensaje):base(mensaje)
        {
            
        }

        public InsertarSQLExcepcion(string mensaje, Exception inner):base(mensaje, inner)
        {

        }
    }
}
