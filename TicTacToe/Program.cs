using System;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; //default player is 1
        static int choice;
        static int flag = 0; // check is someone has won

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player1: X and Player2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("player 2 turn");
                }
                else
                {
                    Console.WriteLine("player 1 turn");
                }
                Console.WriteLine("\n");
                Board(); // call board function
                choice = int.Parse(Console.ReadLine()); //get users choice

                // checking if position is x or o 
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                // don't allow place already taken to be chosen
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 seconds board is loading...");
                    Thread.Sleep(2000);
                }
                flag = CheckWin(); //check for win
            } while (flag != 1 && flag != -1);
                Console.Clear();
                Board();
            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else 
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }
        // method to create board
        private static void Board()
        {
			Console.WriteLine("     |     |      ");
			Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
			Console.WriteLine("_____|_____|_____ ");
			Console.WriteLine("     |     |      ");
			Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
			Console.WriteLine("_____|_____|_____ ");
			Console.WriteLine("     |     |      ");
			Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
			Console.WriteLine("     |     |      ");
        }
        private static int CheckWin()
        {
			#region Horizontal Win Condition
			if (arr[1] == arr[2] && arr[2] == arr[3])
			{
				return 1;
			}
			else if (arr[4] == arr[5] && arr[5] == arr[6])
			{
				return 1;
			}
			else if (arr[6] == arr[7] && arr[7] == arr[8])
			{
				return 1;
			}
			#endregion

			#region Vertical Win Condition
			else if (arr[1] == arr[4] && arr[4] == arr[7])
			{
				return 1;
			}
			else if (arr[2] == arr[5] && arr[5] == arr[8])
			{
				return 1;
			}
			else if (arr[3] == arr[6] && arr[6] == arr[9])
			{
				return 1;
			}
            #endregion

            #region Check for Draw
            // if all cells are full but no win then it is a draw
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else 
            {
                return 0;
            }
		}


    }
}
