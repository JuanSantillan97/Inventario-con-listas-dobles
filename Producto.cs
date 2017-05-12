using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_Inventario
{
    class Producto
    {
        //Nodo de la clase producto, siguiente pues sera el "padre".
        public Producto siguiente, anterior;

        private int _codigo;
        public int codigo
        {
            get { return _codigo; }
        }

        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
        }

        private int _cantidad;
        public int cantidad
        {
            get { return _cantidad; }
        }

        private int _precio;
        public int precio
        {
            get { return _precio; }
        }

        public Producto(int codigo, string nombre, int cantidad, int precio)
        {
            _codigo = codigo;
            _nombre = nombre;
            _cantidad = cantidad;
            _precio = precio;
        }

        /// <summary>
        /// Regresa la información de cada producto en un cadena concatenada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string cadena = "";
            cadena += "[ " + _nombre + " ]" + "\r\n" + "Código: " + _codigo + "\r\n" + 
                "Cantidad: " + _cantidad + "\r\n" + "Precio: $" + _precio + "\r\n" + "\r\n";
            return cadena;
        }

    }
}
