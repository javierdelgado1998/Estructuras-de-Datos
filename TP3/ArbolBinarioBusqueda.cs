using System;

namespace Complejidad.TP3
{

	public class ArbolBinarioBusqueda : IComparable
	{

		private IComparable dato;
		private ArbolBinarioBusqueda hijoIzquierdo;
		private ArbolBinarioBusqueda hijoDerecho;
		
		public ArbolBinarioBusqueda(IComparable dato){
			this.dato = dato;
		}
		
		public IComparable getDatoRaiz(){
			return this.dato;
		}
		
		public ArbolBinarioBusqueda getHijoIzquierdo(){
			return this.hijoIzquierdo;
		}
		
		public ArbolBinarioBusqueda getHijoDerecho(){
			return this.hijoDerecho;
		}
		
		public void agregarHijoIzquierdo(ArbolBinarioBusqueda hijo){
			this.hijoIzquierdo=hijo;
		}

		public void agregarHijoDerecho(ArbolBinarioBusqueda hijo){
			this.hijoDerecho=hijo;
		}
		
		public void eliminarHijoIzquierdo(){
			this.hijoIzquierdo=null;
		}
		
		public void eliminarHijoDerecho(){
			this.hijoDerecho=null;
		}
		//-----------------------------METODO AGREGAR---------------------------------
		public void agregar(IComparable elem) 
		{
			if(((ArbolBinarioBusqueda)elem).CompareTo(this) > 0)
			{
				if(this.getHijoDerecho() == null)
				{
					this.agregarHijoDerecho((ArbolBinarioBusqueda)elem);
				}
				else
				{
					this.getHijoDerecho().agregar(elem);
				}
			}
			else
			{
				if(this.getHijoIzquierdo() == null)
				{
					this.agregarHijoIzquierdo((ArbolBinarioBusqueda)elem);
				}
				else
				{
					this.getHijoIzquierdo().agregar(elem);
				}
			}	
		}
		//------------------------------------------------------------------------------
		public bool incluye(IComparable elem) 
		{
			Cola<ArbolBinarioBusqueda> c = new Cola<ArbolBinarioBusqueda>();
			ArbolBinarioBusqueda aux;
			c.encolar(this);
			while(!c.esVacia())
			{
				aux = c.desencolar();
				if(aux.Equals((ArbolBinarioBusqueda)elem))
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

		public void preOrden() 
		{
			Console.Write(this.getDatoRaiz() + " ");
			if(this.getHijoIzquierdo() != null)
			{
				this.hijoIzquierdo.preOrden();
			}
			if(this.getHijoDerecho() != null)
			{
				this.hijoDerecho.preOrden();
			}
		}
		
		public void inOrden() 
		{
			if(this.getHijoIzquierdo() != null)
			{
				this.hijoIzquierdo.inOrden();
			}
			Console.Write(this.getDatoRaiz() + " ");
			if(this.getHijoDerecho() != null){
				this.hijoDerecho.inOrden();
			}
		}
		
		public void postOrden() 
		{
			if(this.getHijoIzquierdo() != null)
			{
				this.hijoIzquierdo.postOrden();
			}
			if(this.getHijoDerecho() != null)
			{
				this.hijoDerecho.postOrden();
			}
			Console.Write(this.getDatoRaiz() + " ");
		}

		public int CompareTo(Object x)
		{
			return this.getDatoRaiz().CompareTo(((ArbolBinarioBusqueda)x).getDatoRaiz());
		}

	}

}

//---------------------------------------Opcion 2---------------------------------------------------
/*using System;

namespace Complejidad.TP3
{

	public class ArbolBinarioBusqueda : IComparable
	{

		private IComparable dato;
		private ArbolBinarioBusqueda hijoIzquierdo;
		private ArbolBinarioBusqueda hijoDerecho;
		
		public ArbolBinarioBusqueda(IComparable dato){
			this.dato = dato;
		}
		
		public IComparable getDatoRaiz(){
			return this.dato;
		}
		
		public ArbolBinarioBusqueda getHijoIzquierdo(){
			return this.hijoIzquierdo;
		}
		
		public ArbolBinarioBusqueda getHijoDerecho(){
			return this.hijoDerecho;
		}
		
		public void agregarHijoIzquierdo(ArbolBinarioBusqueda hijo){
			this.hijoIzquierdo=hijo;
		}

		public void agregarHijoDerecho(ArbolBinarioBusqueda hijo){
			this.hijoDerecho=hijo;
		}
		
		public void eliminarHijoIzquierdo(){
			this.hijoIzquierdo=null;
		}
		
		public void eliminarHijoDerecho(){
			this.hijoDerecho=null;
		}
		//-----------------------------METODO AGREGAR---------------------------------
		public void agregar(IComparable elem) 
		{
			if(elem.sosMayor(this.getDatoRaiz()))
			{
				if(this.getHijoDerecho() == null)
				{
					this.agregarHijoDerecho((ArbolBinarioBusqueda)elem);
				}
				else
				{
					this.getHijoDerecho().agregar(elem);
				}
			}
			if(elem.sosMenor(this.getDatoRaiz()))
			{
				if(this.getHijoIzquierdo() == null)
				{
					this.agregarHijoIzquierdo((ArbolBinarioBusqueda)elem);
				}
				else
				{
					this.getHijoIzquierdo().agregar(elem);
				}
			}		
		}
		//------------------------------------------------------------------------------
		public bool incluye(IComparable elem) 
		{
			Cola<ArbolBinarioBusqueda> c = new Cola<ArbolBinarioBusqueda>();
			ArbolBinarioBusqueda aux;
			c.encolar(this);
			while(!c.esVacia())
			{
				aux = c.desencolar();
				if(aux.sosIgual(elem))
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

		public void preOrden() 
		{
			Console.Write(this.getDatoRaiz() + " ");
			if(this.getHijoIzquierdo() != null)
			{
				this.hijoIzquierdo.preOrden();
			}
			if(this.getHijoDerecho() != null)
			{
				this.hijoDerecho.preOrden();
			}
		}
		
		public void inOrden() 
		{
			if(this.getHijoIzquierdo() != null)
			{
				this.hijoIzquierdo.inOrden();
			}
			Console.Write(this.getDatoRaiz() + " ");
			if(this.getHijoDerecho() != null){
				this.hijoDerecho.inOrden();
			}
		}
		
		public void postOrden() 
		{
			if(this.getHijoIzquierdo() != null)
			{
				this.hijoIzquierdo.postOrden();
			}
			if(this.getHijoDerecho() != null)
			{
				this.hijoDerecho.postOrden();
			}
			Console.Write(this.getDatoRaiz() + " ");
		}
		public bool sosIgual(IComparable elem)
		{
			return this == elem; //Comparo por referencia 
		}
		public bool sosMenor(IComparable elem)
		{
			return this.getDatoRaiz().sosMenor(elem);
		}
		public bool sosMayor(IComparable elem)
		{
			return this.getDatoRaiz().sosMayor(elem);
		}
	}
    public class Numero : IComparable
    {
        private int dato;
        public Numero (int dato)
        {
            this.dato = dato;
        }

        public int getNumero()
        {
            return dato;
        }
        public bool sosIgual(IComparable c)
        {
            return this.dato == ((Numero)c).dato;
        }
        public bool sosMenor(IComparable c)
        {
            return this.dato < ((Numero)c).dato;
        }
        public bool sosMayor(IComparable c)
        {
            return this.dato >= ((Numero)c).dato;
        }

        public override string ToString()
        {
            return dato.ToString();
        }
    }
    public interface IComparable
    {
        public bool sosIgual(IComparable c);
        public bool sosMenor(IComparable c);
        public bool sosMayor(IComparable c);
    }
}*/