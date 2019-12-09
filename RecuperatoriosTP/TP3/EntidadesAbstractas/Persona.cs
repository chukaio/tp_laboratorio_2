using Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;


        #endregion


        #region Propiedades

        /// <summary>
        /// Propiedad de Apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de Dni
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad de Nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de Dni (string)
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }


        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Retornará los datos de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("NOMBRE COMPLETO: {0}, {1}", this.apellido, this.nombre));
            sb.AppendLine(string.Format("NACIONALIDAD: {0}", this.nacionalidad));

            return sb.ToString();
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Valida que DNI sea correcto, teniendo en cuenta su nacionalidad.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int returnAux = 0;


            if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException("El dni esta fuera del rango permitido");
            }
            else
            {
                if (nacionalidad == ENacionalidad.Argentino && (dato >= 1 && dato <= 89999999))
                {
                    returnAux = dato;
                }
                else if (nacionalidad == ENacionalidad.Extranjero && (dato >= 90000000 && dato <= 99999999))
                {
                    returnAux = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }

            return returnAux;
        }

        /// <summary>
        /// Valida que DNI sea correcto, teniendo en cuenta su nacionalidad.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int returnAux;

            foreach (char letter in dato)
            {
                if (!char.IsNumber(letter))
                {
                    throw new DniInvalidoException("El dni esta fuera del rango permitido");
                }
            }
            returnAux = ValidarDni(nacionalidad, int.Parse(dato));

            return returnAux;
        }

        /// <summary>
        /// Valida si el string ingresado es una cadena con caracteres válidos 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string returnAux = "";
            int isValid = 1;

            foreach (char letter in dato)
            {
                if (!char.IsLetter(letter))
                {
                    isValid = 0;
                    break;
                }
            }
            if (isValid == 1)
            {
                returnAux = dato;
            }

            return returnAux;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
