using System;
namespace TP2
{
    public class RedBinariaLlena
    {
        ArbolBinario<int> arbol;
        public RedBinariaLlena(ArbolBinario<int> arbol)
        {
            this.arbol = arbol;
        }
        public int retardoReenvio()
        {
            Cola<ArbolBinario<int>> c = new Cola<ArbolBinario<int>>();
            ArbolBinario<int> aux;
            int retardoMax = 0;
            int retardoAux = 0;
            c.encolar(arbol);
            c.encolar(null);
            while(!c.esVacia())
            {
                aux = c.desencolar();
                if(aux == null)
                {
                    retardoMax += retardoAux;
                    retardoAux = 0;
                    if(!c.esVacia())
                    {
                        c.encolar(null);
                    }
                }
                else
                {
                    if(aux.getDatoRaiz() > retardoAux)
                    {
                        retardoAux = aux.getDatoRaiz();
                    }
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
            return retardoMax;
        }
    }
}