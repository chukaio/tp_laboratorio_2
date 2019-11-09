using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        #region Constructores

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public AlumnoRepetidoException():base("Alumno repetido")
        {

        }
        #endregion
    }
}
