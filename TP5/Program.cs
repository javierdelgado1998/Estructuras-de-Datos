using System;
using System.Collections;

namespace TP5
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(String[] args)
        { 
            foreach (int x in randomUno(5))
            {
                Console.Write(x+" ");
            }
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
                Console.WriteLine("Valor de iterador i actual "+i);
                Boolean seguirBuscando = true;
                while (seguirBuscando)
                {
                    x = ran_int(0, n-1);
                    Console.WriteLine("Valor de x actual "+x);
                    Console.ReadKey();
                    seguirBuscando = false;
                    for(k=0; k<i && !seguirBuscando; k++)
                    {
                        Console.WriteLine("Valor de iterador k actual "+k);
                        Console.ReadKey();
                        Console.WriteLine("{0} == {1}?",x,a[k]);
                        if (x==a[k])
                        {
                            Console.WriteLine("a == k, verdadero");
                            Console.ReadKey();
                            seguirBuscando = true;
                        }
                    }
                }
                a[i]=x;
                Console.WriteLine("se agrego {0} en la posicion {1} del array",x,i);
            }
            return a;
        }
        public static int[] randomDos(int n)
        {
            int i,x;
            int[]a = new int[n];
            Boolean[] used = new Boolean[n];
            for (i = 0; i < n; i++)
            {
                used[i] = false;
            } 
            for (i = 0; i < n; i++)
            {
                x = ran_int(0, n - 1);
                Console.WriteLine("Valor de x: {0} ",x);
                Console.ReadKey();
                Console.WriteLine("{0} el estado del array de boleans en la posicion {1}",used[x],x);
                Console.ReadKey();
                while (used[x])
                {
                    Console.WriteLine("Entre al while");
                    Console.ReadKey();
                    x = ran_int(0, n - 1);
                    Console.WriteLine("Valor de x: {0} ",x);
                    Console.WriteLine("Saliendo del while...");
                    Console.ReadKey();
                }
                a[i] = x;
                Console.WriteLine("valor {0} agregado en la posicion {1} del array de números",x,i);
                Console.ReadKey();
                used[x] = true;
                Console.WriteLine("Pasando a true la posicion {0} del array de boleans",x);

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
}
