using System;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolGeneral<string> arbolD = new ArbolGeneral<string>("blanco");
            ArbolGeneral<string> arbolA = new ArbolGeneral<string>("gris");
            ArbolGeneral<string> arbolV = new ArbolGeneral<string>("blanco");
            ArbolGeneral<string> arbolI = new ArbolGeneral<string>("negro");
            ArbolGeneral<string> arbolB = new ArbolGeneral<string>("negro");
            ArbolGeneral<string> arbolJ = new ArbolGeneral<string>("negro");
            ArbolGeneral<string> arbolU = new ArbolGeneral<string>("blanco");
            ArbolGeneral<string> arbolK = new ArbolGeneral<string>("blanco");
            ArbolGeneral<string> arbolX = new ArbolGeneral<string>("negro");
            arbolD.agregarHijo(arbolA);
            arbolD.agregarHijo(arbolV);
            arbolD.agregarHijo(arbolI);
            arbolD.agregarHijo(arbolB);
            arbolV.agregarHijo(arbolJ);
            arbolV.agregarHijo(arbolU);
            arbolV.agregarHijo(arbolK);
            arbolV.agregarHijo(arbolX);
            //RedAgua r = new RedAgua(arbolD);
            QuadTree q = new QuadTree(arbolD);
            Console.Write("Inorden: ");
            arbolD.inOrden();
            Console.WriteLine();
            Console.Write("preOrden: ");
            arbolD.preOrden();
            Console.WriteLine();
            Console.Write("postOrden: ");
            arbolD.postOrden();
            Console.WriteLine();
            Console.Write("porNiveles: ");
            arbolD.porNiveles();
            Console.WriteLine();
            Console.Write("Altura: "+arbolD.altura());
            Console.WriteLine();
            Console.Write("Ancho: "+arbolD.ancho());
            Console.WriteLine();
            Console.Write("Nivel: "+(arbolD.nivel(arbolD)));
            Console.WriteLine();
           //Console.Write("Caudal mínimo: "+r.caudalMinimo(1000));
            Console.Write("Píxeles: "+q.quadTree(1024));
        }
    }
}
