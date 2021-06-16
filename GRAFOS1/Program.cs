using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_De_Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            int inicio = 0;
            int final = 0;
            int distancia = 0;
            int n = 0;
            int cantNodos = 7;
            string dato = "";
            int actual = 0;
            int columna = 0;

            //Creamos el grafo
            CGrafo miGrafo = new CGrafo(cantNodos);

            miGrafo.AdicionarArista(0, 1, 2);
            miGrafo.AdicionarArista(0, 3, 1);
            miGrafo.AdicionarArista(1, 3, 3);
            miGrafo.AdicionarArista(1, 4, 10);
            miGrafo.AdicionarArista(2, 0, 4);
            miGrafo.AdicionarArista(2, 5, 5);
            miGrafo.AdicionarArista(3, 2, 2);
            miGrafo.AdicionarArista(3, 4, 2);
            miGrafo.AdicionarArista(3, 5, 8);
            miGrafo.AdicionarArista(3, 6, 4);
            miGrafo.AdicionarArista(4, 6, 6);
            miGrafo.AdicionarArista(6, 5, 1);

            miGrafo.MuestraAdyacencia();

            Console.WriteLine("Dame el indice del nodo inicio");
            dato = Console.ReadLine();
            inicio = Convert.ToInt32(dato);

            Console.WriteLine("Dame el indice del nodo final");
            dato = Console.ReadLine();
            final = Convert.ToInt32(dato);

            //Creamos la tabla de enteros por 3 columnas
            int[,] tabla  = new int[cantNodos, 3];

            //Inicializar tabla
            for (n = 0; n < cantNodos; n++)
            {
                tabla[n, 0] = 0;
                tabla[n, 1] = int.MaxValue;
                tabla[n, 2] = 0;
            }

            tabla[inicio, 1] = 0;
            MostrarTabla(tabla);

            //Inicio del algoritmo Dijkstra
            actual = inicio;

            do
            {
                //Se marca el nodo como visitado
                tabla[actual, 0] = 1;
    
                for (columna = 0; columna < cantNodos; columna++)
                      {

                    //1-Buscamos a quien se dirige
                     if (miGrafo.ObtenAdyacencia(actual, columna) != 0)
                        {
                        //Se calcula la distancia
                        distancia = miGrafo.ObtenAdyacencia(actual, columna) + tabla[actual, 1];

                        //Colocamos las distancias
                        if (distancia < tabla[columna, 1])
                        {
                            tabla[columna, 1] = distancia;

                            //Tomamos la informacion del padre

                            tabla[columna, 2] = actual;
                        }
                    }
                }

                //El nuevo nodo actual es el nodo que no hemos visitado.
                int indiceMenor = -1;
                int distanciaMenor = int.MaxValue;

                for (int x = 0; x < cantNodos; x++)
                {
                    if (tabla[x, 1] < distanciaMenor && tabla[x, 0] == 0)
                    {
                        indiceMenor = x;
                        distanciaMenor = tabla[x, 1];
                    }
                }
                actual = indiceMenor;
            } while (actual != -1);
            MostrarTabla(tabla);

            //Obtenemos la ruta.
            List<int> ruta = new List<int>();
            int nodo = final;

            while (nodo != inicio)
            {
                ruta.Add(nodo);
                nodo = tabla[nodo, 2];
            }
            ruta.Add(inicio);
            ruta.Reverse();

            foreach (int posicion in ruta)
            {
                Console.Write("{0}-->", posicion);
            }

            Console.WriteLine();

            Console.Read();

        }
        public static void MostrarTabla(int[,] Tabla)
        {

            for (int n = 0; n < Tabla.GetLength(0); n++)
            {
                Console.WriteLine("{0}--> {1}\t{2}\t{3}", n, Tabla[n, 0], Tabla[n, 1], Tabla[n, 2]);
            }

            Console.WriteLine("----------");
           
        }
    }
}
