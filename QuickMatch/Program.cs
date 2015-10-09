using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMatch
{
    class Program
    {
        static int[,] WinBoard = new int[13,4];
        public Program()
        {
            string msg1 = "QuickMatch 1.0";
            string msg2 = "Developed by Arjun & Prianka";
            string msg3 = "Project";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg1.Length / 2) + "}", msg1);
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + 17 / 2) + "}", "================");
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg2.Length / 2) + "}", msg2);
            Console.WriteLine();
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg3.Length / 2) + "}", msg3);
            Console.WriteLine("\n");
            Console.WriteLine("\nGUIDELINES: ");
            Console.WriteLine("1. Each player will be given 5 cards initially at random from the deck.");
            Console.WriteLine("2. A player can have only 5 cards maximum with him/her. If exceeds, he/she has to discard any one.");
            Console.WriteLine("3. Winner is the one who has all 5 cards of same suite.");
            Console.WriteLine("4. Each player can either take a card from the deck or previously thrown card by the opponent.");
            Console.WriteLine("\n");
            Console.WriteLine("Let's start!");
            Console.WriteLine("\n");
            int i, j, Numb;
            Numb = 0;
            for (i = 0; i < 13; i++)        //Loop for assigning winning table values
            {
                for (j = 0; j < 4; j++)
                {
                    WinBoard[i, j] = Numb;
                    Numb++;
                }
            }
        }
        public static string GetCardName(int ind)
        {
            List<string> CardNames = new List<string>();
            CardNames.Add("The Ace of Hearts");
            CardNames.Add("The Ace of Clubs");
            CardNames.Add("The Ace of Diamonds");
            CardNames.Add("The Ace of Spades");
            CardNames.Add("The Two of Hearts");
            CardNames.Add("The Two of Clubs");
            CardNames.Add("The Two of Diamonds");
            CardNames.Add("The Two of Spades");
            CardNames.Add("The Three of Hearts");
            CardNames.Add("The Three of Clubs");
            CardNames.Add("The Three of Diamonds");
            CardNames.Add("The Three of Spades");
            CardNames.Add("The Four of Hearts");
            CardNames.Add("The Four of Clubs");
            CardNames.Add("The Four of Diamonds");
            CardNames.Add("The Four of Spades");
            CardNames.Add("The Five of Hearts");
            CardNames.Add("The Five of Clubs");
            CardNames.Add("The Five of Diamonds");
            CardNames.Add("The Five of Spades");
            CardNames.Add("The Six of Hearts");
            CardNames.Add("The Six of Clubs");
            CardNames.Add("The Six of Diamonds");
            CardNames.Add("The Six of Spades");
            CardNames.Add("The Seven of Hearts");
            CardNames.Add("The Seven of Clubs");
            CardNames.Add("The Seven of Diamonds");
            CardNames.Add("The Seven of Spades");
            CardNames.Add("The Eight of Hearts");
            CardNames.Add("The Eight of Clubs");
            CardNames.Add("The Eight of Diamonds");
            CardNames.Add("The Eight of Spades");
            CardNames.Add("The Nine of Hearts");
            CardNames.Add("The Nine of Clubs");
            CardNames.Add("The Nine of Diamonds");
            CardNames.Add("The Nine of Spades");
            CardNames.Add("The Ten of Hearts");
            CardNames.Add("The Ten of Clubs");
            CardNames.Add("The Ten of Diamonds");
            CardNames.Add("The Ten of Spades");
            CardNames.Add("The Jack of Hearts");
            CardNames.Add("The Jack of Clubs");
            CardNames.Add("The Jack of Diamonds");
            CardNames.Add("The Jack of Spades");
            CardNames.Add("The Queen of Hearts");
            CardNames.Add("The Queen of Clubs");
            CardNames.Add("The Queen of Diamonds");
            CardNames.Add("The Queen of Spades");
            CardNames.Add("The King of Hearts");
            CardNames.Add("The King of Clubs");
            CardNames.Add("The King of Diamonds");
            CardNames.Add("The King of Spades");
            return CardNames[ind];
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            int N, i, j, Temp = 0, intChoice = 0, Discard = 0, mark = 10;
            char Choice;
            string[] PlayerName = new string[4];
            do
            {
                Console.Write("Enter number of players (2-4): ");
                N = Convert.ToInt32(Console.ReadLine());
            } while (!(N >= 2 && N <= 4));
            for (i = 0; i < N; i++)
            {
                Console.Write("Enter Player {0} Name: ", i + 1);
                PlayerName[i] = Console.ReadLine();
            }
            int[,] Player = new int[N, 5];
            List<int> Deck = new List<int>();
            for (i = 0; i <= 51; i++)
            {
                Deck.Add(i);
            }
            Random ran = new Random();
            List<int> Selected = new List<int>();
            for (i = 0; i < N * 5; i++)
            {
                int RandomNumber = ran.Next(0, Deck.Count) - 1;
                Selected.Add(Deck[RandomNumber]);
                Deck.RemoveAt(RandomNumber);
            }
            int LoopCount = 0;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    Player[i, j] = Selected[LoopCount];
                    LoopCount++;
                }
            }
            int Turn = 1;
            int PlNum = 0;
            Console.WriteLine();
            do
            {
                //Console.WriteLine("[[[[{0}]]]]",GetCardName(Temp));
                Console.WriteLine(PlayerName[PlNum] + "'s Turn");
                for (j = 0; j < 5; j++)
                {
                    Console.WriteLine(GetCardName(Player[PlNum, j]));
                }
                if (Turn == 1)
                {
                    do
                    {
                        Console.Write("\nPress D to draw  card from Pile: ");
                        Choice = Convert.ToChar(Console.ReadLine());
                    } while (!(Choice != 'D' || Choice != 'd'));
                }
                else
                {
                    do
                    {
                        Console.Write("\nPress D to draw from Pile or T to take the card discarded by previous person: ");
                        Choice = Convert.ToChar(Console.ReadLine());
                    } while (!(Choice != 'D' || Choice != 'd' || Choice != 'T' || Choice != 't'));
                }
                if (Choice == 'D' || Choice == 'd')
                {
                    Temp = Deck[0];
                    Deck.RemoveAt(0);
                    for (j = 0; j < 5; j++)
                    {
                        Console.WriteLine("{0}. {1}", j + 1, GetCardName(Player[PlNum, j]));
                    }
                    Console.WriteLine("6. {0}", GetCardName(Temp));
                }
                else if (Choice == 'T' || Choice == 't')
                {
                    for (j = 0; j < 5; j++)
                    {
                        Console.WriteLine("{0}. {1}", j + 1, GetCardName(Player[PlNum, j]));
                    }
                    Temp = Discard;
                    Console.WriteLine("6. {0}",GetCardName(Discard));
                }
                do
                {
                    Console.Write("\nSelect an option to discard: ");
                    intChoice = Convert.ToInt32(Console.ReadLine());
                } while (intChoice > 6);
                if (intChoice != 6)
                {
                    Deck.Add(Player[PlNum, intChoice - 1]);
                    Discard = Player[PlNum, intChoice - 1];
                    Player[PlNum, intChoice - 1] = Temp;
                }
                else if (intChoice == 6)
                {
                    Discard = Temp;
                }
                Console.WriteLine("The card discarded was: {0}", GetCardName(Discard));
                if (PlNum == N-1)
                {
                    PlNum = 0;
                    Turn++;
                }
                else
                {
                    PlNum++;
                    Turn++;
                }
                Turn++;
                int k, l;
                Console.WriteLine("\n");
                int times = 0;               //Added from raw algo win.cs
                int[,] TempArray = new int[N, 52];
                for (i = 0; i < N; i++)				//Making 1 and 0 array, a 2x52 two-dimension array
                {
                    for (j = 0; j < 5; j++)
                    {
                        for (k = 0; k < 4; k++)
                        {
                            for (l = 0; l < 13; l++)
                            {
                                if (Player[i, j] == WinBoard[l, k])
                                {
                                    TempArray[i, times] = 1;
                                }
                                else if (TempArray[i, times] != 1)
                                {
                                    TempArray[i, times] = 0;
                                }
                                times++;
                            }

                        }
                        times = 0;
                    }
                }
                int[] Winner = new int[N];
                times = 0;
                for (i = 0; i < N; i++)				//Counting the number of 1s and deciding the winner
                {
                    for (j = 0; j < 52; j++)
                    {
                        if (TempArray[i, j] == 1)
                        {
                            Winner[i] = ++times;
                        }
                        if (times != 5 && (j == 13 || j == 25 || j == 38 || j == 51))
                        {
                            times = 0;
                        }
                    }
                }
                for (i = 0; i < N; i++)				//Locating the winner
                {
                    if (Winner[i] == 5)
                    {
                        mark = i;
                        break;
                    }
                }
                if (mark != 10)
                {
                    break;
                }
            } while (true);
            Console.WriteLine("Well Played! Congratulations, {0}! You won!",PlayerName[mark]);
            Console.WriteLine("\nPress any key to exit the application...");
            Console.ReadLine();
        }
    }
}