using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;



namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor por defecto de la clase FormCalculadora
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Realizará la operacion pedida entre ambos numeros
        /// </summary>
        /// <param>2 parametros de tipo string y 1 parametro tipo string para el operador</param>
        /// <returns>Retorna un double con el resultado.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double returnAux;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            returnAux = Calculadora.Operar(num1, num2, operador);

            return returnAux;
        }

        /// <summary>
        /// Limpiara la calculadora
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            cmbOperador.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
        }
        #endregion

        #region Eventos
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            resultado = Calculadora.Operar(new Numero(this.txtNumero1.Text), new Numero(this.txtNumero2.Text), this.cmbOperador.Text);
            this.lblResultado.Text = resultado.ToString();
        }

        /// <summary>
        /// Evento click del boton Limpiar
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Evento click del boton Cerrar
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Evento click del boton ConvertirABinario
        /// </summary>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string returnAux="";
            Numero num1 = new Numero();

            //Si se dan estas condiciones defino al origen del input como el label 1
            if (lblResultado.Text == "" || lblResultado.Text == "Valor inválido")
            {
                returnAux = num1.DecimalBinario(txtNumero1.Text);
            }
            //Si se dan estas condiciones defino al origen del input como el label resultado
            else if (txtNumero1.Text != "")
            {
                returnAux = num1.DecimalBinario(lblResultado.Text);
            }
            lblResultado.Text = returnAux;
        }

        /// <summary>
        /// Evento click del boton ConertirADecimal
        /// </summary>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string returnAux="";
            Numero num1 = new Numero();

            //Si se dan estas condiciones defino al origen del input como el label 1
            if (lblResultado.Text == "" || lblResultado.Text == "Valor inválido")
            {
                returnAux = num1.BinarioDecimal(txtNumero1.Text);
            }
            //Si se dan estas condiciones defino al origen del input como el label resultado
            else if (txtNumero1.Text != "")
            {
                returnAux = num1.BinarioDecimal(lblResultado.Text);
            }
            lblResultado.Text = returnAux;
        }
        #endregion
    }
}
