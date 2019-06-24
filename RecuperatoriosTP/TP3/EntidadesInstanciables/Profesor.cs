using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos

        private Queue<EClases> claseDelDia;
        private static Random random;

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            claseDelDia = new Queue<EClases>();
            this.RandomClases();
            Thread.Sleep(1000);
            this.RandomClases();
        }


        #endregion

        #region Operadores

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool returnAux = false;

            if(i.claseDelDia.Peek()==clase)
            {
                returnAux = true;
            }

            return returnAux;
        }

        /// <summary>
        /// Un Profesor será distinto a un EClase si no es igual.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }


        #endregion

        #region Sobrecargas

        /// <summary>
        /// Hará públicos los datos del Profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Asigna una clase aleatoria
        /// </summary>
        private void RandomClases()
        {
            this.claseDelDia.Enqueue((EClases)random.Next(0, 3));
        }

        /// <summary>
        /// Retornará los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("CLASES DEL DIA");
            foreach (EClases clase in this.claseDelDia)
            {
                sb.Append(string.Format("{0} ", clase));
            }
            sb.Append("\n");

            return sb.ToString();
        }

        /// <summary>
        /// Retornará el nombre de las clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASES DEL DÍA: ");
            foreach (EClases clase in this.claseDelDia)
            {
                sb.Append(string.Format("{0} ", clase));
            }
            sb.Append("\n");

            return sb.ToString();
        }

        #endregion

    }
}
