using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;

        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        /// <summary>
        /// Guarda "datos" en el archivo
        /// </summary>
        /// <param name="datos"> Lo que se va a guardar en el archivo </param>
        /// <returns> true si no hubo errores </returns>
        public bool guardar(string datos)
        {
            bool retorno = true;
            try
            {
                StreamWriter scritor = new StreamWriter(this._archivo, true);

                scritor.WriteLine(datos);

                scritor.Close();
            }
            catch (Exception)
            {

                retorno = false;
            }



            return retorno;
        }


        /// <summary>
        /// Lee todos los datos del archivo y los retorna en una lista
        /// </summary>
        /// <param name="datos"> Una lista de string sin inicializar </param>
        /// <returns> true si no hubo errores </returns>
        public bool leer(out List<string> datos)
        {
            bool retorno = true;
            datos = new List<string>();

            try
            {
                StreamReader lectora = new StreamReader(this._archivo);

                while (!lectora.EndOfStream)
                {

                    datos.Add(lectora.ReadLine());
                }

                lectora.Close();

            }
            catch (Exception)
            {

                retorno = false;
            }

            return retorno;
        }

    }
}
