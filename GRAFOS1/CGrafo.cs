using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_De_Dijkstra
{
    class CGrafo
    {
        private int[,] mAdyacencia;
        private int[] indegree;
        private int nodos;

        public CGrafo(int pNodos)
        {
            nodos = pNodos;

            //Intanciamos matriz de adyacencia
            mAdyacencia = new int[nodos, nodos];

            //Intanciamos areglo de indegree

            indegree = new int[nodos];
        }
        public void AdicionarArista(int pNodoInicio, int pNodoFinal)
        {
            mAdyacencia[pNodoInicio, pNodoFinal] = 1;
        }
        public void AdicionarArista(int pNodoInicio, int pNodoFinal, int pPeso)
        {
            mAdyacencia[pNodoInicio, pNodoFinal] = pPeso;
        }
        public void MuestraAdyacencia()
        {
            int n = 0;
            int m = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (n = 0; n < nodos; n++)
                Console.Write("\t{0}", n);

            Console.WriteLine();

            for (n = 0; n < nodos; n++)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("\t{0}", mAdyacencia[n, m]);
            }
            Console.WriteLine();
        }
        public int ObtenAdyacencia(int pFila, int pColumna)
        {
            return mAdyacencia[pFila, pColumna];
        }
        public void CalcularIndegree()
        {
            int n = 0;
            int m = 0;

            for (n = 0; n < nodos; n++)
            {
                for (m = 0; n < nodos; m++)
                {
                    if (mAdyacencia[m, n] == 1)
                        indegree[n]++;
                }
            }
        }
        public void MostrarIndegree()
        {
            int n = 0;
            Console.ForegroundColor = ConsoleColor.White;
            for (n = 0; n < nodos; n++)
                Console.WriteLine("Nodo:{0},{1}", n, indegree[n]);
        }
        public int EncuentraI0()
        {
            bool encontrado = false;
            int n = 0;

            for (n = 0; n < nodos; n++)
            {
                if (indegree[n] == 0)
                {
                    encontrado = true;
                    break;
                }
            }
            if (encontrado)
                return n;
            else return -1;//Codigo que indica que no se ha encontrado 
        }
        public void DecrementaIndegree(int pNodo)
        {
            indegree[pNodo] = -1;

            int n = 0;

            for (n = 0; n < nodos; n++)
            {
                if (mAdyacencia[pNodo, n] == 1)
                    indegree[n]--;
            }
        }
    }
}
