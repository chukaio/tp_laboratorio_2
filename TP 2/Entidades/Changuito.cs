using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        #region Atributos

        /// <summary>
        /// Definicion del enumerado ETipo
        /// </summary>
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        List<Producto> productos;
        private int _espacioDisponible;

        #endregion

        #region Constructores
        
        /// <summary>
        /// Constructor de la clase Producto
        /// </summary>
        /// <returns></returns>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase Producto
        /// </summary>
        /// <param name="espacioDisponible"></param>
        /// <returns></returns>
        public Changuito(int espacioDisponible) : this()
        {
            this._espacioDisponible = espacioDisponible;
        }

        #endregion

        #region Metodos
        
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
        }

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if (v is Snacks)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if (v is Dulce)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Leche:
                        if (v is Leche)
                            sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }

        #endregion

        #region Operadores
        
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            foreach (Producto v in c.productos)
            {
                if (v == p)
                    return c;
            }
            if (c.productos.Count < c._espacioDisponible)
                c.productos.Add(p);
            return c;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c.productos)
            {
                if (v == p)
                {
                    c.productos.Remove(p);
                    break;
                }
            }

            return c;
        }
        
        #endregion
    }
}

