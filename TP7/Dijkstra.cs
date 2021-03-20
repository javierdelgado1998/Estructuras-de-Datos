using System;
using System.Collections.Generic;
namespace TP7
{
    public class Dijkstra
    {
		public void algoritmoDijkstra(Grafo<int> grafo, Vertice<int> origen)
		{
			List<Vertice<int>> verticesAux = grafo.getVertices();
			Vertice<int>[] vertices = new Vertice<int>[verticesAux.Count];
			int[] distancia = new int[verticesAux.Count];
			bool[] procesado = new bool[verticesAux.Count];
			vertices[0] = origen;
			//procesado[0] = true;
			distancia[0] = 0;
			for (int i = 0; i < vertices.Length; i++)
			{
				if(verticesAux[i] != origen)
				{
					vertices[i] = verticesAux[i];
					distancia[i] = int.MaxValue;
				}
			}
			this._algoritmoDijkstra(vertices,distancia,procesado);
		}
		private void _algoritmoDijkstra(Vertice<int>[] vertices,int[] distancia,bool[] procesado)
		{
			Vertice<int> v;
			for (int i = 0; i < vertices.Length; i++)
			{
				int indice = minimaDistancia(distancia);
				v = vertices[indice];
				Console.WriteLine("v {0}",v.getDato());
				procesado[indice] = true;
				foreach (var ady in v.getAdyacentes())
				{
					if(!procesado[ady.getDestino().getPosicion() - 1])
					{
						if(distancia[indice] + ady.getPeso() < distancia[ady.getDestino().getPosicion()-1])
						{
							Console.WriteLine("Entre al if");
							distancia[ady.getDestino().getPosicion()-1] = distancia[indice] + ady.getPeso();
							Console.WriteLine(distancia[ady.getDestino().getPosicion()-1]);
							//Console.Write(v.getDato() + " ");
						}
					}
				}
			}
		} 
		private int minimaDistancia(int[] costo)
		{
			int index = 0;
			int costoAux = costo[0];
			for (int i = 0; i < costo.Length; i++)
			{
				if(costo[i] <= costoAux)
				{
					costoAux = costo[i];
					index = i;
				}
			}
			return index;
		}      
    }
}