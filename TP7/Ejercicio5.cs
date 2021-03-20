using System.Collections.Generic;
using System;
namespace TP7
{
    public class Ejercicio5
    {
		public List<Vertice<int>> caminoMayor(Grafo<int> grafo, Vertice<int> origen)
		{
			bool[] visitados = new bool[grafo.getVertices().Count];
			List<List<Vertice<int>>> mejoresCaminos = new List<List<Vertice<int>>>();
			foreach (var vertice in grafo.getVertices())
			{
				List<Vertice<int>> camino = new List<Vertice<int>>();
				List<Vertice<int>> mejorCaminoAux = new List<Vertice<int>>();
				this._caminoMayor(camino,origen,vertice,visitados,mejorCaminoAux);
				mejoresCaminos.Add(mejorCaminoAux);
			}
			List<Vertice<int>> mejorCamino = mejoresCaminos[0];
			foreach (var camino in mejoresCaminos)
			{
				if(camino.Count > mejorCamino.Count)
				{
					mejorCamino.Clear();
					mejorCamino.AddRange(camino);
				}
			}
			return mejorCamino;
		}
		private List<Vertice<int>> _caminoMayor(List<Vertice<int>> camino, Vertice<int> origen, Vertice<int> destino, bool[] visitados, List<Vertice<int>> mejorCamino)
		{
			camino.Add(origen);
			visitados[origen.getPosicion()-1] = true;
			if(origen == destino)
			{
				int tiempo = 0;
				for (int i = 0; i < camino.Count; i++)
				{
					tiempo += camino[i].getDato();
					List<Arista<int>> adyacentes = camino[i].getAdyacentes();
					for (int j = 0; j < adyacentes.Count; j++)
					{
						if(i != camino.Count-1)
						{
							if(adyacentes[j].getDestino() == camino[i+1])
							{
								tiempo+= adyacentes[j].getPeso();
							}
						}
					}
				}
				if(camino.Count >= mejorCamino.Count && tiempo <= 120)//120 min = 2 hs
				{
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
						this._caminoMayor(camino,ady.getDestino(),destino,visitados, mejorCamino);
                        visitados[ady.getDestino().getPosicion() - 1] = false;
						camino.RemoveAt(camino.Count-1);
					}
				}
			}
			return null;
		}        
    }
}