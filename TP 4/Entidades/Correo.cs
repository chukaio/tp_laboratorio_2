using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #endregion


        #region Propiedades
        /// <summary>
        /// Propiedad del atributo Paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion


        #region Constructores
        
        
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();

        }
        #endregion

        #region Operadores


        /// <summary>
        /// Operador +
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya esta en la lista");
                }

            }

            c.paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            hilo.Start();
            c.mockPaquetes.Add(hilo);

            return c;
        }
        #endregion

        #region Metodos


        /// <summary>
        /// Cerrará todos los hilos activos.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }
            }
        }

        /// <summary>
        /// Retornará los datos de todos los paquetes de su lista.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> list = ((Correo)elementos).paquetes;
            string retorno = "";

            foreach (Paquete p in list)
            {
                retorno += string.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }

            return retorno;
        }

        #endregion
    }
}
