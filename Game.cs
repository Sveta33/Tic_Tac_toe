using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_toe
{
     class Game
    {
        static char[] cell = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };//field cells
        static int player = 1;//choose a player. default=1
        static int mark;//allows you to mark 'X' or 'O' on the field
        static int result=0;//checks who won: if -1, then a draw;
                            //if 0, the game is on;
                            //if 1,someone won;
        public Game()
        //Will run until all cells are filled, или кто-то не выиграет
        {
            do
            {
            Console.SetCursorPosition(10, 0); Console.WriteLine("The game Tic Tac Toe");
            Console.WriteLine("Player 1:X \n Player 2:O\n");

            //tells whose turn it is in the game
            if (player % 2 == 0)
            {
                Console.SetCursorPosition(12, 4); Console.WriteLine("Now it's player 2's turn");
            }
            else
            {
                Console.SetCursorPosition(12, 4); Console.WriteLine("Now it's player 1's turn");
            }
            Console.WriteLine("\n");
            //board
            Board();
            mark = int.Parse(Console.ReadLine());
            if (mark < 1 || mark > 9)
            {
                Console.WriteLine("Sorry, the number you entered is incorrect. The number must be between 1 and 9");
                    Console.WriteLine("Wait 5 seconds. The board will reload...");
                    Thread.Sleep(5000);
                }
            else //checks if the player has made a move
            {
                if (cell[mark] != 'X' && cell[mark] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        cell[mark] = 'O';
                        player++;
                    }
                    else
                    {
                        cell[mark] = 'X';
                        player++;
                    }
                }
                else
                //if the cell is already filled
                {
                    Console.WriteLine("Sorry, cell {0} is already marked {1}", mark, cell[mark]);
                        Console.WriteLine("Wait 5 seconds. The board will reload...");
                        Thread.Sleep(5000);

                    }
                    result = CheckingWinner();
            }
        }
            while (result != 1 && result != -1) ;
            Console.Clear();
            Board();
            if (result == 1)
            {
                Console.SetCursorPosition(11, 16);
                Console.WriteLine("Player {0} won!", (player % 2) + 1);
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(16, 16);
                Console.WriteLine("Teko!");
                Console.ReadKey();
            }
        }
                //Creating a game board
                static void Board()
            {
                Console.SetCursorPosition(10, 6); Console.WriteLine("     |     |      ");
                Console.SetCursorPosition(10, 7); Console.WriteLine("  {0}  |  {1}  |  {2}", cell[1], cell[2], cell[3]);
                Console.SetCursorPosition(10, 8); Console.WriteLine("_____|_____|_____ ");
                Console.SetCursorPosition(10, 9); Console.WriteLine("     |     |      ");
                Console.SetCursorPosition(10, 10); Console.WriteLine("  {0}  |  {1}  |  {2}", cell[4], cell[5], cell[6]);
                Console.SetCursorPosition(10, 11); Console.WriteLine("_____|_____|_____ ");
                Console.SetCursorPosition(10, 12); Console.WriteLine("     |     |      ");
                Console.SetCursorPosition(10, 13); Console.WriteLine("  {0}  |  {1}  |  {2}", cell[7], cell[8], cell[9]);
                Console.SetCursorPosition(10, 14); Console.WriteLine("     |     |      ");
            }
            //Checking for a winner (conditions or combinations of winnings)
             static int CheckingWinner()
            {
                //Horizontal winning combinations
                if (cell[1] == cell[2] && cell[2] == cell[3])
                {
                    return 1;
                }
                else if (cell[4] == cell[5] && cell[5] == cell[6])
                {
                    return 1;
                }
                else if (cell[6] == cell[7] && cell[7] == cell[8])
                {
                    return 1;
                }
                //Vertical winning combinations
                else if (cell[1] == cell[4] && cell[4] == cell[7])
                {
                    return 1;
                }
                else if (cell[2] == cell[5] && cell[5] == cell[8])
                {
                    return 1;
                }
                else if (cell[3] == cell[6] && cell[6] == cell[9])
                {
                    return 1;
                }
                //Diagonal win combinations
                else if (cell[1] == cell[5] && cell[5] == cell[9])
                {
                    return 1;
                }
                else if (cell[3] == cell[5] && cell[5] == cell[7])
                {
                    return 1;
                }
                //Checking for a teko
                else if (cell[1] != '1' && cell[2] != '2' && cell[3] != '3' && cell[4] != '4' && cell[5] != '5' && cell[6] != '6' && cell[7] != '7' && cell[8] != '8' && cell[9] != '9')
                {
                    return -1;
                }
                //The game continues
                else
                {
                    return 0;
                }


            
        }

    }
}
