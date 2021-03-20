using System;
using System.Collections.Generic;
namespace TP1
{
    public class RedAgua
    {
        ArbolGeneral<float> arbol;
        public RedAgua(ArbolGeneral<float> arbol)
        {
            this.arbol = arbol;
        }
        public float caudalMinimo(float caudal)
        {
            ArbolGeneral<float> aux;
            Cola<ArbolGeneral<float>> c = new Cola<ArbolGeneral<float>>();
            float cMinimo = caudal;
            arbol.setDatoRaiz(caudal);
            c.encolar(arbol);
            while(!c.esVacia())
            {
                aux = c.desencolar();
                if(!aux.esHoja())
                {
                    float caudalHijos = aux.getDatoRaiz() / aux.getHijos().Count;
                    if(caudalHijos < cMinimo)
                    {
                        cMinimo = caudalHijos;
                    }
                    foreach (var hijo in aux.getHijos())
                    {
                        hijo.setDatoRaiz(caudalHijos);
                        c.encolar(hijo);
                    }
                }
            }
            return cMinimo;
        }

    }
}