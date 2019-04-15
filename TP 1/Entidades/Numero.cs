using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto. Asigna un 0 al atributo de la clase Numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Crea una instancia de la clase Numero asignandole el parametro double
        /// </summary>
        /// <param>1 parametro tipo double</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Crea una instancia de la clase Numero asignandole el parametro double
        /// </summary>
        /// <param>1 parametro tipo string</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Asignará un valor al atributo número, previa validación.
        /// </summary>
        /// <returns>Retorna una variable tipo string con el valor seteado</returns>
        private string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Convertirá un número decimal a binario
        /// </summary>
        /// <param>1 parametro tipo numero</param>
        /// <returns>Retorna una variable tipo string con el resultado. Caso contrario retornara "Valor inválido"</returns>
        public string DecimalBinario(double numero)
        {
            int entero;
            string returnAux= "Valor inválido";
            
            entero = (int)numero;
            returnAux = Convert.ToString(entero, 2);   
                     
            return returnAux;
        }

        /// <summary>
        /// Convertirá un número decimal a binario
        /// </summary>
        /// <param>1 parametro tipo string</param>
        /// <returns>Retorna una variable tipo string con el resultado. Caso contrario retornara "Valor inválido"</returns>
        public string DecimalBinario(string numero)
        {
            double num;
            string returnAux="Valor inválido";
            bool control;

            control=double.TryParse(numero, out num);
            if(control==true)
            {
                returnAux=this.DecimalBinario(num);
            }

            return returnAux;
        }

        /// <summary>
        /// Convertirá un número binario a decimal
        /// </summary>
        /// <param>1 parametro tipo string</param>
        /// <returns>Retorna una variable tipo string con el resultado. Caso contrario retornara "Valor inválido"</returns>
        public string BinarioDecimal(string binario)
        {
            string returnAux = "Valor inválido";
            string acumulador="";
            char[] bin=binario.ToCharArray();
            int i;
            //int contNegativo = 0;
            double resultado = 0.0;
            Numero aux2 = new Numero();

            aux2.SetNumero = binario;
            //Si da 0 no es valido pero si es distinto de cero hay que evaluar si esta en binario
            if(aux2.numero!=0)
            {
                for (i = 0; i < binario.Length && binario != "Valor inválido"; i++)
                {
                    if (bin[i] != '1' && bin[i] != '0')
                    {
                        //Si es un negativo, lo ignora y se queda con el resto
                        if (bin[i] == '-')
                        {
                            continue;
                        }
                        //Si tiene un decimal corto y me quedo con lo acumulado hasta aqui
                        else if(bin[i] == ',')
                        {
                            break;
                        }
                        //Si tiene un punto lo desecho al numero
                        else
                        {
                            acumulador = "";
                            break;
                        }
                    }
                    acumulador += bin[i];
                }
            }
            //Convierto lo acumulado a binario
            if(acumulador!="")
            {
                resultado = Convert.ToInt64(acumulador, 2);
                returnAux=resultado.ToString();
            }

            return returnAux;
        }

        /// <summary>
        /// Comprobará que el valor recibido sea numérico
        /// </summary>
        /// <param>1 variable tipo string</param>
        /// <returns>Retorna el valor recibido en una variable tipo double o 0 en caso contrario.</returns>
        private double ValidarNumero(string strNumero)
        {
            double returnAux = 0;

            if(double.TryParse(strNumero, out double num))
            {
                returnAux = num;
            }

            return returnAux;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Realizará la operacion Resta
        /// </summary>
        /// <param>2 parametros de clase Numero</param>
        /// <returns>Retorna un double con el resultado</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double returnAux = n1.numero - n2.numero;

            return returnAux;
        }

        /// <summary>
        /// Realizará la operacion Multiplicación
        /// </summary>
        /// <param>2 parametros de clase Numero</param>
        /// <returns>Retorna un double con el resultado</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double returnAux = n1.numero * n2.numero;

            return returnAux;
        }

        /// <summary>
        /// Realizará la operacion División
        /// </summary>
        /// <param>2 parametros de clase Numero</param>
        /// <returns>Retorna un double con el resultado</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double returnAux;

            if (n2.numero != 0)
            {
                returnAux = n1.numero / n2.numero;
            }
            else
            {
                returnAux = double.MinValue;
            }

            return returnAux;
        }

        /// <summary>
        /// Realizará la operacion Suma
        /// </summary>
        /// <param>2 parametros de clase Numero</param>
        /// <returns>Retorna un double con el resultado</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double returnAux = n1.numero + n2.numero;

            return returnAux;
        }
        #endregion
    }
}
