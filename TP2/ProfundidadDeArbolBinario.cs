namespace TP2
{
    public class ProfundidadDeArbolBinario
    {
        ArbolBinario<int> arbol;
        public ProfundidadDeArbolBinario(ArbolBinario<int> arbol)
        {
            this.arbol = arbol;
        }
        public int sumaElementosProfundidad(int p)
        {
            Cola<ArbolBinario<int>> c = new Cola<ArbolBinario<int>>();
            ArbolBinario<int> aux;
            c.encolar(arbol);
            c.encolar(null);
            int profundidadActual = 0;
            int sumaElementos = 0;
            while(!c.esVacia())
            {
                aux = c.desencolar();
                if(aux == null)
                {
                    profundidadActual++;
                    if(!c.esVacia())
                    {
                        c.encolar(null);
                    }
                }
                else
                {
                    if(profundidadActual == p)
                    {
                        sumaElementos += aux.getDatoRaiz();
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
            return sumaElementos;
        }
    }
}