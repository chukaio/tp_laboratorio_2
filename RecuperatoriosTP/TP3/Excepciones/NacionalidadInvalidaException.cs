using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region Constructores

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public NacionalidadInvalidaException():base()
        {

        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        public NacionalidadInvalidaException(string message):base(message)
        {

        }

        #endregion
    }
}
