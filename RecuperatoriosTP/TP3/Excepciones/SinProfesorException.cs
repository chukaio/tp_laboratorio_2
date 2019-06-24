﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        #region Constructor

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public SinProfesorException():base("Sin profesor disponible")
        {

        }

        #endregion
    }
}
