using Excepciones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        #region Metodos

        /// <summary>
        /// Guardar un dato T generico en un archivo en formato XML.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool returnAux = false;

            XmlSerializer guardar = new XmlSerializer(typeof(T));
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    guardar.Serialize(writer, datos);
                    returnAux = true;
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return returnAux;
        }

        /// <summary>
        /// Leer un dato T generico de un archivo en formato XML.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool returnAux = false;
            XmlSerializer Leer = new XmlSerializer(typeof(T));

            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    datos = (T)Leer.Deserialize(reader);
                    returnAux = true;
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return returnAux;
        }

        #endregion
    }
}
