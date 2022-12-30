using System;
using System.Collections.Generic;
using System.Text;

public class CNodoLista
{
    #region Atributos
    private Object aElemento;
    private CNodoLista aSgte;
    #endregion Propiedades
    #region Constructores
    public CNodoLista()
    {
        aElemento = null;
        aSgte = null;
    }
    public CNodoLista(Object pElemento)
    {
        aElemento = pElemento;
        aSgte = null;
    }
    public CNodoLista(Object pElemento, CNodoLista pNodo)
    {
        aElemento = pElemento;
        aSgte = pNodo;
    }
    #endregion Constructores
    #region Propiedades
    public object Elemento
    {
        set { aElemento = value; }
        get { return aElemento; }
    }
    public CNodoLista Sgte
    {
        set { aSgte = value; }
        get { return aSgte; }
    }
    #endregion Propiedades
}
