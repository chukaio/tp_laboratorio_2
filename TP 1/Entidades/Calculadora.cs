using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos
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
