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
            int[] pair = new int[2];
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
            int pairkind = 0;
            int pairrecord = 0;
            bool iscover = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    if (number[i] == number[j])
                    {
                        if (i == 0)
                        {
                            pair[pairkind]++;
                            pairrecord = number[i];
                        }
                        else
                        {
                            for (int k = i; k > 0; k--)
                            {
                                if (number[i] == number[k - 1])
                                {
                                    iscover = true;
                                }
                            }
                            if (iscover == false)
                            {
                                if (pair[pairkind] >= 1 && pairrecord != number[i])
                                {
                                    pairkind++;
                                }
                                pair[pairkind]++;
                                pairrecord = number[i];
                            }
                        }
                    }
                }
            }
            Console.WriteLine("あなたのそろえた役は...!");
            Console.ReadLine();
            for (int i = 0; i < 4; i++) {
                Console.Write(number[i] + " ");
            }
            Console.WriteLine("");
            switch(pair[0])
            {
                case 0:
                    Console.WriteLine("ノーペア...");
                    break;
                case 1:
                    if (pair[1] == 1)
                    {
                        Console.WriteLine("ツーペア！");
                    }
                    else
                    {
                        Console.WriteLine("ワンペア！！");
                    }
                    break;
                case 2:
                    Console.WriteLine("スリーカード！！スゴい！！");
                    break;
                case 3:
                    Console.WriteLine("フォーカード！！ヤバすぎ！！！");
                    break;
            }

            Console.ReadLine();
        }
    }
}
