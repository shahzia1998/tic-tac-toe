using System;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {

        static int option; 
        static int player = 1;
        static int chance;
        static int win = 0;
        static int flag;
        static char ch;
        static char[] cross = { 'X', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static void Main(string[] args)
        {
            do
            {
                do
                {
                    //intro
                    Console.WriteLine("-----X and O GAME----- (PLAYER 1-X AND PLAYER 2-O)\n");
                    Console.WriteLine("RULES: enter the number of space(1-9) where you like to mark\n\n ");

                    //display board
                    board();

                    
                    if (player % 2 == 0)
                    {
                        Console.WriteLine("\n player 2's chance to play-enter the space number(1-9):");
                        chance = 2;
                        player++;
                    }
                    else
                    {
                        Console.WriteLine("\n player 1's chance to play-enter the space number(1-9): ");
                        chance = 1;
                        player++;
                    }

                    //option contains the space number that need to be marked
                    option = int.Parse(Console.ReadLine());

                    //marking the space
                    if (cross[option] != 'X' && cross[option] != 'O')
                    {
                        if (chance == 1)
                        {
                            cross[option] = 'X';
                        }
                        else
                        {
                            cross[option] = 'O';
                        }
                        win = check();
                    }
                    else
                    {
                        Console.WriteLine("\n this space is already marked:PLEASE TRY ANOTHER SPACE \n");
                        Thread.Sleep(2000);
                        player--;
                    }

                    
                    Console.Clear();
                } while (win != 1 && win != -1);

                //checking for victory/draw
                if (win == 1)
                {
                    if (chance == 2)
                    {
                        Console.WriteLine("\n \n PLAYER 2 WON!!");
                    }
                    else if (chance == 1)
                    {
                        Console.WriteLine("\n \n PLAYER 1 WON!!");
                    }
                }
                else if (win == -1)
                {
                    Console.WriteLine("\n \n IT'S A DRAW!!");
                }


                Console.WriteLine("\n \n do you want to play one more match(y/n):");
                ch = char.Parse(Console.ReadLine());
                Console.Clear();
            } while (ch == 'y');
        }

        public static void board() 
        {
            Console.WriteLine("      _____ _______ _______ ");
            Console.WriteLine("     |     |       |       |");
            Console.WriteLine("     | {0}   |  {1}    |  {2}    |",cross[1],cross[2],cross[3]);
            Console.WriteLine("     |_____|_______|_______|");
            Console.WriteLine("     |     |       |       |");
            Console.WriteLine("     | {0}   |  {1}    |  {2}    |",cross[4],cross[5],cross[6]);
            Console.WriteLine("     |_____|_______|_______|");
            Console.WriteLine("     |     |       |       |");
            Console.WriteLine("     | {0}   |  {1}    |  {2}    |",cross[7],cross[8],cross[9]);
            Console.WriteLine("     |_____|_______|_______|");
        }
        public static int check()
        {
            //horizontal
            flag = 0;
            if(cross[1]==cross[2]&&cross[2]==cross[3])
            {
                flag = 1;
            }
            else if(cross[4] == cross[5] && cross[5] == cross[6])
            {
                flag = 1;
            }
            else if(cross[7] == cross[8] && cross[8] == cross[9])
            {
                flag = 1;
            }
            //vertical
            else if (cross[1] == cross[4] && cross[4] == cross[7])
            {
                flag = 1;
            }
            else if (cross[2] == cross[5] && cross[5] == cross[8])
            {
                flag = 1;
            }
            else if (cross[3] == cross[6] && cross[6] == cross[9])
            {
                flag = 1;
            }
            //diagonal
            if (cross[1] == cross[5] && cross[5] == cross[9])
            {
                flag = 1;
            }
            else if (cross[3] == cross[5] && cross[5] == cross[7])
            {
                flag = 1;
            }
            //no win-draw
            else if (cross[1] != '1' && cross[2] != '2' && cross[3] != '3' && cross[4] != '4' && cross[5] != '5' && cross[6] != '6' && cross[7] != '7' && cross[8] != '8' && cross[9] != '9')
            {
                flag = -1;
            }
            
            return flag;

        } 

    }
}
