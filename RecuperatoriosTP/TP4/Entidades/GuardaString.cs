using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Entidades
{
    public static class GuardaString
    {
        #region Metodos


        /// <summary>
        /// Guardará en un archivo de texto en el escritorio de la máquina
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool returnAux;

            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/" + archivo, true, Encoding.UTF8))
                {
                    sw.WriteLine(texto);
                    returnAux = true;
                }

            }
            catch (Exception)
            {
                returnAux = false;
            }

            return returnAux;
        }


        #endregion

    }
}
