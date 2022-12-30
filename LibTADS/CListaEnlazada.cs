using System;
using System.Collections.Generic;
using System.Text;
using LibTADS;
public class CListaEnlazada : ILista
{
    #region Atributos
    private CNodoLista aNodo;
    #endregion Atributos
    #region Constructores
    public CListaEnlazada()
    {
        aNodo = new CNodoLista();
    }
    public CListaEnlazada(CNodoLista pNodo)
    {
        aNodo = pNodo;
    }
    #endregion Constructores
    #region Propiedades
    public CNodoLista Nodo
    {
        set { aNodo = value; }
        get { return aNodo; }
    }
    #endregion Propiedades
    #region Metodos base
    public bool EstaVacia()
    {
        return (aNodo.Elemento == null && aNodo.Sgte == null);
    }
    public int Longitud()
    {
        CNodoLista Aux = aNodo;
        int Nro = 0;
        while (Aux != null)
        {
            Nro++;
            Aux = Aux.Sgte;
        }
        return Nro;
    }
    public void Agregar(object Elem)
    {
        //-- si la lista está vacía, insertar al inicio
        if (EstaVacia())
            aNodo.Elemento = Elem;
        else
        { //-- recorrer la lista hasta el último nodo
            CNodoLista Aux = aNodo;
            while (Aux.Sgte != null)
                Aux = Aux.Sgte;
            //-- insertar elemento al final
            Aux.Sgte = new CNodoLista(Elem);
        }
    }
    private void insertar(Object Elem, int Pos)
    {
        //-- insertar en lista vacia
        if (EstaVacia())
        {
            aNodo = new CNodoLista(Elem);
        }
        else
        {
            //-- insertar en la primera ubicacion
            if (Pos == 1)
                aNodo = new CNodoLista(Elem, aNodo);
            else
            {
                //-- ubicar el puntero en la posicion indicada
                CNodoLista Aux = aNodo;

                int k = 1;
                while (k < Pos - 1)

                {
                    Aux = Aux.Sgte;

                    k++;
                }

                //-- insertar el elemento

                Aux.Sgte = new CNodoLista(Elem, Aux.Sgte);
            }
        }
    }
    public void Insertar(Object Elem, int Pos)
    { // validar la posicion de insercion
        if (1 <= Pos && Pos <= Longitud() + 1)
            insertar(Elem, Pos);
        else
            Console.WriteLine("ERROR: Posición incorrecta");
    }
    private object iesimo(int Pos)
    {
        //-- Avanzar el puntero hasta la posicion
        CNodoLista Aux = aNodo;
        int k = 1;
        while (k < Pos)
        {
            Aux = Aux.Sgte;
            k++;
        }
        //-- devolver el elemento
        return Aux.Elemento;
    }
    public object Iesimo(int Pos)
    {
        //-- validar la posicion
        if (1 <= Pos && Pos <= Longitud() + 1)
            return iesimo(Pos);
        else
        {
            Console.WriteLine("ERROR: Posición incorrecta");
            return null;
        }
    }
    public void Mostrar()
    {
        //-- si la lista está vacía, insertar al inicio
        if (EstaVacia())
            Console.WriteLine("Lista vacía");
        else
        { //-- recorrer la lista hasta el último nodo
            CNodoLista Aux = aNodo;
            while (Aux != null)
            {
                Console.WriteLine(Aux.Elemento.ToString());

                Aux = Aux.Sgte;

            }
        }
    }
    public int Ubicacion(object obj)
    {
        if (EstaVacia())
            return -1;
        else
        { //-- buscar hasta encontrar el elemento
            int k = 1;
            CNodoLista Aux = aNodo;
            while (Aux != null && !Aux.Elemento.Equals(obj))
            {
                k++;

                Aux = Aux.Sgte;

            }
            //-- evaluar el resultado de la búsqueda
            if (Aux == null)
                return -1;
            else
                return k;
        }
    }
    private void eliminar(int pos)
    {
        //-- eliminar primer elemento
        if (pos == 1)
            aNodo = aNodo.Sgte;
        else
        {
            //-- ubicar el puntero auxiliar en la posicion anterior
            CNodoLista Aux = aNodo;
            for (int k = 1; k < pos - 1; k++)
                Aux = Aux.Sgte;
            //-- eliminar el elemento en pos
            Aux.Sgte = Aux.Sgte.Sgte;
        }
    }
    public void Eliminar(int pos)
    {
        if (1 <= pos && pos <= Longitud())
            eliminar(pos);
        else
            Console.WriteLine("Error al eliminar: Posición fuera de rango");
    }
    public void Eliminar(object obj)
    {
        //-- eliminar por ubicacion
        int pos = Ubicacion(obj);
        eliminar(pos);
    }
    #endregion Metodos base
}
