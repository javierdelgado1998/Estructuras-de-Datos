using System;
using System.Collections.Generic;

namespace TP1
{
	public class ArbolGeneral<T>
	{
		
		private T dato;
		private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();

		public ArbolGeneral(T dato) {
			this.dato = dato;
		}

		public void setDatoRaiz(T dato)
		{
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public List<ArbolGeneral<T>> getHijos() {
			return hijos;
		}
	
		public void agregarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Add(hijo);
		}
	
		public void eliminarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Remove(hijo);
		}
	
		public bool esHoja() {
			return this.getHijos().Count == 0;
		}
	
		public int altura()
		{
			//Inicializamos variable local en 0, donde guardaremos la altura.
			int alturaMax = 0;
			int hAltura;
			//Si es hoja retornamos 0.
			if(this.esHoja())
			{
				return alturaMax;
			}
			//Si no es hoja, entonces recorremos sus hijos... 
			foreach (var hijo in this.getHijos())
			{
				//Comparamos que hijo tiene la altura mas grande.
				hAltura = hijo.altura();
				if(hAltura > alturaMax)
				{
					alturaMax = hAltura;
				}
			}
			//Retornamos la altura + 1.
			return alturaMax+1;
		}
		
		public int nivel(ArbolGeneral<T> dato) 
		{
			Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> aux;
			int nivel = 0;
			c.encolar(this);
			c.encolar(null);
			while(!c.esVacia())
			{
				aux = c.desencolar();
				if(aux == dato)
				{
					return nivel;
				}
				if(aux == null)
				{
					nivel++;
					if(!c.esVacia())
					{
						c.encolar(null);
					}
				}
				else
				{
					foreach (var hijo in aux.getHijos())
					{
						c.encolar(hijo);
					}
				}
			}
			return nivel;
		}

		public int ancho()
		{
			Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();	//Instanciamos la cola
			ArbolGeneral<T> aux;	//Declaramos un arbol auxiliar
			int nodos = 0;	//Contador de nodos
			int ancho = 0;	//Ancho del nivel
			c.encolar(this);	//Encolamos el propio arbol
			c.encolar(null);	//Encolamos el separador
			while(!c.esVacia())	//Mientras la cola tenga elementos
			{
				aux = c.desencolar();	//Desencolamos el arbol aux
				if (aux == null)		//Si es un separador...
				{
					if(nodos > ancho)	//Comparamos si la cantidad de nodos es mayor al ancho actual
					{
						ancho = nodos;	//Nos quedamos con el mayor
					}

					nodos = 0;			//Reseteamos el contador de nodos

					if(!c.esVacia())	//Si la cola todavia tiene elementos...
					{
						c.encolar(null);	//Encolamos el separador
					}
				}
				else	//Si no es un separador...
				{
					nodos++;				//Aumentamos el contador de nodos
					foreach (var hijo in aux.getHijos())	//Recorremos los hijos restantes
					{
						c.encolar(hijo);		//Encolamos los hijos
					}
				}				
			}
			return ancho;	//Retornamos el ancho de cada nivel
		}

		public void inOrden()
		{
			// primero primer hijo recursivamente
			if(!this.esHoja())
			{
				this.getHijos()[0].inOrden();
			}
			
			// luego raiz
			Console.Write(this.getDatoRaiz() + " ");
			
			// por ultimo los hijos restantes recursivamente
			if(this.getHijos().Count > 1)
			{
				for(int i = 1; i < this.getHijos().Count; i++)
				{
					this.getHijos()[i].inOrden();
				}
					
			}				
		}
		public void preOrden()
		{
			//Primero proceso la raiz
			Console.Write(this.getDatoRaiz() + " ");
			//Despues los  hijos
			foreach (var hijo in this.getHijos())
			{
				hijo.preOrden();
			}			
		}
		public void postOrden()
		{
			//Primero proceso los hijos
			foreach (var hijo in this.getHijos())
			{
				hijo.postOrden();
			}
			//Despues la raiz
			Console.Write(this.getDatoRaiz() + " ");
		}
		public void porNiveles()
		{
			Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> aux;
			c.encolar(this);
			while(!c.esVacia())
			{
				aux = c.desencolar();
				Console.Write(aux.getDatoRaiz() + " ");
				foreach (var hijo in aux.getHijos())
				{
					c.encolar(hijo);
				}
			}
		}
	}
}
