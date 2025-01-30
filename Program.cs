using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] number = new int[4];
            bool check = false;
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i+1}つめの数字を入力してください。(1～4): ");
                check = int.TryParse(Console.ReadLine(), out number[i]);
                if (!check || number[i]>4 || number[i]<1)
                {
                    Console.WriteLine("その入力は無効です");
                    i--;
                }
            }
        }
    }
}
