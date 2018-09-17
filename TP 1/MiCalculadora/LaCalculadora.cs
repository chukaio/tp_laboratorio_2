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
    public partial class LaCalculadora : Form
    {
        #region Constructor
        public LaCalculadora()
        {
            InitializeComponent();
            
        }
        #endregion

        #region Metodos
        private double Operar(string numero1, string numero2, string operador)
        {
            double returnAux;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            returnAux = Calculadora.Operar(num1, num2, operador);

            return returnAux;
        }
        private void Limpiar()
        {
            textNumero1.Text = "";
            cmbOperador.Text = "";
            textNumero2.Text = "";
            lblResultado.Text = "Resultado";
        }
        #endregion

        #region Eventos
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            resultado=Operar(textNumero1.Text, textNumero2.Text, cmbOperador.Text);
            lblResultado.Text = resultado.ToString();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string returnAux="";
            if(lblResultado.Text!="Resultado")
            {
                returnAux = Numero.DecimalBinario(lblResultado.Text);
            }
            else if(lblResultado.Text=="Resultado" || lblResultado.Text== "Valor invalido")
            {
                returnAux = Numero.DecimalBinario(textNumero1.Text);
            }
            
            lblResultado.Text = returnAux;
        }
        private void btnConertirADecimal_Click(object sender, EventArgs e)
        {
            string returnAux="";
            if (lblResultado.Text != "Resultado")
            {
                returnAux = Numero.BinarioDecimal(lblResultado.Text);
            }
            else if (lblResultado.Text == "Resultado" || lblResultado.Text == "Valor invalido")
            {
                returnAux = Numero.BinarioDecimal(textNumero1.Text);
            }
            lblResultado.Text = returnAux;
        }
        #endregion
    }
}
