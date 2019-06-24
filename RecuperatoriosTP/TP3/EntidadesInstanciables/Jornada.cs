using Archivos;
using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Text;
using static EntidadesInstanciables.Universidad;
using System.IO;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;



        #endregion

        #region Propiedades


        /// <summary>
        /// Propiedad de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        /// <summary>
        /// Propiedad de clase
        /// </summary>
        public EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }

        /// <summary>
        /// Propiedad de instructor
        /// </summary>
        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }



        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        public Jornada(EClases clase, Profesor instructor)
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion


        #region Operadores

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool returnAux = false;

            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    returnAux = true;
                    break;
                }

            }

            return returnAux;
        }

        /// <summary>
        /// Una Jornada será distinta a un Alumno si no es igual.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega Alumnos a la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {            
            if(j!=a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Mostrará todos los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this.alumnos)
            {
                sb.Append(string.Format("{0} ", item));
            }
            sb.Append("\n");
            sb.AppendLine(string.Format("CLASE: {0}", this.clase));
            sb.AppendLine(string.Format("INSTRUCTOR: {0}", this.instructor));

            return sb.ToString();
        }

        #endregion


        #region Metodos

        /// <summary>
        ///  Guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada j)
        {
            bool returnAux = false;
            Texto txt = new Texto();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string path = projectDirectory + "Jornada.txt";

            if (txt.Guardar(path, j.ToString()))
            {
                returnAux = true;
            }
            
            return returnAux;
        }

        /// <summary>
        /// Retornará los datos de la Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string returnAux = "";
            Texto txt = new Texto();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string path = projectDirectory + "Jornada.txt";

            txt.Leer(path, out returnAux);
                        
            return returnAux;
        }
        #endregion

    }
}
