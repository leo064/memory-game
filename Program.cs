using System;
using System.Collections.Generic;
namespace test
{
    class Program
    {
        public static void Main()
        {
            string[] showArray = { "?", "?", "?", "?", "?", "?", "?", "?", "?", "?", "?", "?"};
            string[] cleanArray = {"A", "A", "B", "B", "C", "C", "D", "D", "E", "E", "F", "F"};
            string[] shuffleArray = RandomizeArray(cleanArray);

            string[] selections = new string[3];  //array que armazena as cartas selecionadas
            int[] selectionsNdx = new int[3]; //array que armazena o índice das cartas selecionadas
            List<int> correctNdx = new List<int>(); //list que armazena o índice de pares acertados.
            string lastCard;
            int lastCardNdx;

            int totalOfPairs = (cleanArray.Length)/2;
            int count = -1;
            int score = 0;
            while (score < totalOfPairs){
                Console.Clear();
                //This write is just for test.
                //Console.Write("\n # "+shuffleArray[0]+" # "+shuffleArray[1]+" # "+shuffleArray[2]+
                //             "\n # "+shuffleArray[3]+" # "+shuffleArray[4]+" # "+shuffleArray[5]+
                //             "\n # "+shuffleArray[6]+" # "+shuffleArray[7]+" # "+shuffleArray[8]+
                //             "\n # "+shuffleArray[9]+" # "+shuffleArray[10]+" # "+shuffleArray[11]);
                Console.WriteLine();
                for(int j = 0; j<cleanArray.Length; j++){
                    //to show array and break lines
                    if(j%3==0)
                        Console.WriteLine();
                    Console.Write($" [{showArray[j]}] ");
                }
                Console.WriteLine("\n\nPares encontrados: "+score);
                Console.WriteLine($"Qual carta deseja virar? (0-{cleanArray.Length-1})");
                int sideCard = int.Parse(Console.ReadLine());
                while(correctNdx.Contains(sideCard)){
                    Console.WriteLine("Essa carta já foi retirada do game!");
                    Console.WriteLine($"\nQual carta deseja virar? (0-{cleanArray.Length-1})");
                    sideCard = int.Parse(Console.ReadLine());
                }

                //carta selecionada. Então adiciona +1 no contador de cartas:
                count++;
                selections[count] = shuffleArray[sideCard];
                selectionsNdx[count] = sideCard;
                showArray = ChangeIndex(sideCard, showArray, shuffleArray);
                
                //Verifica os pares selecionados :
                if(count == 2){

                    // Soma +1 ao score do jogador caso ele acerte os pares de números. \\
                    // selections[0] == primeira carta selecionada.
                    // selections[1] == segunda carta selecionada.
                    // selections[2] == terceira carta selecionada que ao resetar count, passa a ser
                    // a primeira carta.

                    //só habilita a verificação se os indices forem diferentes :
                    if(selectionsNdx[0] != selectionsNdx[1]){
                        if(selections[0] == selections[1]){
                            // Deixo os dois índices de visualização vazios, 
                            // simbolizando que as cartas foram retiradas.
                            showArray[selectionsNdx[0]] = " ";
                            showArray[selectionsNdx[1]] = " ";
                            // Adiciono os índices corretos digitados em uma lista para 
                            // que eu possa bloquear esses índices de serem acessados novamente.
                            correctNdx.Add(selectionsNdx[0]);
                            correctNdx.Add(selectionsNdx[1]);
                            score++;
                        } else {
                            showArray[selectionsNdx[0]] = "?";
                            showArray[selectionsNdx[1]] = "?";
                        }
                    }

                    // a partir do momento que a segunda carta for selecionada, selections e count resetam\\
                    // pego a última carta do vetor, que é a terceira carta selecionada
                    lastCard = selections[2];
                    lastCardNdx = selectionsNdx[2];
                    // reseto selections e selectionsNdx
                    selections = new string[3];
                    selectionsNdx = new int[3];
                    // atribuo a primeira carta do novo vetor, a terceira carta selecionada anteriormente.
                    selectionsNdx[0] = lastCardNdx;
                    selections[0] = lastCard;
                    // reseto count
                    count = 0;
                }

                Console.Clear();
                Console.Write(showArray+ "\n");
            }
            Console.Clear();
            Console.WriteLine("Parabéns! você achou os "+totalOfPairs+" pares do jogo da memória e sagrou-se vitorioso!");
        }
        static string[] ChangeIndex(int n, string[] show, string[] sArray){
            // Altera o array de visualização mostrando a carta virada no lugar da [?]. \\
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
   }
}