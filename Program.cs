﻿using System;
using System.Collections.Generic;
namespace test
{
    class Program
    {
        public static void Main()
        {
            string[] showArray = {"?", "?", "?", "?", "?", "?",
                         "?", "?", "?", "?", "?", "?"};
            string[] cleanArray = {"1", "1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6"};
            string[] shuffleArray = RandomizeArray(cleanArray);
            
            bool running = true;
            while (running){
                Console.Clear();
                //This write is just for test.
                Console.Write(" # "+shuffleArray[0] +" # "+shuffleArray[1]+" # "+shuffleArray[2] +
                            "\n # "+ shuffleArray[3]+" # "+shuffleArray[4]+" # "+shuffleArray[5]+
                            "\n # "+ shuffleArray[6]+" # "+shuffleArray[7]+" # "+shuffleArray[8]+
                            "\n # "+ shuffleArray[9]+" # "+shuffleArray[10]+" # "+shuffleArray[11]);
                for(int j = 0; j<12; j++){
                    //to show array and break lines
                    if(j%3==0)
                        Console.WriteLine();
                    Console.Write($" [{showArray[j]}] ");
                }
                Console.WriteLine("\nQual carta deseja virar? (0-11)");
                int sideCard = int.Parse(Console.ReadLine());
                showArray = ChangeIndex(sideCard, showArray, shuffleArray);
                
                Console.Write(showArray+ "\n");
            }
        }
        static string[] ChangeIndex(int n, string[] show, string[] sArray){
            Console.Clear();
            show[n] = sArray[n];
            return show;
        }

        static string[] RandomizeArray(string[] array){
            /*
            using the "Fisher-yates algorithm :"
            Basicamente eu gero um número randômico de 0 a n--. Esse número
            vai representar o índice que eu vou alterar para randomizar os elementos
            de um vetor.
            Por fim faço um processo de troca de lugares entre a posição randomizada com 
            a posição atual do meu vetor e... voilá
            */
            Random rnd = new Random();
            int n = array.Length;
            while(n > 0){
                int k = rnd.Next(0, n--);
                string aux = array[n];
                array[n] = array[k];
                array[k] = aux;
            }
            return array;
        }
   }
}