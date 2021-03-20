using System;
using System.Collections.Generic;
namespace Complejidad.TP4
{
    public class TablaHash
    {
        private List<Empleado>[] arreglo;
        public TablaHash(int tamaño)
        {
            arreglo = new List<Empleado>[tamaño];
            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = new List<Empleado>();
            }
        }
        private int hash(int dni)
        {
            return dni%11;
        }
        public void guardarEmpleado(int dni, Empleado empleado)
        {
            int clave = hash(dni);
            bool existe = false;
            foreach(Empleado x in arreglo[clave])
            {
                if(x.getDni() == dni)
                {
                    existe = true;
                    break;
                }
            }
            if(!existe)
            {
                arreglo[clave].Add(empleado);
            }
        }
        public Empleado accederEmpleado(int dni)
        {
            foreach (Empleado x in arreglo[hash(dni)])
            {
                if(x.getDni() == dni)
                {
                    return x;
                }
            }
            return null;
        }
    }
    public class Empleado
    {
        private int numero;
        private int dni;
        private string nombre;
        public Empleado(int numero, string nombre, int dni)
        {
            this.numero = numero;
            this.nombre = nombre;
            this.dni = dni;
        }
        public int getNumero()
        {
            return numero;
        }
        public string getNombre()
        {
            return nombre;
        }
        public int getDni()
        {
            return dni;
        }
    }
}