﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        #region Atributos
        /// <summary>
        /// Definicion del enumerado EMarca
        /// </summary>
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase Producto
        /// </summary>
        /// <param name="patente"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = patente;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias
        {
            get;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Convierte el objecto producto en un string.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: "+p.codigoDeBarras+"\r\n");
            sb.AppendLine("MARCA          : "+p.marca.ToString()+"\r\n");
            sb.AppendLine("COLOR EMPAQUE  : "+p.colorPrimarioEmpaque.ToString()+"\r\n");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1==v2);
        }

        #endregion
    }
}
