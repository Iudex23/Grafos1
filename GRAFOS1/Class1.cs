using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRAFOS1
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
        }
    }
}
