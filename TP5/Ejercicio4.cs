/*using System;
using System.Collections;
namespace Complejidad.TP5
{
    public class Ejercicio4
    {
        private static Random rand = new Random();
        public static void main(String[] args)
        {
            Console.WriteLine(randomUno(1000));
            Console.WriteLine(randomDos(1000));
            Console.WriteLine(randomTres(1000));
        }
        private static void swap(int[]a, int i, int j)
        {
            int aux;
            aux = a[i];
            a[i] = a[j];
            a[j] = aux;
        }
        private static int ran_int(int a, int b)
        {
            if(b<a || a<0 || b<0)
            {
                Console.WriteLine("Parámetros inválidos.");
                return 0;
            }
            return a + (rand.Next(b - a +1));
        }
        public static int[] randomUno(int n)
        {
            int i,x =0, k;
            int[] a = new int[n];
            for(i=0; i<n; i++)
            {
                Boolean seguirBuscando = true;
                while (seguirBuscando)
                {
                    x = ran_int(0, n-1);
                    seguirBuscando = false;
                    for(k=0; k<i && !seguirBuscando; k++)
                    {
                        if (x==a[k])
                        {
                            seguirBuscando = true;
                        }
                    }
                }
                a[i]=x;
            }
            return a;
        }
        public static int[] randomDos(int n)
        {
            int i,x;
            int[]a = new int[n];
            Boolean[] used = new Boolean[n];
            for(i=0; i<n; i++)
            {
                used[i] = false;
            }
            for(i=0; i<n; i++)
            {
                x = ran_int(0, n-1);
                while (used[x])
                {
                    x = ran_int(0, n-1);
                    a[i] = x;
                    used[x] = true;
                }
            }
            return a;
        }
        public static int[] randomTres(int n)
        {
            int i;
            int[] a = new int[n];
            for (i=0; i<n; i++)
            {
                a[i] = i;
            }
            for (i=1; i<n; i++)
            {
                swap(a,i,ran_int(0,i-1));
            }
            return a;
        }
    }
}*/