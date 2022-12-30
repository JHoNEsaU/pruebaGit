using System;
using System.Collections.Generic;
using System.Text;

namespace LibTADS
{
    /// <summary>
    /// Definición de los servicios de las listas.
    /// Las listas indexan en posición 1
    /// </summary>
    public interface ILista
    {
        /// <summary>
        /// Determina si una lista está vacía
        /// </summary>
        /// <returns> valor que indica si una lista está vacía o no </returns>
        bool EstaVacia();
        /// <summary>
        /// Determina la cantidad de elementos de una lista
        /// </summary>
        /// <returns> número de elementos de la lista </returns>
        int Longitud();
        /// <summary>
        /// Permite agregar un elemento al final de la lista
        /// </summary>
        /// <param name="obj">objeto que se desea agregar </param>
        void Agregar(object obj);
        /// <summary>
        /// Permite insertar un elemento en una posición determinada
        /// </summary>
        /// <param name="obj"> elemento a insertar </param>
        /// <param name="pos"> posición en la que se insertará el elemento </param>
        void Insertar(object obj, int pos);
        /// <summary>
        /// Selecciona el elemento que se encuentra en una determinada posición
        /// </summary>
        /// <param name="pos"> Posición del elemento a seleccionar </param>
        /// <returns> Elemento que se encuentra en la posición determinada.Si el parámetro pos no es correcto, retorna NULL</returns>
        object Iesimo(int pos);
        /// <summary>
        /// Determina la ubicación (índice) de un elemento dentro de la lista
        /// /// </summary>
        /// <param name="obj"> Elemento que se busca </param>
        /// <returns> Ubicación del elemento. Si no existe retorna valor de 0 </returns>
        int Ubicacion(object obj);
        /// <summary>
        /// Elimina un elemento por su posición
        /// </summary>
        /// <param name="pos"> Posición del elemento a eliminar </param>
        void Eliminar(int pos);
        /// <summary>
        /// Elimina un elemento de la lista
        /// </summary>
        /// <param name="obj"> Elemento a eliminar </param>
        void Eliminar(object obj);
        /// <summary>
        /// Muestra los elementos de una lista
        /// </summary>
        void Mostrar();
    }
}

