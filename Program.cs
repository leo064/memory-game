using System;
using System.Collections.Generic;
namespace test
{
    class Program
    {
        public static void Main()
        {
            string[] showArray = {"?", "?", "?", "?", "?", "?",
                         "?", "?", "?", "?", "?", "?"};
            string[] cleanArray = {"A", "A", "B", "B", "C", "C", "D", "D", "E", "E", "F", "F"};
            string[] shuffleArray = RandomizeArray(cleanArray);
            string[] selections = new string[2];  //array que armazena as cartas selecionadas
            string[] selectionsNdx = new string[2]; //array que armazena o índice das cartas selecionadas
            bool running = true;
            int count = -1;
            int score = 0;
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
                Console.WriteLine("\nLength: "+selections.Length);
                Console.WriteLine("Count: "+count);
                Console.WriteLine("Pares encontrados: "+score);
                Console.WriteLine("\nQual carta deseja virar? (0-11)");
                int sideCard = int.Parse(Console.ReadLine());
                
                //carta selecionada, então adiciona +1 no contador:
                count++;
                selections[count] = shuffleArray[sideCard];
                selectionsNdx[count] = sideCard.ToString();
                score = VerifyPairs(count, selections, selectionsNdx, score);

                showArray = ChangeIndex(sideCard, showArray, shuffleArray);
                if(count == 1){
                //a partir do momento que a segunda carta for selecionada, array e count resetam\\
                    selections = new string[2];
                    selectionsNdx = new string[2];
                    count = -1;
                }
                Console.Write(showArray+ "\n");
            }
        }
        static string[] ChangeIndex(int n, string[] show, string[] sArray){
            // Altera o array de visualização mostrando a carta virada no lugar da [?]. \\
            Console.Clear();
            if(show[n] == "?"){
                show[n] = sArray[n];
            }
                    //ou ...
            else{   //desvira a carta caso seja selecionada uma carta já virada.
                show[n] = "?";
            }
            
            return show;
        }
        static string[] RandomizeArray(string[] array){
            /*
            // Randomiza um vetor usando o "Fisher-yates algorithm :" \\
            Basicamente eu gero um número randômico de 0 a n. Esse número
            vai representar o índice que eu vou alterar para randomizar os elementos
            de um vetor.
            Por fim faço um processo de troca de lugares entre a posição randomizada com 
            a posição atual do meu vetor e... voilá
            */
            Random rnd = new Random();
            int n = array.Length;
            while(n > 0){
                n--;
                int k = rnd.Next(0, n);
                string aux = array[n];
                array[n] = array[k];
                array[k] = aux;
            }
            return array;
        }
        static int VerifyPairs(int c, string[] slc, string[] slcNdx, int sc){
            /* 
            // Soma +1 ao score do jogador caso ele acerte os pares de números. \\
            slc[0] == primeira carta selecionada.
            slc[1] == segunda carta selecionada.
            */
            if(c == 1){
                if(slcNdx[0] != slcNdx[1]){ //só habilita a verificação se os indices forem diferentes.
                    if (slc[0] == slc[1])
                        sc++;
                }
            }
            return sc;
        }
   }
}