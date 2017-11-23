using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public delegate void FinDescargaCallback(string html);
    public delegate void ProgresoDescargaCallback(int progreso);

    public class Descargador
    {
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
        }

        /// <summary>
        /// Inicia la descarga del Html
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;


                cliente.DownloadStringAsync(direccion);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public event FinDescargaCallback EventFinDescarga;

        public event ProgresoDescargaCallback EventProgresoDescarga;

        /// <summary>
        /// Lanza un evento con el progreso de la descarga como parametro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            EventProgresoDescarga(e.ProgressPercentage);

        }

        /// <summary>
        /// Lanza un evento con el resultado de la descarga como parametro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            EventFinDescarga(e.Result);
        }
    }
}
