using System.Collections.Generic;
using System;

namespace TP7
{
    public class Recorrido
    {
        public List<Vertice<int>> verticesADistanciaConBFS(Grafo<int> grafo,Vertice<int> origen, int aristas)
        {
			bool[] visitados = new bool[grafo.getVertices().Count];
			Cola<Vertice<int>> c = new Cola<Vertice<int>>();
			List<Vertice<int>> listaV = new List<Vertice<int>>();
			Vertice<int> vertAux;
            int nivel = 0;
			c.encolar(origen);
            c.encolar(null);
			visitados[origen.getPosicion() -1] = true;
			while(!c.esVacia())
			{
				vertAux = c.desencolar();
                if(vertAux == null)
                {
                    if(nivel == aristas)
                    {
                        return listaV;
                    }
					nivel++;
					listaV.Clear();
					if(!c.esVacia())
					{
						c.encolar(null);
					}
                }
				if(vertAux != null)
				{
					listaV.Add(vertAux);
					foreach (var ady in vertAux.getAdyacentes())
					{
						if(!visitados[ady.getDestino().getPosicion() - 1])
						{
							c.encolar(ady.getDestino());
							visitados[ady.getDestino().getPosicion() - 1] = true;
						}
					}
				}
			} 
			return null;         
        }
		public List<Vertice<int>> caminoSimpleConDFS(Grafo<int> grafo, Vertice<int> origen, Vertice<int> destino)
		{
			bool[] visitados = new bool[grafo.getVertices().Count];
			List<Vertice<int>> camino = new List<Vertice<int>>();
			return this._caminoSimpleConDFS(camino,origen,destino,visitados);
		}
		private List<Vertice<int>> _caminoSimpleConDFS(List<Vertice<int>> camino, Vertice<int> origen, Vertice<int> destino, bool[] visitados)
		{
			camino.Add(origen);
			visitados[origen.getPosicion()-1] = true;
			if(origen == destino)
			{
				foreach (var vertice in camino)
				{
					Console.Write(vertice.getDato() + " ");
				}
				return camino;
			}
			else
			{
				foreach (var ady in origen.getAdyacentes())
				{
					if(!visitados[ady.getDestino().getPosicion() - 1])
					{
						this._caminoSimpleConDFS(camino,ady.getDestino(),destino,visitados);
						camino.RemoveAt(camino.Count-1);
					}
				}
			}
			return null;
		}
    }
}