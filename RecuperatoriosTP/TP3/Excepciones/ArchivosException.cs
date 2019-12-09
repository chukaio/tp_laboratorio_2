using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region Constructor

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base("Path incorrecto", innerException)
        {

        }

        #endregion
    }
}
