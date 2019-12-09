using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Excepciones;

namespace Archivos
{

    public class Texto : IArchivo<string>
    {
        #region Metodos


        /// <summary>
        /// Guarda string en un archivo.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool returnAux = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.WriteLine(datos);
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
        /// Lee un string de un archivo.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool returnAux = false;

            try
            {
                using (StringReader sr = new StringReader(archivo))
                {
                    datos = sr.ReadToEnd();
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
