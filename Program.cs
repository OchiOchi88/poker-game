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
            bool playing = true;
            while (playing)
            {
                int[] number = new int[5];
                int[] pair = new int[2];
                bool check = false;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{i + 1}つめの数字を入力してください。(1～13): ");
                    check = int.TryParse(Console.ReadLine(), out number[i]);
                    if (!check || number[i] > 13 || number[i] < 1)
                    {
                        Console.WriteLine("その入力は無効です");
                        i--;
                    }
                }
                int pairkind = 0;
                int pairrecord = 0;
                bool iscover = false;
                for (int i = 0; i < 4; i++)
                {
                    iscover = false;
                    for (int j = i + 1; j < 5; j++)
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
                for (int i = 0; i < 5; i++)
                {
                    switch (number[i])
                    {
                        case 1:
                            Console.Write("A ");
                            break;
                        case 11:
                            Console.Write("J ");
                            break;
                        case 12:
                            Console.Write("Q ");
                            break;
                        case 13:
                            Console.Write("K ");
                            break;
                        default:
                            Console.Write(number[i] + " ");
                            break;
                    }

                }
                Console.WriteLine("");
                switch (pair[0])
                {
                    case 0:
                        int minnumber = 15;
                        int straightCard = 0;
                        bool ace = false;
                        bool royal = false;
                        for (int i = 0; i < 5; i++)
                        {
                            if (minnumber >= number[i])
                            {
                                minnumber = number[i];
                            }
                            if (minnumber == 1)
                            {
                                ace = true;
                            }
                        }
                        int straight = minnumber;
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (straight + 1 == number[j])
                                {
                                    straight = number[j];
                                    straightCard++;
                                }else if(ace == true && number[j] == 10)
                                {
                                    ace = false;
                                    royal = true;
                                    straight = number[j];
                                    straightCard++;
                                }
                            }
                        }
                        if (straightCard == 4)
                        {
                            if (royal)
                            {
                                Console.WriteLine("ロイヤルストレート！！！ヤバすぎ！！！");
                            }
                            else
                            {
                                Console.WriteLine("ストレート！！！スゴイ！！");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ノーペア...");
                        }
                        break;
                    case 1:
                        switch (pair[1])
                        {
                            case 1:
                            Console.WriteLine("ツーペア！");
                                break;
                            case 2:
                                Console.WriteLine("フルハウス！！！");
                                break;
                            default :
                        Console.WriteLine("ワンペア！！");
                                break;
                        }
                        break;
                    case 2:
                        if (pair[1] >= 1)
                        {
                            Console.WriteLine("フルハウス！！！");
                        }
                        else
                        {
                            Console.WriteLine("スリーカード！！スゴい！！");
                        }
                        break;
                    case 3:
                        Console.WriteLine("フォーオブカインド！！ヤバすぎ！！！");
                        break;
                }
                Console.ReadLine();
                Console.WriteLine("もう一度遊びますか？(yで続行、それ以外で退出)");
                if(Console.ReadLine() != "y")
                {
                    playing = false;
                }
            }
        }
    }
}
