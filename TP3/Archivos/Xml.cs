using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Exepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {


        /// <summary>
        /// Serializa en un archivo "datos" en la carpeta donde se encuentra el .exe con el nombre pasado en "archivo" (por default es TP3\Consola\bin\Debug\archivo.xml)
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si pudo caso contrario lanza un exception</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                TextWriter escritor = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo + ".xml");
                XmlSerializer serializador = new XmlSerializer(typeof(T));

                serializador.Serialize(escritor, datos);

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
        /// Lee el "archivo" .xml y lo guarda en "datos" si no puede lanza un exception.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns> true si pudo leer </returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                TextReader lectora = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo + ".xml");

                XmlSerializer deserializador = new XmlSerializer(typeof(T));

                datos = (T)deserializador.Deserialize(lectora);

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
