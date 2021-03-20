using System;
using System.Collections.Generic;
namespace Complejidad.TP3
{

	public class AVL : IComparable
	{
		
		protected IComparable dato;
		protected AVL hijoIzquierdo;
		protected AVL hijoDerecho;
		protected int altura;
		
		public AVL(IComparable dato){
			this.dato = dato;
		}
		
		public IComparable getDatoRaiz(){
			return this.dato;
		}
		
		public AVL getHijoIzquierdo(){
			return this.hijoIzquierdo;
		}
		
		public AVL getHijoDerecho(){
			return this.hijoDerecho;
		}
	
		public void agregarHijoIzquierdo(AVL hijo){
			this.hijoIzquierdo=hijo;
		}

		public void agregarHijoDerecho(AVL hijo){
			this.hijoDerecho=hijo;
		}
		
		public void eliminarHijoIzquierdo(){
			this.hijoIzquierdo=null;
		}
		
		public void eliminarHijoDerecho(){
			this.hijoDerecho=null;
		}

		public int getAltura()
		{
			return this.altura;
		}
		
		public AVL agregar(IComparable elem) 
		{
			
			// si elem es mayor que el dato almacenado en la raiz

			if(((AVL)elem).CompareTo(this) > 0)
			{
				// si el hijo derecho esta vacio, insero elem en ese lugar
				if(this.getHijoDerecho() == null)
				{
					this.agregarHijoDerecho((AVL)elem);
				}
				else
				{
					// si el arbol derecho NO esta vacio, llamo recursivamente a agregar()
					AVL nuevoHijoDerecho = this.getHijoDerecho().agregar(elem);
					this.agregarHijoDerecho(nuevoHijoDerecho);					
				}
				
			}
			// si elem es menor o igual que el dato almacenado en la raiz
			else
			{
				// idem anterior en hijo izquierdo
				if(this.getHijoIzquierdo() == null)
				{
					this.agregarHijoIzquierdo((AVL)elem);
				}
				else
				{
					AVL nuevoHijoIzquierdo = this.getHijoIzquierdo().agregar(elem);
					this.agregarHijoIzquierdo(nuevoHijoIzquierdo);
				}
			}
			   	
			// actualizar altura
			this.actualizarAltura();
			
			// control de desbalance
			AVL nuevaRaiz = this;
			int balance = this.calcularDesbalance();
			
			if(balance >= 2)	// desbalance del lado derecho
			{  
				
				// si elem es mayor que hijo derecho, entonces rotacion simple con derecho
				if(elem.CompareTo(this.getHijoDerecho()) > 0)
					nuevaRaiz = this.rotacionSimpleDerecha();
				// si elem es menor o igual, entonces rotacion doble con derecho
				else
					nuevaRaiz = this.rotacionDobleDerecha();
			}
			
			if(balance <= -2)	// desbalance del lado izquierdo
			{  
				
				// si elem es menor que hijo izquierdo, entonces rotacion simple con izquierdo
				if(elem.CompareTo(this.getHijoIzquierdo()) <= 0)
					nuevaRaiz = this.rotacionSimpleIzquierda();
				// si elem es mayor, entonces rotacion doble con izquierdo
				else
					nuevaRaiz = this.rotacionDobleIzquierda();
			}			   
			
			return nuevaRaiz;
		}
		
		// rotacion simple CON derecho
		public AVL rotacionSimpleDerecha() {
			// referencia a nueva raiz luego de la rotacion
			AVL nuevaRaiz = this.getHijoDerecho();
			
			// cambio hijo derecho de raiz actual
			this.agregarHijoDerecho(nuevaRaiz.getHijoIzquierdo());
			
			// cambiar hijo izquierdo de nueva raiz
			nuevaRaiz.agregarHijoIzquierdo(this);
			
			// actualizar altura de antigua raiz (this)
			this.actualizarAltura();
			
			// actualizar altua de nueva raiz
			nuevaRaiz.actualizarAltura();
			
			// retornamos nueva raiz
			return nuevaRaiz;
		}
		
		// rotacion simple CON izquierdo
		public AVL rotacionSimpleIzquierda() {
			// referencia a nueva raiz luego de la rotacion
			AVL nuevaRaiz = this.getHijoIzquierdo();
			
			// cambio hijo izquierdo de raiz actual
			this.agregarHijoIzquierdo(nuevaRaiz.getHijoDerecho());
			
			// cambiar hijo derecho de nueva raiz
			nuevaRaiz.agregarHijoDerecho(this);
			
			// actualizar altura de antigua raiz (this)
			this.actualizarAltura();
			
			// actualizar altua de nueva raiz
			nuevaRaiz.actualizarAltura();
			
			// retornamos nueva raiz
			return nuevaRaiz;
		}
		
		// rotacion doble con derecho
		public AVL rotacionDobleDerecha() {
			
			// 1ero: rotacion simple con izquierdo en hijo derecho
			AVL nuevoHijoDerecho = this.getHijoDerecho().rotacionSimpleIzquierda();
			this.agregarHijoDerecho(nuevoHijoDerecho);
			
			// 2do: rotacion simple con derecho
			return this.rotacionSimpleDerecha();				
		}
		
		// rotacion doble con izquerdo		
		public AVL rotacionDobleIzquierda() {
			// 1ero: rotacion simple con derecho en hijo izquierdo
			AVL nuevoHijoIzquierdo = this.getHijoIzquierdo().rotacionSimpleDerecha();
			this.agregarHijoIzquierdo(nuevoHijoIzquierdo);
			
			// 2do: rotacion simple con izquierdo
			return this.rotacionSimpleIzquierda();		
		}
		
		private void actualizarAltura(){
			int alturaIzq = -1;
			int alturaDer = -1;
			
			if(this.getHijoIzquierdo() != null)
				alturaIzq = this.getHijoIzquierdo().altura;
			
			if(this.getHijoDerecho() != null)
				alturaDer = this.getHijoDerecho().altura;
			
			if(alturaDer > alturaIzq)
				this.altura = alturaDer + 1;
			else
				this.altura = alturaIzq + 1;
		}
		
		private int calcularDesbalance(){
			int alturaIzq = -1;
			int alturaDer = -1;
			
			if(this.getHijoIzquierdo() != null)
				alturaIzq = this.getHijoIzquierdo().altura;
			
			if(this.getHijoDerecho() != null)
				alturaDer = this.getHijoDerecho().altura;
			
			return alturaDer - alturaIzq;
		}
		
		public void inorden() {
			// hijo izquierdo recursivamente
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.inorden();
			
			// raiz (dato)
			Console.Write(this.dato + " ");
			
			// hijo derecho recursivamente
			if(this.hijoDerecho != null)
				this.hijoDerecho.inorden();
		}
		
		public void preorden() {
			
			// raiz (dato)
			Console.Write(this.dato + " ");
			
			// hijo izquierdo recursivamente
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.preorden();			
			
			// hijo derecho recursivamente
			if(this.hijoDerecho != null)
				this.hijoDerecho.preorden();
		}
		
		public void postorden() {
						
			// hijo izquierdo recursivamente
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.postorden();			
			
			// hijo derecho recursivamente
			if(this.hijoDerecho != null)
				this.hijoDerecho.postorden();
			
			// raiz (dato)
			Console.Write(this.dato + " ");
		}
		
		public void recorridoPorNiveles() {
			Cola<AVL> c = new Cola<AVL>();
			AVL arbolAux;

			c.encolar(this);
			while(!c.esVacia()){
				arbolAux = c.desencolar();
				
				Console.Write(arbolAux.dato + " ");
				
				if(arbolAux.hijoIzquierdo != null)
					c.encolar(arbolAux.hijoIzquierdo);
				
				if(arbolAux.hijoDerecho != null)
					c.encolar(arbolAux.hijoDerecho);
								
			}
		}
		public virtual int CompareTo(Object x)
		{
			return this.getDatoRaiz().CompareTo(((AVL)x).getDatoRaiz());
		}
		
	}
}