using System;
using System.Collections.Generic;
using System.Text;
using LibTADS;
public class CLista : ILista
{
    // ============= Atributos ===============
    protected Object aElemento;
    protected CLista aSubLista;
    // ============= Metodos =================
    // ------------ Constructores ------------
    public CLista()
    {
        aElemento = null;
        aSubLista = null;
    }
    // --------------------------------------------
    public CLista(Object pElemento, CLista pSubLista)
    {
        aElemento = pElemento;
        aSubLista = pSubLista;
    }
    // ----------------- Propiedades -----------------
    public Object Elemento
    {
        get
        { return aElemento; }
        set
        { aElemento = value; }
    }
    // --------------------------------------------
    public CLista SubLista
    {
        get
        { return aSubLista; }
        set
        { aSubLista = value; }
    }
    // ------------ Otros mètodos --------------------
    public bool EstaVacia()
    {
        return ((aElemento == null) && (aSubLista == null));
    }
    // ---------- Operacion insertar--------------------
    protected void insertar(Object pElemento, int posicion)
    {
        if (posicion == 1)
        {
            aSubLista = new CLista(aElemento, aSubLista);
            aElemento = pElemento;
        }
        else
            aSubLista.insertar(pElemento, posicion - 1);

    }
    // --------------------------------------------
    public virtual void Insertar(Object pElemento, int posicion)
    { // validar la posicion de insercion
        if (1 <= posicion && posicion <= Longitud() + 1)
            insertar(pElemento, posicion);
        else
            Console.WriteLine("ERROR: Posición incorrecta");

    }
    // --------------------------------------------------
    public virtual void Agregar(Object pElemento)
    {
        insertar(pElemento, Longitud() + 1);
    }

    // ---------- Operacion Ubicacion--------------------
    /// <summary>
    /// Determina la ubicación (índice) de un elemento dentro de la lista
    /// </summary>
    /// /// <param name="obj"> Elemento que se busca </param>
    /// <returns> Ubicación del elemento. Si no existe retorna valor de 0 </returns>
    public virtual int Ubicacion(Object pElemento)
    {
        if (EstaVacia())
            return 0;
        else // comparar con el elemento actual
        if (aElemento.Equals(pElemento))
            return 1;
        else
        { // buscar en el resto de la lista
            int k = aSubLista.Ubicacion(pElemento);
            return ((k > 0) ? 1 + k : 0);
        }
    }
    public object Ubicacion(string Identificador)
    {
        if (EstaVacia())
        {
            return null;
        }
        else
        if (aElemento.ToString() == Identificador)
        {
            return aElemento;
        }
        else
        {
            return aSubLista.Ubicacion(Identificador);
        }
    }
    // ---------- Operacion insertar--------------------
    protected Object iesimo(int posicion)
    {
        if (posicion == 1)
            return aElemento;
        else
            return aSubLista.iesimo(posicion - 1);

    }
    // --------------------------------------------------
    public virtual Object Iesimo(int posicion)
    { //validar la posicion
        if (1 <= posicion && posicion <= Longitud())
            return iesimo(posicion);
        else
        { // la posicion no es correcta
            Console.WriteLine("ERROR: Posición incorrecta");
            return null;
        }
    }
    // ---------- Operacion Eliminar --------------------
    protected void eliminar(int posicion)
    {
        if (posicion == 1)
        { // quitar el elemento actual
            aElemento = aSubLista.Elemento;
            aSubLista = aSubLista.SubLista;
        }
        else // eliminar en la sublista
            aSubLista.eliminar(posicion - 1);

    }
    // -------------------------------------------------
    public virtual void Eliminar(int posicion)
    { // validar la posicion
        if (1 <= posicion && posicion <= Longitud())
            eliminar(posicion);
        else
            Console.WriteLine("ERROR: Posición incorrecta");

    }
    //--------------------------------------------------
    public void Eliminar(object pElemento)
    { // elimina un elemento de la lista
        int pos = Ubicacion(pElemento);
        if (pos != 0)
            eliminar(pos);
        else
            Console.WriteLine("ERROR: El elemento no existe");

    }
    // ---------- Operacion Longitud --------------------
    public int Longitud()
    {
        if (EstaVacia())
            return 0;
        else
            return 1 + aSubLista.Longitud();

    }
    //------------ Operacion mostrar ----------------------
    public void Mostrar()
    { // muestra el elemento y el resto de la lista
        if (!(EstaVacia()))
        {
            aElemento.ToString();
            aSubLista.Mostrar();
        }
    }
}
