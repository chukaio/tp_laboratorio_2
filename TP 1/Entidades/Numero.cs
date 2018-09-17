using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double _numero;
        #endregion

        #region Constructor
        public Numero()
        {
            this._numero = 0.0;
        }
        public Numero(double numero)
        {
            this._numero = numero;
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        #region Propiedad
        public string SetNumero
        {
            set
            {
                if (Numero.ValidarNumero(value) != 0)
                {
                    this._numero = double.Parse(value);
                }
                else
                {
                    this._numero = 0;
                }
            }
        }
        #endregion

        #region Metodos
        public static string DecimalBinario(double numero)
        {
            int entero;
            double dec;
            double decProd;
            string returnAux="";
            
            //Parte Entera
            entero = (int)numero;
            dec = numero - entero;
            decProd = dec;
            returnAux = Convert.ToString(entero, 2);
            //Parte Decimal
            if (dec != 0)
            {
                returnAux += ',';
                do
                {
                    decProd = decProd * 2;
                    if (decProd >= 1)
                    {
                        decProd -= 1;
                        returnAux += 1;
                        if (decProd == 0)
                        {
                            continue;
                        }
                    }
                    else if (decProd < 1)
                    {
                        returnAux += 0;
                    }
                }
                while (decProd != 0);
            }
                     
            return returnAux;
        }
        public static string DecimalBinario(string numero)
        {
            double num;
            string returnAux="Valor invalido";
            bool control;

            control=double.TryParse(numero, out num);
            if(control==true)
            {
                returnAux=DecimalBinario(num);
            }

            return returnAux;
        }
        public static string BinarioDecimal(string binario)
        {
            string returnAux = "Valor invalido";
            char[] bin=binario.ToCharArray();
            int i;
            int j;
            int contEntero = 0;
            int contDecimal = -1;
            double resultado = 0.0;
            double resultado1;
            double resultado2;
            double potencia;

            //Determina si el string binario es un decimal o no
            for (i = 0; i < binario.Length && binario != "Valor invalido"; i++)
            {
                if (bin[i] != '1' && bin[i] != '0' && bin[i] != ',' )
                {
                    returnAux = "Valor invalido";
                    binario = "";
                    break;
                }
            }
            for (i=0; i<binario.Length && binario!="Valor invalido"; i++)
            {
                //Si es un string vacio no entra aca
                if(i==0)
                {
                    returnAux = "";
                }
                //Numero binario con decimales
                if(bin[i]==',')
                {
                    //returnAux += ',';
                    //Posicion relativa de decimales a partir de la coma
                    contDecimal = binario.Length - (contEntero + 1);
                    for(j=1; j<=contDecimal; j++)
                    {
                        if(bin[i+j]=='1')
                        {
                            potencia = Math.Pow(2, -j);
                            resultado += potencia;
                            
                        }
                    }
                    break;
                }
                //Numero binario sin decimales
                else
                {
                    contEntero++;
                    returnAux += bin[i];
                }
                

            }
            //Es un binario sin decimales no vacio
            if(contDecimal==-1 && binario.Length!=0 && binario != "Valor invalido")
            {
                resultado1 = Convert.ToInt64(returnAux, 2);
                returnAux=resultado1.ToString();
            }
            //es un binario con decimales no vacio
            else if(contDecimal!=-1 && binario.Length!=0 && binario != "Valor invalido")
            {
                resultado2 = Convert.ToInt64(returnAux, 2);
                resultado2 += resultado;
                returnAux = resultado2.ToString();
            }

            return returnAux;
        }
        private static double ValidarNumero(string strNumero)
        {
            double.TryParse(strNumero, out double returnAux);

            return returnAux;
        }
        #endregion

        #region Operadores
        public static double operator -(Numero n1, Numero n2)
        {
            double returnAux = n1._numero - n2._numero;

            return returnAux;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            double returnAux = n1._numero * n2._numero;

            return returnAux;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double returnAux = 0;

            if (n2._numero != 0)
            {
                returnAux = n1._numero / n2._numero;
            }

            return returnAux;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            double returnAux = n1._numero + n2._numero;

            return returnAux;
        }
        #endregion
    }
}
