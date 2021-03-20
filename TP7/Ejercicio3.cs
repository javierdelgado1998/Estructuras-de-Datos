using System;
using System.Collections.Generic;
namespace TP7
{
    public class Ejercicio3
    {
		public int minEncrucijadas(Grafo<string> grafo, Vertice<string> origen, Vertice<string> destino)
		{
			bool[] visitados = new bool[grafo.getVertices().Count];
			List<Vertice<string>> camino = new List<Vertice<string>>();
            List<Vertice<string>> mejorCamino = grafo.getVertices();
			this._minEncrucijadas(camino,origen,destino,visitados,mejorCamino);
            return mejorCamino.Count-1;
		}
		private List<Vertice<string>> _minEncrucijadas(List<Vertice<string>> camino, Vertice<string> origen, Vertice<string> destino, bool[] visitados, List<Vertice<string>> mejorCamino)
		{
			camino.Add(origen);
			visitados[origen.getPosicion()-1] = true;
			if(origen == destino)
			{
                //Console.WriteLine("\nLongitud camino actual: "+camino.Count);
                //Console.WriteLine("\nLongitud mejor camino: "+mejorCamino.Count);
				foreach (var vertice in camino)
				{
					Console.Write(vertice.getDato() + " ");
				}
                if(camino.Count < mejorCamino.Count)
                {
                    //Console.WriteLine("\nHaciendo la copia.");
                    mejorCamino.Clear();
                    mejorCamino.AddRange(camino);
                }
                return camino;
			}
			else
			{
				foreach (var ady in origen.getAdyacentes())
				{
					if(!visitados[ady.getDestino().getPosicion() - 1])
					{
						this._minEncrucijadas(camino,ady.getDestino(),destino,visitados, mejorCamino);
                        visitados[ady.getDestino().getPosicion() - 1] = false;
						camino.RemoveAt(camino.Count-1);
					}
				}
			}
			return null;
		}
    }
}