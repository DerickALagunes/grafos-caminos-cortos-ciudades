using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FloydWarshallAlgorithm
{
    class FloydWarshallAlgo
    {

        public const int cst = 9999;

        private static void Print(int[,] distance, int verticesCount)
        {
            Console.WriteLine("Distancias mas cortas entre un par de vertices:");

            for (int i = 0; i < verticesCount; ++i)
            {
                for (int j = 0; j < verticesCount; ++j)
                {
                    if (distance[i, j] == cst)
                        Console.Write("cst".PadLeft(7));
                    else
                        Console.Write(distance[i, j].ToString().PadLeft(7)+",");
                }

                Console.WriteLine();
            }
        }

        public static void FloydWarshall(int[,] graph, int[,] pathS, int verticesCount)
        {
            int[,] distance = new int[verticesCount, verticesCount];
            int[,] path = new int[verticesCount, verticesCount];

            for (int i = 0; i < verticesCount; ++i)
                for (int j = 0; j < verticesCount; ++j)
                {
                    distance[i, j] = graph[i, j];
                    path[i, j] = pathS[i, j];
                }

            for (int k = 0; k < verticesCount; ++k)
            {
                for (int i = 0; i < verticesCount; ++i)
                {
                    for (int j = 0; j < verticesCount; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                        {
                            if (distance[i, j] != distance[i, k] + distance[k, j])
                            {
                                path[i, j] = k+1;
                            }
                            distance[i, j] = distance[i, k] + distance[k, j];
                        }
                    }
                }
            }

            Print(distance, verticesCount);
            Console.Write("----------------------------");
            Print(path, verticesCount);
        }
        static void Main(string[] args)
        {
            int[,] graph = {
                            {0,15,cst,cst,cst,cst,cst,cst,cst,3,cst,cst,7,2,5,cst,3,cst,cst,9,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,6,cst,3,3,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {15,0,cst,cst,cst,cst,cst,cst,cst,10,cst,cst,cst,15,cst,cst,cst,cst,cst,7,cst,cst,cst,12,cst,cst,cst,cst,cst,9,5,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,7,3,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,8,10,13,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,0,6,cst,6,cst,cst,6,cst,cst,cst,3,cst,3,cst,cst,7,cst,cst,cst,10,cst,cst,4,cst,cst,cst,cst,cst,cst,cst,cst,cst,7,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,4,0,cst,5,cst,10,8,cst,cst,cst,cst,cst,5,cst,cst,cst,5,cst,cst,14,cst,cst,7,cst,cst,cst,cst,cst,cst,cst,cst,cst,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,0,1,cst,cst,cst,cst,8,14,cst,cst,cst,cst,cst,cst,5,cst,cst,cst,7,cst,cst,8,5,16,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,4,1,0,cst,cst,cst,cst,cst,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,1,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,0,2,9,cst,cst,cst,cst,cst,cst,8,cst,cst,cst,10,cst,cst,cst,7,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,9,cst,cst,cst,2,0,7,cst,cst,cst,cst,cst,cst,6,cst,cst,cst,6,5,6,cst,cst,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,13,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,4,7,cst,cst,cst,cst,0,cst,cst,cst,4,cst,5,2,cst,8,cst,cst,cst,10,cst,cst,2,cst,cst,cst,cst,cst,cst,cst,5,cst,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {3,cst,cst,cst,cst,cst,cst,cst,8,0,cst,cst,5,cst,cst,6,5,cst,cst,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,7,cst,4,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,cst,cst,cst,cst,cst,5,cst,cst,cst,cst,cst,cst,cst,1,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,10,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,12,cst,cst,cst,cst,cst,cst,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,16,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {5,cst,6,cst,cst,cst,cst,cst,8,cst,cst,cst,0,cst,3,7,6,12,cst,cst,cst,11,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,1,cst,10,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {5,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,5,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,8,8,cst,cst,cst,cst,cst,cst,9,4,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {7,cst,2,5,cst,cst,cst,cst,cst,7,cst,cst,3,cst,0,cst,6,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,4,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {8,cst,cst,cst,cst,cst,cst,cst,2,6,cst,cst,4,cst,cst,0,8,cst,cst,cst,cst,cst,cst,cst,4,cst,cst,cst,cst,cst,cst,cst,9,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {4,cst,cst,cst,cst,cst,cst,cst,cst,5,cst,cst,20,cst,5,cst,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,3,4,2,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,11,7,cst,cst,cst,cst,cst,cst,20,cst,cst,cst,cst,cst,1,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,3,4,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,cst,cst,cst,cst,cst,5,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,12,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {8,9,cst,cst,cst,cst,cst,cst,cst,6,cst,cst,cst,12,cst,10,cst,cst,cst,0,cst,cst,cst,8,cst,cst,cst,cst,cst,15,6,cst,9,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,11,cst,cst,cst,cst,cst,cst,cst,cst,19,cst,cst,cst,10,11,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,5,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,7,cst,cst,cst,cst,cst,cst,15,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,7,cst,cst,16,0,cst,cst,cst,cst,cst,cst,15,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,5,cst,cst,cst,cst,cst,cst,15,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,10,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,8,cst,cst,cst,cst,7,8,16,cst,cst,cst,cst,cst,cst,14,cst,cst,cst,10,cst,cst,cst,0,13,cst,cst,cst,cst,10,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,4,8,cst,cst,cst,6,6,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,12,cst,cst,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,9,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,10,cst,cst,cst,cst,cst,13,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,15,cst,cst,0,8,14,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,12,15,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,8,cst,cst,cst,cst,5,cst,cst,cst,cst,cst,cst,cst,6,cst,cst,cst,cst,cst,cst,7,0,13,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,7,9,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,15,cst,cst,cst,cst,cst,18,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,22,cst,cst,cst,13,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,16,15,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,15,17,cst,14,cst,cst,cst,cst,0,14,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,15,cst,cst,cst,10,cst,cst,cst,cst,14,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {7,13,cst,cst,cst,cst,cst,cst,8,4,cst,cst,8,8,cst,9,cst,cst,cst,5,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,6,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,14,16,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,12,12,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,8,cst,cst,4,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,4,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,9,cst,9,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {8,cst,cst,cst,cst,cst,cst,cst,8,5,cst,cst,6,cst,4,cst,7,cst,cst,11,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,8,cst,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {2,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,2,cst,cst,12,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,4,cst,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,8,6,cst,2,cst,7,cst,cst,cst,cst,cst,cst,cst,cst,cst,1,cst,cst,cst,7,cst,cst,9,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,17,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,17,cst,cst,cst,cst,cst,20,15,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,16,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,18,0,cst,cst,cst,25,cst,17,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,20,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,20,22,29,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,22,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,18,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,23,0,20,14,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,10,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,14,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,22,20,0,23,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,16,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,19,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,25,29,14,18,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,6,cst,cst,cst,cst,cst,18,cst,cst,9,cst,cst,6,7,cst,13,cst,cst,cst,cst,cst,17,12,cst,cst,cst,cst,cst},
                            {cst,12,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,17,cst,cst,cst,cst,cst,5,cst,cst,cst,cst,cst,cst,0,9,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,10,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,5,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,4,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,10,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,4,cst,7,0,cst,cst,cst,cst,cst,cst,cst,cst,10,cst,cst,9,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,24,12,cst,cst,cst,cst,cst,cst,0,cst,cst,cst,cst,cst,cst,cst,cst,2,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,8,3},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,6,cst,cst,cst,cst,2,2,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,6,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,9,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,6,7,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,8,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,12,9,16,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,3,0,cst,cst,4,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,9,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,7,cst,0,11,6,cst,cst,cst,cst,cst,cst,11,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,13,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,15,cst,9,0,7,cst,15,cst,cst,cst,cst,10,cst,cst,cst,8,10,cst,12,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,13,7,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,2,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,cst,cst,cst,cst,4,3,cst,cst,3,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,24,cst,cst,15,cst,cst,cst,cst,cst,15,cst,cst,0,cst,cst,cst,14,cst,11,cst,cst,cst,cst,cst,11,12,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,25,23,11,cst,cst,cst,cst,cst,cst,2,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,3,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,14,cst,cst,cst,cst,cst,cst,8,7,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,11,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,1,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,6,cst,6,2,cst,6,cst,cst,cst,cst,cst,cst,cst,cst,3,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {1,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,1,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,1,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,8,cst,cst,11,cst,cst,cst,cst,cst,cst,cst,cst,5,cst,cst,cst,0,2,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,1,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,9,14,cst,cst,11,cst,cst,cst,9,0,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,2,cst,cst,cst,cst,cst,cst,0,3,cst,cst,cst,cst,3,2,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,4,cst,cst,cst,cst,cst,cst,2,0,5,cst,cst,cst,cst,4,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,4,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,cst,cst,cst,cst,cst,3,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,3,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,3,cst,5,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,7,5,cst,cst,cst,cst,cst,cst,cst,cst,cst,1,0,cst,cst,cst,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,0,cst,cst,1,1,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,6,cst,cst,11,cst,cst,cst,cst,8,2,cst,cst,4,cst,cst,0,4,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,11,cst,cst,cst,cst,3,cst,cst,cst,7,cst,cst,10,cst,cst,cst,cst,cst,3,cst,cst,cst,cst,cst,5,0,cst,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,1,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,7,cst,cst,1,cst,cst,0,cst,cst,cst,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,1,cst,cst,cst,0,cst,cst,2},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,16,cst,cst,cst,cst,cst,cst,cst,0,16,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,18,17,19,25,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,4,0,cst},
                            {cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,4,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,cst,2,cst,cst,0}
                           };

            int[,] pathS = {
                            {0,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,0,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,0,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,0,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,0,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,0,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,0,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,0,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,0,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,0,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,0,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,0,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,0,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,0,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,0,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,0,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,0,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,0,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,0,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,0,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,0,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,0,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,0,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,0,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,0,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,0,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,0,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,0,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,0,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,0,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,0,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,0,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,0,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,0,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,0,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,0,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,0,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,0,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,0,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,0,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,0,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,0,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,0,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,0,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,0,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,0,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,0,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,0,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,0,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,0,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,0,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,0,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,0,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,0,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,0,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,0,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,0,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,0,59,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,0,60,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,0,61,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,0,62,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,0,63,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,0,64,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,0,65,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,0,66,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,0,67,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,0,68,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,0,69,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,0,70,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,0,71,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,0,72},
{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,0}
                            };

            FloydWarshall(graph,pathS, 72);
            
            Console.ReadKey();

        }
    }
}