using System;

namespace TicTacToe
{
    class Program
    {
        private static char[,] board = new char[3, 3];
        private static bool gameOver = false;
        private static bool isTie = false;
        public static int turn = 1;
        public static char[] winnerArray = { 'X','O' }; // by making winnerArray[turn%2] we get potencional winner

        private static void Main(string[] args)
        {
            InitBoard();
            DisplayBoard();
            MakeTurn();
            
        }
        public static void MakeTurn()
        {
            if (turn%2==1)
            {
                XCheckPoint:
                Console.WriteLine(@"'X', choose your location (row, column):");
                int row = Convert.ToInt32(Console.ReadLine());
                int column = Convert.ToInt32(Console.ReadLine());
                if(0<=row && row<3 && 0<=column && column<3 && board[row,column]==' ')
                {
                    board[row, column] = 'X';
                    turn++;
                }
                else
                {
                    Console.WriteLine("Wrong row/column input");
                    goto XCheckPoint;
                }
            }else if (turn%2==0)
            {
                OCheckPoint:
                Console.WriteLine(@"'O', choose your location (row, column):");
                int row = Convert.ToInt32(Console.ReadLine());
                int column = Convert.ToInt32(Console.ReadLine());
                if (0<=row && row<3 && 0<=column && column<3 && board[row, column]==' ')
                {
                    board[row, column] = 'O';
                    turn++;
                }
                else
                {
                    Console.WriteLine("Wrong row/column input");
                    goto OCheckPoint;
                }
            }
            CheckForWinners(winnerArray[turn%2]);
            DisplayBoard();
            if (gameOver!=true && isTie!=true)
            {
                MakeTurn();
            }else if(isTie == true)
            {
                Console.WriteLine("The game is tie!");
            }else if(gameOver == true)
            {
                Console.WriteLine($"{winnerArray[turn%2]} wins!");
            }
            

        }
        // 00-01-02 10-11-12 2
       private static void CheckForWinners(char XOrO)
        {
            if (board[0, 0]==XOrO&&board[0, 1]==XOrO&&board[0, 1]==XOrO&&board[0, 2]==XOrO
                || board[1, 0]==XOrO&&board[1, 1]==XOrO&&board[1, 1]==XOrO&&board[1, 2]==XOrO
                || board[2, 0]==XOrO&&board[2, 1]==XOrO&&board[2, 1]==XOrO&&board[2, 2]==XOrO
                || board[0, 0]==XOrO&&board[1, 0]==XOrO&&board[1, 0]==XOrO&&board[2, 0]==XOrO
                || board[0, 1]==XOrO&&board[1, 1]==XOrO&&board[1, 1]==XOrO&&board[2, 1]==XOrO
                || board[0, 2]==XOrO&&board[1, 2]==XOrO&&board[1, 2]==XOrO&&board[2, 2]==XOrO
                || board[0, 0]==XOrO&&board[1, 1]==XOrO&&board[1, 1]==XOrO&&board[2, 2]==XOrO
                || board[0, 2]==XOrO&&board[1, 1]==XOrO&&board[1, 1]==XOrO&&board[2, 0]==XOrO
                )
            {
                gameOver = true;
            }
            else if (turn==10)
            {
                isTie = true;
            }
        }
        private static void InitBoard()
        {
            // fills up the board with blanks
            for (var r = 0; r < 3; r++)
            {
                for (var c = 0; c < 3; c++)
                    board[r, c] = ' ';
            }
            
        }

        private static void DisplayBoard()
        {
            Console.WriteLine("  0  " + board[0, 0] + "|" + board[0, 1] + "|" + board[0, 2]);
            Console.WriteLine("    --+-+--");
            Console.WriteLine("  1  " + board[1, 0] + "|" + board[1, 1] + "|" + board[1, 2]);
            Console.WriteLine("    --+-+--");
            Console.WriteLine("  2  " + board[2, 0] + "|" + board[2, 1] + "|" + board[2, 2]);
            Console.WriteLine("    --+-+--");
            Console.WriteLine("=======================================================");
        }
    }
}
