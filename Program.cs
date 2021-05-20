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
            string[] numsArray = new string[12];
            Random rnd = new Random();
            for(int i=0; i<12; i++){
                numsArray[i] = rnd.Next(1,7).ToString();
            }
            bool running = true;
            
            while (running){
                Console.Clear();
                Console.Write(" # "+numsArray[0] +" # "+numsArray[1]+" # "+ numsArray[2] +
                            "\n # "+ numsArray[3]+" # "+numsArray[4]+" # "+numsArray[5]+
                            "\n # "+ numsArray[6]+" # "+numsArray[7]+" # "+numsArray[8]+
                            "\n # "+ numsArray[9]+" # "+numsArray[10]+" # "+numsArray[11]);
                for(int j = 0; j<12; j++){
                    if(j%3==0)
                        Console.WriteLine();
                    Console.Write($" [{showArray[j]}] ");
                }
                Console.WriteLine("\nQual carta deseja virar? (0-11)");
                int sideCard = int.Parse(Console.ReadLine());
                showArray = AlteraIndice(sideCard, showArray, numsArray);
                
                Console.Write(showArray+ "\n");
            }
        }
        static string[] AlteraIndice(int n, string[] show, string[] nums){
            Console.Clear();
            show[n] = nums[n];
            return show;
        }

   }
}