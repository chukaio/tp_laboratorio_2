using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Atributos

        private string mensajeBase;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public DniInvalidoException() : base()
        {

        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        public DniInvalidoException(Exception e) : base("El dni esta fuera del rango permitido", e)
        {

        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        public DniInvalidoException(string message)
        {
            this.mensajeBase = message;
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }

        #endregion
    }
}
