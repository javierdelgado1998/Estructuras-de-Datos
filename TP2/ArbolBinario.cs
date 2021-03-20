using System;

namespace TP2
{
	public class ArbolBinario<T>
	{
		private T dato;
		private ArbolBinario<T> hijoIzquierdo;
		private ArbolBinario<T> hijoDerecho;
		
		public ArbolBinario(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}

		public void setDatoRaiz(T dato)
		{
			this.dato = dato;
		}
	
		public ArbolBinario<T> getHijoIzquierdo() {
			return this.hijoIzquierdo;
		}
	
		public ArbolBinario<T> getHijoDerecho() {
			return this.hijoDerecho;
		}
	
		public void agregarHijoIzquierdo(ArbolBinario<T> hijo) {
			this.hijoIzquierdo=hijo;
		}
	
		public void agregarHijoDerecho(ArbolBinario<T> hijo) {
			this.hijoDerecho=hijo;
		}
	
		public void eliminarHijoIzquierdo() {
			this.hijoIzquierdo=null;
		}
	
		public void eliminarHijoDerecho() {
			this.hijoDerecho=null;
		}
	
		public bool esHoja() {
			return this.hijoIzquierdo==null && this.hijoDerecho==null;
		}
		public void agregar(ArbolBinario<T> arbol)
		{
			if(Convert.ToInt32(arbol.getDatoRaiz()) > Convert.ToInt32(this.getDatoRaiz()))
			{
				if(this.getHijoDerecho() == null)
				{
					this.agregarHijoDerecho(arbol);
				}
				else
				{
					this.getHijoDerecho().agregar(arbol);
				}
			}
			if(Convert.ToInt32(arbol.getDatoRaiz()) < Convert.ToInt32(this.getDatoRaiz()))
			{
				if(this.getHijoIzquierdo() == null)
				{
					this.agregarHijoIzquierdo(arbol);
				}
				else
				{
					this.getHijoIzquierdo().agregar(arbol);
				}
			}
		}
		
		public void inorden() {
			if(this.getHijoIzquierdo() != null)
			{
				this.hijoIzquierdo.inorden();
			}
			Console.Write(this.getDatoRaiz() + " ");
			if(this.getHijoDerecho() != null){
				this.hijoDerecho.inorden();
			}
		}
		
		public void preorden() {
			Console.Write(this.getDatoRaiz() + " ");
			if(this.getHijoIzquierdo() != null)
			{
				this.hijoIzquierdo.preorden();
			}
			if(this.getHijoDerecho() != null)
			{
				this.hijoDerecho.preorden();
			}
		}
		
		public void postorden() {
			if(this.getHijoIzquierdo() != null)
			{
				this.hijoIzquierdo.postorden();
			}
			if(this.getHijoDerecho() != null)
			{
				this.hijoDerecho.postorden();
			}
			Console.Write(this.getDatoRaiz() + " ");
		}
		
		public void recorridoPorNiveles() {
			Cola<ArbolBinario<T>> c = new Cola<ArbolBinario<T>>();
			ArbolBinario<T> aux;
			c.encolar(this);
			while(!c.esVacia())
			{
				aux = c.desencolar();
				Console.Write(aux.getDatoRaiz() + " ");
				if(aux.getHijoIzquierdo() != null)
				{
					c.encolar(aux.getHijoIzquierdo());
				}
				if(aux.getHijoDerecho() != null)
				{
					c.encolar(aux.getHijoDerecho());
				}
			}
		}
		public bool incluye(T dato)
		{
			Cola<ArbolBinario<T>> c = new Cola<ArbolBinario<T>>();
			ArbolBinario<T> aux;
			c.encolar(this);
			while(!c.esVacia())
			{
				aux = c.desencolar();
				if(aux.getDatoRaiz().Equals(dato))
				{
					return true;
				}
				if(aux.getHijoIzquierdo() != null)
				{
					c.encolar(aux.hijoIzquierdo);
				}
				if(aux.getHijoDerecho() != null)
				{
					c.encolar(aux.hijoDerecho);
				}
			}
			return false;
		}
	
		public int contarHojas() {
			int hojas = 0;
			if(this.esHoja())
			{
				return hojas+1;
			}
			if(this.getHijoIzquierdo() != null)
			{
				hojas += this.getHijoIzquierdo().contarHojas();
			}
			if(this.getHijoDerecho() != null)
			{
				hojas += this.getHijoDerecho().contarHojas();
			}
			return hojas;
		}
		/*public int contarHojas()
		{
			Cola<ArbolBinario<T>> c = new Cola<ArbolBinario<T>>();
			ArbolBinario<T> aux;
			int hojas = 0;
			c.encolar(this);
			while(!c.esVacia())
			{
				aux = c.desencolar();
				if(aux.esHoja())
				{
					hojas++;
				}
				if(aux.getHijoIzquierdo() != null)
				{
					c.encolar(aux.hijoIzquierdo);
				}
				if(aux.getHijoDerecho() != null)
				{
					c.encolar(aux.hijoDerecho);
				}
			}
			return hojas;
		}*/
		public void recorridoEntreNiveles(int n,int m)
		{
			Cola<ArbolBinario<T>> c = new Cola<ArbolBinario<T>>();
			ArbolBinario<T> aux;
			int nivel = 0;
			c.encolar(this);
			c.encolar(null);
			while(!c.esVacia())
			{
				aux = c.desencolar();
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
					if(nivel >= n && nivel <= m)
					{
						Console.Write(aux.getDatoRaiz() + " ");
					}
					if(aux.getHijoIzquierdo() != null)
					{
						c.encolar(aux.hijoIzquierdo);
					}
					if(aux.getHijoDerecho() != null)
					{
						c.encolar(aux.hijoDerecho);
					}
				}

			}
		}
	}
}
