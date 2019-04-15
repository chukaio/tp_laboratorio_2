using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Métodos
        /// <summary>
        /// Validará y realizará la operación pedida entre ambos números.
        /// </summary>
        /// <param>2 parametros de clase Numero y 1 parametro tipo string para el operador</param>
        /// <returns>Retorna un double con el resultado o double.MinValue si el dividendo fuera 0</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        { 
            double returnAux=0;
            
            switch (Calculadora.ValidarOperador(operador))
            {
                case "+":
                    {
                        returnAux = num1 + num2;
                        break;
                    }
                case "-":
                    {
                        returnAux = num1 - num2;
                        break;
                    }
                case "*":
                    {
                        returnAux = num1 * num2;
                        break;
                    }
                case "/":
                    {
                        returnAux = num1 / num2;                                                                                                                                                    
                        break;
                    }
            }

            return returnAux;   
        }

        /// <summary>
        ///  Validara que el operador recibido sea +, -, / o *.
        /// </summary>
        /// <param>1 variable tipo string para el operador</param>
        /// <returns>Retornara una variable tipo string con el operador elegido si es correcto, caso contrario retornara +.</returns>
        private static string ValidarOperador(string operador)
        {
            string returnAux;

            switch(operador)
            {
                case "+":
                    {
                        returnAux = operador;
                        break;
                    }
                case "-":
                    {
                        returnAux = operador;
                        break;
                    }
                case "*":
                    {
                        returnAux = operador;
                        break;
                    }
                case "/":
                    {
                        returnAux = operador;
                        break;
                    }
                default:
                    {
                        returnAux = "+";
                        break;
                    }
            }

            return returnAux;
        }
        #endregion
    }
}
