using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaDeClases;

namespace Layout
{
    public partial class Layout : Form
    {
        private Numero numeroUno;
        private Numero numeroDos;


        public Layout()
        {
            InitializeComponent();

            this.cmbOperation.Items.Add("+");
            this.cmbOperation.Items.Add("-");
            this.cmbOperation.Items.Add("*");
            this.cmbOperation.Items.Add("/");
            this.cmbOperation.SelectedItem = "+";

        }

        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "0";

        }

        
        private void btnOperar_Click(object sender, EventArgs e)
        {
            numeroUno = new Numero(this.txtNumero1.Text);
            numeroDos = new Numero(this.txtNumero2.Text);

            lblResultado.Text=Calculadora.operar(numeroUno, numeroDos, this.cmbOperation.Text).ToString();

        }
    }
}
