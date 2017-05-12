using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_Inventario
{
    class Inventario
    {
        private Producto inicio, ultimo;

        public Inventario()
        {
            inicio = null;
            ultimo = null;
        }

        //______________________________________________________________________________________________________________________________________________________//
        /// <summary>
        /// Metodo privado para agregar con recursividad.
        /// </summary>
        /// <param name="ultimo"></param>
        /// <param name="nuevo"></param>
        private void agregarProductoRecursividad(Producto ultimo, Producto nuevo)
        {
            if (ultimo.siguiente == null)
            {
                ultimo.siguiente = nuevo;
            }
            else
            {
                agregarProductoRecursividad(ultimo.siguiente, nuevo);
            }
        }

        /// <summary>
        /// Metodo 2 para agregar productos, de manera recursiva,
        /// </summary>
        /// <param name="productoNew"></param>
        public void agregarProductoMetodoDos(Producto productoNew)
        {
            if (inicio == null)
            {
                inicio = productoNew;
            }
            else
            {
                agregarProductoRecursividad(inicio, productoNew);//Llama el metodo recursivo y espera a que suceda la magia.
            }
        }
        //______________________________________________________________________________________________________________________________________________________//

        /// <summary>
        /// Verifica que el código no se repita y el limite del vector.
        /// </summary>
        /// <param name="producto"></param>
        public void agregarProducto(Producto productoNew)
        {
            bool sePuedeAgregar = true;

            if (inicio == null)//En caso de no tener ningun producto, agrega al primer producto en inicio.
            {
                inicio = productoNew;
                ultimo = productoNew;
            }
            else//busca el último nodo con un siguiente en null para poder agregar y busca que el código no este repetido.
            {
                Producto temp = inicio;
                while (temp.siguiente != null && sePuedeAgregar == true)
                {
                    if (temp.codigo == productoNew.codigo)//condición para saber si esta repetido o no.
                    {
                        sePuedeAgregar = false;
                    }
                    temp = temp.siguiente;
                }
                if (sePuedeAgregar == true && temp.codigo != productoNew.codigo)
                {
                    temp.siguiente = productoNew;
                    productoNew.anterior = temp;
                    ultimo = productoNew;
                }
            }
        }

        /// <summary>
        /// Elimina el producto con el código ingresado y recorre a los demas productos, después borra el último.
        /// </summary>
        /// <param name="codigo"></param>
        public void eliminarProducto(int codigo)
        {
            Producto temp = inicio;
            if (temp != null)//Verifica que exista al menos un producto.
            {
                if (temp.codigo == codigo)//Elimina en caso de ser el primero.
                {
                    eliminarInicio();
                }
                else//Busca eliminar a partir del segundo nodo.
                {
                    while (temp.siguiente != null && temp.siguiente.codigo != codigo)//verifica que exista temp.siguiente y que su código sea diferente.
                    {
                        temp = temp.siguiente;
                    }
                    if (temp.siguiente != null)//En caso de no encontrar dicho valor devolvera un null, es por eso que vuelve a verificar si regreso un valor.
                    {
                        if (temp.siguiente.siguiente == null)//ultimo
                        {
                            eliminarUltimo();
                        }
                        else
                        {
                            Producto temp2 = temp.siguiente.siguiente;
                            temp2.anterior = temp;
                            temp.siguiente = temp2;
                        }
                    }
                }
            }
        }

        public void eliminarInicio()
        {
            if (inicio.siguiente == null || inicio == null)
            {
                inicio = null;
            }
            else
            {
                inicio = inicio.siguiente;
                inicio.anterior = null; 
            }
        }
        public void eliminarUltimo()
        {
            if (ultimo.anterior == null || ultimo == null)
            {
                ultimo = null;
            }
            else
            {
                ultimo = ultimo.anterior;
                ultimo.siguiente = null;
            }
        }

        /// <summary>
        /// Busca un producto mediante su código, en caso de no encontrar el producto regresa null.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Producto buscarProducto(int codigo)
        {
            Producto temp = inicio;

            while (temp != null && temp.codigo != codigo)//Buscara si temp existe y si su código es igual al que se busca.
            {
                temp = temp.siguiente;
            }//Al terminar el ciclo si encontro el valor deseado, temp es el producto a regresar,
            //en caso de no serlo, temp valdra null, entonces regresaremos null.
            return temp;
        }

        /// <summary>
        /// Inserta un producto en una posición asignada por el usuario entre 1 y 15.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="posicion"></param>
        public void insertarProducto(Producto productoNew, int posicion)//posicion de 1 a 15.
        {
            Producto temp = inicio;
            int contador = 2;
            bool sePuedeAgregar = true;
            
            //Este ciclo hace una verificación para saber si el código esta repetido o no.
            while (temp != null && sePuedeAgregar == true)
            {
                if(temp.codigo == productoNew.codigo)
                {
                    sePuedeAgregar = false;
                }
                temp = temp.siguiente;
            }

            //Si el cógio se repite la variable 'sePuedeAgregar' sera igual a false.
            if(sePuedeAgregar == true)//Se Puede agregar.
            {
                temp = inicio;

                if (posicion == 1)
                {
                    productoNew.siguiente = temp;
                    temp.anterior = productoNew;
                    inicio = productoNew;
                }
                else
                {
                    //Nota: Contador inicia en 2.
                    while (temp.siguiente != null && contador != posicion)
                    {
                        contador++;
                        temp = temp.siguiente;
                    }
                    productoNew.siguiente = temp.siguiente;
                    temp.siguiente = productoNew;
                    productoNew.anterior = temp;
                    temp = temp.siguiente;
                    temp.anterior = productoNew;

                    //Identifica si el nuevo producto es el ultimo.
                    if (temp.siguiente == null)
                    {
                        productoNew.anterior = ultimo;
                        ultimo.siguiente = productoNew;
                        ultimo = productoNew;
                    }
                }
            }
        }
        
        /// <summary>
        /// Muestra todos los productos en el vector.
        /// </summary>
        /// <returns></returns>
        public string reporteDeProductos()
        {
            string cadena = "";
            Producto temp = inicio;

            while (temp != null)
            {
                cadena += temp.ToString();
                temp = temp.siguiente;
            }

            return cadena;
        }
        //______________________________________________________________________________________________________________________________________________________//
        /// <summary>
        /// Metodo recursivo para regresar todos los productos de forma invertida.
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        private string reporteDeProductosRecursividad(Producto principal)
        {
            string cadena1 = "";
            if (principal.siguiente != null)
            {
                cadena1 = reporteDeProductosRecursividad(principal.siguiente);
            }
            cadena1 += principal.ToString();
            return cadena1;
        }

        public string reporteDeProductosMetodoDos()
        {
            if (inicio != null)
            {
                return reporteDeProductosRecursividad(inicio);
            }
            return "";
        }
        //______________________________________________________________________________________________________________________________________________________//

        public string mostrarAnterior(int codigo)
        {
            Producto temp = inicio;
            while (temp != null && temp.codigo != codigo)
            {
                temp = temp.siguiente;
            }
            return temp.anterior.ToString();
        }
    }
}
