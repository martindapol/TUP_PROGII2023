using PilasColas.implementaciones;
using PilasColas.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilasColas
{
    public partial class Form1 : Form
    {
        private IColeccion lista;
        public Form1(IColeccion col)
        {
            InitializeComponent();
            lista = col;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNuevo.Text))
            {
                string valor = txtNuevo.Text;
                lista.Agregar(valor);
                lstValores.Items.Add(valor);
            }
                
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            object elem = lista.Primero();
            if (elem != null)
                MessageBox.Show("Primero: [" + lista.Primero().ToString() + "]");
            else
                MessageBox.Show("No hay elementos!");
        }

        private void btnVacia_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lista.EstaVacia() ? "Lista Vacía!" : "Lista con elementos!");
        }

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            object elem = lista.Extraer();
            if (elem != null)
            {
                lstValores.Items.Remove(elem);
                MessageBox.Show("Elemento extraido: " + elem);
            }
            else
            {
                MessageBox.Show("No hay elementos!");
            }
        }
    }
}
