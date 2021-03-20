using System;
using System.Collections.Generic;
namespace Complejidad.TP4
{
    public class Ejercicio4
    {
        private List<string>[] arreglo = new List<string>[23];
        public Ejercicio4()
        {
            for (int i = 0; i < arreglo.Length-1; i++)
            {
                arreglo[i] = new List<string>();
            }
        }
        public int getHashEntry(string user, string password)
        {
            int hash = 5381;
            foreach (char c in user)
            {
                hash = (hash * 7) + (int) c;
            }
            foreach (char c in password)
            {
                hash = (hash * 7) + (int) c;
            }
            return hash%23;
        }
        public void guardarClave(string user,string password)
        {
            if(!verificarClave(user,password))
            {
                arreglo[getHashEntry(user,password)].Add(user);
            }
        }
        public bool verificarClave(string user, string password)
        {
            int clave = getHashEntry(user,password);
            foreach (string u in arreglo[clave])
            {
                if(u == user)
                {
                    return true;
                }
            }
            return false;
        }
    }
}