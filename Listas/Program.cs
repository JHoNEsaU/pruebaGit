using System;
using LibTADS;

namespace Listas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CLista a = new CLista();
            a.Agregar("asd");
            a.Mostrar();

        }
    }
}
