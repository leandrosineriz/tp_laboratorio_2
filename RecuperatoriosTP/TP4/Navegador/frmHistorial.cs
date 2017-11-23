using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            this.CargarHistorial();
        }

        /// <summary>
        /// Carga los datos del historial en el visor del form.
        /// </summary>
        private void CargarHistorial()
        {
            Archivos.Texto archivos = new Archivos.Texto(ARCHIVO_HISTORIAL);

            List<string> datos;

            if (archivos.leer(out datos))
            {
                foreach (string i in datos)
                {
                    this.lstHistorial.Items.Add(i);
                }
            }


        }

    }
}
