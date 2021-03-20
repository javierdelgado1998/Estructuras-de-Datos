using System;

namespace TP2
{
    class Program
    {
        static void Main(string[] args)
        {
			ArbolBinario<int> arbolBinarioA = new ArbolBinario<int>(5);
			arbolBinarioA.agregar(new ArbolBinario<int>(10));
			arbolBinarioA.agregar(new ArbolBinario<int>(8));
			arbolBinarioA.agregar(new ArbolBinario<int>(20));
			arbolBinarioA.agregar(new ArbolBinario<int>(4));
			arbolBinarioA.agregar(new ArbolBinario<int>(3));
			arbolBinarioA.inorden();





			/*ArbolBinario<int> hijoIzquierdo=new ArbolBinario<int>(2);
			hijoIzquierdo.agregarHijoIzquierdo(new ArbolBinario<int>(3));
			hijoIzquierdo.agregarHijoDerecho(new ArbolBinario<int>(4));*/
			/*
			ArbolBinario<int> hijoHijoIzquierdo = new ArbolBinario<int>(3);
			hijoIzquierdo.agregarHijoIzquierdo(hijoHijoIzquierdo);
			hijoHijoIzquierdo.agregarHijoIzquierdo(new ArbolBinario<int>(10));
			hijoHijoIzquierdo.agregarHijoDerecho(new ArbolBinario<int>(14));
			*/
			/*ArbolBinario<int> hijoDerecho=new ArbolBinario<int>(5);
			hijoDerecho.agregarHijoIzquierdo(new ArbolBinario<int>(6));
			hijoDerecho.agregarHijoDerecho(new ArbolBinario<int>(7));
			
			arbolBinarioA.agregarHijoIzquierdo(hijoIzquierdo);
			arbolBinarioA.agregarHijoDerecho(hijoDerecho);*/

			/*Console.WriteLine("PreOrden...");
			arbolBinarioA.preorden();
			Console.WriteLine("\ninOrden...");
			arbolBinarioA.inorden();
			Console.WriteLine("\nPostOrden...");
			arbolBinarioA.postorden();
			Console.WriteLine("\nPorNiveles...");
			arbolBinarioA.recorridoPorNiveles();
			Console.WriteLine("\nIncluye: "+arbolBinarioA.incluye(1));
			Console.WriteLine("Cantidad hojas: "+arbolBinarioA.contarHojas());
			Console.WriteLine("Recorrido entre niveles...");
			arbolBinarioA.recorridoEntreNiveles(1,2);
			RedBinariaLlena rb = new RedBinariaLlena(arbolBinarioA);
			Console.WriteLine("Retardo máximo: "+rb.retardoReenvio());
			ProfundidadDeArbolBinario pb = new ProfundidadDeArbolBinario(arbolBinarioA);
			Console.WriteLine("Suma elementos: "+pb.sumaElementosProfundidad(2));*/
        }
    }
}
