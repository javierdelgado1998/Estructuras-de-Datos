using System;
using System.Collections.Generic;
namespace TP1
{
    public class QuadTree
    {
        ArbolGeneral<string> arbol;
        public QuadTree(ArbolGeneral<string> arbol)
        {
            this.arbol = arbol;
        }
		public double quadTree(double pixeles)
		{
			Cola<ArbolGeneral<string>> c = new Cola<ArbolGeneral<string>>();
			ArbolGeneral<string> aux;
			double auxMath = 0;
			double p = 0;
            int nivel=0;
            c.encolar(arbol);
            c.encolar(null);
			while(!c.esVacia())
			{
				aux = c.desencolar();
				if(aux == null)
				{
                    nivel++;
                    auxMath = pixeles/(Math.Pow(4,nivel));
                    Console.WriteLine(auxMath);
					if(!c.esVacia())
					{
						c.encolar(null);
					}
				}
				else
				{
                    if(aux.esHoja() && aux.getDatoRaiz() == "negro")
                    {
                        p += auxMath;
                    }
					foreach (var hijo in aux.getHijos())
					{
						c.encolar(hijo);
					}
				}
			}
			return p;
		}
    }
}