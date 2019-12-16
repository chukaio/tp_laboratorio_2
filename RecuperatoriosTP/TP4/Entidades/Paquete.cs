using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;


        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        #region Atributos


        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;


        #endregion

        #region Propiedades


        /// <summary>
        /// Propiedad de direccionEntrega.
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad de estado.
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad de trackingID.
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Constructores



        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }



        #endregion

        #region Operadores


        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1">Paquete</param>
        /// <param name="p2">Paquete</param>
        /// <returns>retorna true si son iguales, false si no</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }
            return retorno;

        }


        /// <summary>
        /// Dos paquetes serán distintos si no son iguales.
        /// </summary>
        /// <param name="p1">Paquete</param>
        /// <param name="p2">Paquete</param>
        /// <returns>retorna true si son distintos, false si no</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }



        #endregion

        #region Sobrecargas

        /// <summary>
        /// Retornará la información del paquete.
        /// </summary>
        /// <returns>Retornba un string con dichos datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos((IMostrar<Paquete>)this);
        }


        #endregion

        #region Metodos

        /// <summary>
        /// Compilará los datos del paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Retorna una cadena con dichos datos</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }


        /// <summary>
        /// Hará que el paquete cambie de estado.
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformaEstado(this.Estado, EventArgs.Empty);
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (InsertarSQLExcepcion e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

    }
}
