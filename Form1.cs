using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_Inventario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Inventario inventario1 = new Inventario();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto1 = new Producto(Convert.ToInt32(txtCodigo.Text), txtNombre.Text, 
                Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtPrecio.Text));

            inventario1.agregarProducto(producto1);
            txtReporte.Text = inventario1.reporteDeProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            inventario1.eliminarProducto(Convert.ToInt32(txtCodigo.Text));
            txtReporte.Text = inventario1.reporteDeProductos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (inventario1.buscarProducto(Convert.ToInt32(txtCodigo.Text)) != null)
            {
                txtReporte.Text = (inventario1.buscarProducto(Convert.ToInt32(txtCodigo.Text))).ToString();
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Producto producto1 = new Producto(Convert.ToInt32(txtCodigo.Text), txtNombre.Text,
                Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtPrecio.Text));

            inventario1.insertarProducto(producto1, Convert.ToInt32(txtPosicion.Text));
            txtReporte.Text = inventario1.reporteDeProductos();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            //txtReporte.Text = inventario1.reporteDeProductos();
            txtReporte.Text = inventario1.reporteDeProductosMetodoDos();
        }

        private void btnEliminarInicio_Click(object sender, EventArgs e)
        {
            inventario1.eliminarInicio();
            txtReporte.Text = inventario1.reporteDeProductosMetodoDos();
        }

        private void btnEliminarUltimo_Click(object sender, EventArgs e)
        {
            inventario1.eliminarUltimo();
            txtReporte.Text = inventario1.reporteDeProductosMetodoDos();
        }

        private void btnMostrarAnterior_Click(object sender, EventArgs e)
        {
            txtReporte.Text = inventario1.mostrarAnterior(Convert.ToInt32(txtAnterior.Text));
        }
    }
}
