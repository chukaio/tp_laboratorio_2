using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {

        #region Atributos

        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion


        #region Operadores

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool returnAux = false;

            if(a.claseQueToma==clase && a.estadoCuenta!=EEstadoCuenta.Deudor)
            {
                returnAux = true;
            }

            return returnAux;
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase si no es igual.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            bool returnAux = false;

            if(a.claseQueToma!=clase)
            {
                returnAux = true;
            }

            return returnAux;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }


        #endregion


        #region Metodos

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format("CLASE: {0}", this.claseQueToma));
            sb.AppendLine(string.Format("ESTADO CUENTA: {0}", this.estadoCuenta));

            return sb.ToString();
        }

        /// <summary>
        /// Retornara la clase que toma
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE {0}", this.claseQueToma);
        }


        #endregion

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }


    }
}
