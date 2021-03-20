using System;
using System.Collections.Generic;
namespace Complejidad.TP3
{
    public class ArbolAVLDeMuestras : AVL
    {
        public ArbolAVLDeMuestras(IComparable dato): base(dato)
        {

        }
        public override int CompareTo(Object x)
		{
			return this.getDatoRaiz().CompareTo(((ArbolAVLDeMuestras)x).getDatoRaiz());
		}
        public int minimoDeltaHistorico(int numero)
        {
            //int deltaMenor = 0;
            //int deltaMayor = 999;
            return 0;
        }
    }
}