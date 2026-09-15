using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Laboratorio3_parte3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true; 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            fromVentanaTexto ventanaTexto = Application.OpenForms.OfType<fromVentanaTexto>().FirstOrDefault();

            if (ventanaTexto != null)
            {
                ventanaTexto.Activate();
            }
            else
            {
                ventanaTexto = new fromVentanaTexto();
                ventanaTexto.MdiParent = this;
                ventanaTexto.Show();
            }
        }
    }
}