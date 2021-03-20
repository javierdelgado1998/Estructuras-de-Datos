using System;
using System.Collections.Generic;
namespace TP7
    {
    public class OrdenTopologico
    {
		public List<Vertice<int>> ordenTopologico(Grafo<int> grafo) {
			bool[] visitados = new bool[grafo.getVertices().Count];
            List<Vertice<int>> camino = new List<Vertice<int>>();
            Stack<Vertice<int>> pila = new Stack<Vertice<int>>();
			foreach (var vertice in grafo.getVertices())
			{
				if(vertice.entradaCero())
				{
					this._ordenTopologico(vertice,visitados,pila);
				}
			}
            while(pila.Count !=0)
            {
                camino.Add(pila.Pop());
            }
            return camino;
		}
		
		private void _ordenTopologico(Vertice<int> origen, bool[] visitados,Stack<Vertice<int>> pila)
		{
			//Console.Write(origen.getDato() + " ");
			visitados[origen.getPosicion() - 1] = true;	
			foreach (var ady in origen.getAdyacentes())
			{
				if(!visitados[ady.getDestino().getPosicion()-1]) 
				{
					this._ordenTopologico(ady.getDestino(),visitados,pila);
				}
			}
			pila.Push(origen);
		}       
    }
}