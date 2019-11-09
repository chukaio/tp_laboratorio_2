using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;


        #endregion

        #region Propiedades


        /// <summary>
        /// Propiedad de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de Jornada
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return jornada;
            }
            set
            {
                jornada = value;
            }
        }

        /// <summary>
        /// Indexador de jornada
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if(i>=0 && i<this.jornada.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return null;
                }                
            }
            set
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    this.jornada[i] = value;
                }
            }
        }


        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }


        #endregion

        #region Sobrecargas


        /// <summary>
        /// Hara publico los datos de la Universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }


        #endregion

        #region Operadores


        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool returnAux = false;

            foreach (Alumno item in g.alumnos)
            {
                if(item.Equals(a))
                {
                    returnAux = true;
                    break;
                }
            }           

            return returnAux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool returnAux = false;

            foreach (Profesor item in g.profesores)
            {
                if (item.Equals(i))
                {
                    returnAux = true;
                    break;
                }
            }

            return returnAux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if(item==clase)
                {
                    return item;                    
                }

            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    return item;
                }

            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornadaAux = new Jornada(clase, g == clase);

            foreach (Alumno a in g.Alumnos)
            {
                if(a==clase)
                {
                    jornadaAux.Alumnos.Add(a);
                }
            }

            g.Jornadas.Add(jornadaAux);

            return g;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u!=a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u!=i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            bool returnAux = false;
            Xml<Universidad> x = new Xml<Universidad>();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string path = projectDirectory + "Universidad.xml";

            if(x.Guardar(path,uni))
            {
                returnAux = true;
            }

            return returnAux;
        }

        /// <summary>
        /// Retornará un Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> x = new Xml<Universidad>();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string path = projectDirectory + "Universidad.xml";

            x.Leer(path, out Universidad datos);

            return datos;
        }

        /// <summary>
        /// Retornará los datos de la Universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada item in uni.Jornadas)
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();
        }
        #endregion

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
