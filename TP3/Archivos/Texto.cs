using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exepciones;
using System.IO;


namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        /// <summary>
        /// Guarda los "datos" en el "archivo" que se creara en el directorio del .exe en formato .txt (por default es TP3\Consola\bin\Debug\archivo.txt).
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns> true si pudo caso contrario lanza un "ArchivosException" </returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                StreamWriter escritor = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo + ".txt");

                escritor.Write(datos);

                escritor.Close();

                retorno = true;

            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Lee el "archivo" .txt y lo guarda en "datos" si no puede lanza un exception.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns> true si pudo leer </returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            try
            {
                StreamReader lectora = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo + ".txt");

                datos = lectora.ReadToEnd();

                retorno = true;

            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }

            return retorno;
        }

    }
}
