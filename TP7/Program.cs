using System;

namespace TP7
{
    class Program
    {
        static void Main(string[] args)
        {
            Grafo<string> gr = new Grafo<string>();
            Vertice<string> lp = new Vertice<string>("La plata");
            Vertice<string> pi = new Vertice<string>("Pilar");
            Vertice<string> ta = new Vertice<string>("Tandil");
            Vertice<string> ma = new Vertice<string>("Madariaga");
            Vertice<string> le = new Vertice<string>("Lezama");
            Vertice<string> mda = new Vertice<string>("Mar de Ajo");
            Vertice<string> mdq = new Vertice<string>("Mar del plata");
            Vertice<string> vg = new Vertice<string>("Villa Gessel");
            Vertice<string> pin = new Vertice<string>("Pinamar");
            gr.agregarVertice(lp);
            gr.agregarVertice(pi);
            gr.agregarVertice(ta);
            gr.agregarVertice(ma);
            gr.agregarVertice(le);
            gr.agregarVertice(mda);
            gr.agregarVertice(mdq);
            gr.agregarVertice(vg);
            gr.agregarVertice(pin);
            gr.conectar(lp,ta,0);
            gr.conectar(ta,lp,0);
            gr.conectar(lp,le,0);
            gr.conectar(le,lp,0);
            gr.conectar(le,pi,0);
            gr.conectar(pi,le,0);
            gr.conectar(le,mda,0);
            gr.conectar(mda,le,0);
            gr.conectar(ta,pi,0);
            gr.conectar(pi,ta,0);
            gr.conectar(ta,ma,0);
            gr.conectar(ma,ta,0);
            gr.conectar(mdq,ta,0);
            gr.conectar(ta,mdq,0);
            gr.conectar(pi,ma,0);
            gr.conectar(ma,pi,0);
            gr.conectar(pi,mda,0);
            gr.conectar(mda,pi,0);
            gr.conectar(mda,pin,0);
            gr.conectar(pin,mda,0);
            gr.conectar(mdq,vg,0);
            gr.conectar(vg,mdq,0);
            gr.conectar(pin,ma,0);
            gr.conectar(ma,pin,0);
            gr.conectar(pin,vg,0);
            gr.conectar(vg,pin,0);
            Console.WriteLine("Recorrido DFS GRAFO 1:");
            gr.DFS(lp);
            Console.WriteLine("\nRecorrido BFS GRAFO 1:");
            gr.BFS(lp);
            //****************************
            Grafo<int> gr2 = new Grafo<int>();
            Vertice<int> uno = new Vertice<int>(1);
            Vertice<int> dos = new Vertice<int>(2);
            Vertice<int> cuatro = new Vertice<int>(4);
            Vertice<int> cinco = new Vertice<int>(5);
            Vertice<int> tres = new Vertice<int>(3);
            Vertice<int> seis = new Vertice<int>(6);
            Vertice<int> siete = new Vertice<int>(7);
            gr2.agregarVertice(uno);
            gr2.agregarVertice(dos);
            gr2.agregarVertice(cuatro);
            gr2.agregarVertice(cinco);
            gr2.agregarVertice(tres);
            gr2.agregarVertice(seis);
            gr2.agregarVertice(siete);
            gr2.conectar(uno,dos,5);
            gr2.conectar(uno,cuatro,7);
            gr2.conectar(dos,cinco,3);
            gr2.conectar(tres,cinco,6);
            gr2.conectar(cuatro,tres,8);
            gr2.conectar(cuatro,cinco,5);
            gr2.conectar(cuatro,seis,6);
            gr2.conectar(cuatro,dos,2);
            gr2.conectar(cinco,siete,3);
            gr2.conectar(seis,tres,1);
            gr2.conectar(seis,siete,4);
            Console.WriteLine("\nBFS GRAFO 2");
            gr2.BFS(uno);
            Console.WriteLine("\nBuscador camino");
            Recorrido r = new Recorrido();
            r.caminoSimpleConDFS(gr2,uno,seis);
            Console.WriteLine("\nDistancia camino");
            foreach (var dato in r.verticesADistanciaConBFS(gr2,uno,1))
            {
                Console.Write(dato.getDato() + " ");
            }
            Console.WriteLine("\n----------EJERCICIO 3----------");
            Ejercicio3 ej3 = new Ejercicio3();
            Console.WriteLine("\nMínimo de encrucijadas: "+ej3.minEncrucijadas(gr,pin,ma));
            Console.WriteLine("\n----------EJERCICIO 4----------");
            Grafo<int> grafo3 = new Grafo<int>();
            Vertice<int> c1 = new Vertice<int>(1);
            Vertice<int> c2 = new Vertice<int>(2);
            Vertice<int> c4 = new Vertice<int>(4);
            Vertice<int> c5 = new Vertice<int>(5);
            Vertice<int> c3 = new Vertice<int>(3);
            grafo3.agregarVertice(c1);
            grafo3.agregarVertice(c2);
            grafo3.agregarVertice(c3);
            grafo3.agregarVertice(c4);
            grafo3.agregarVertice(c5);
            grafo3.conectar(c1,c3,0);
            grafo3.conectar(c3,c5,0);
            grafo3.conectar(c2,c3,0);
            grafo3.conectar(c2,c4,0);
            grafo3.conectar(c4,c5,0);
            OrdenTopologico topo = new OrdenTopologico();
            Console.WriteLine("\nORDEN TOPOLOGICO!!!");
            foreach (var vertice in topo.ordenTopologico(grafo3))
            {
                Console.Write(vertice.getDato() + " ");
            }
            Console.WriteLine("\n-------------EJERCICIO 5-------------");
            Grafo<int> grafo4 = new Grafo<int>();
            Vertice<int> v1 = new Vertice<int>(15);
            Vertice<int> v2 = new Vertice<int>(45);
            Vertice<int> v3 = new Vertice<int>(10);
            Vertice<int> v4 = new Vertice<int>(50);
            Vertice<int> v5 = new Vertice<int>(15);
            grafo4.agregarVertice(v1);
            grafo4.agregarVertice(v2);
            grafo4.agregarVertice(v3);
            grafo4.agregarVertice(v4);
            grafo4.agregarVertice(v5);
            grafo4.conectar(v1,v2,15);
            grafo4.conectar(v1,v4,10);
            grafo4.conectar(v2,v1,15);
            grafo4.conectar(v2,v4,15);
            grafo4.conectar(v2,v5,15);
            grafo4.conectar(v2,v3,15);
            grafo4.conectar(v3,v5,0);
            grafo4.conectar(v3,v2,15);
            grafo4.conectar(v4,v1,10);
            grafo4.conectar(v4,v2,15);
            grafo4.conectar(v4,v5,10);
            grafo4.conectar(v5,v2,15);
            grafo4.conectar(v5,v3,0);
            grafo4.conectar(v5,v4,10);
            Grafo<int> grafo5 = new Grafo<int>();
            Ejercicio5 mejorCamino = new Ejercicio5();
            foreach (var vertice in mejorCamino.caminoMayor(grafo4,v1))
            {
                Console.Write(vertice.getDato() + " ");
            }
            Console.WriteLine("\n--------------DIJKSTRA ALGORITHM!!!---------");
            Dijkstra dijkstra = new Dijkstra();
            dijkstra.algoritmoDijkstra(gr2,uno);


        }
    }
}
