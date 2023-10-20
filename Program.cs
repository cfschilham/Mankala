namespace Mankala;

class Program
{
    void Main()
    {
        Console.WriteLine("What is the name of PLayer 1?");
        string player1Name = Console.ReadLine();
        Console.WriteLine("What is the name of Player 2?");
        string player2Name = Console.ReadLine();
        Player[] players = new Player[2]; players[0] = new Player(player1Name); players[1] = new Player(player2Name);
        Board board = new Board(new MankalaRules(), players);
        
        int winner = -1;
        while (winner == -1) 
        {
            Console.WriteLine("This is the current board:");
            Console.Write(board.ToString());
            Console.WriteLine("It is " + board.GetTurn().Name + "'s turn. \n What move would you like to make?");
            int move = Convert.ToInt32(Console.ReadLine());
            board.ApplyMove(move);

            winner = board.Winner();
        }

        if (winner == 2)
            Console.WriteLine("It's a draw.");
        else
            Console.WriteLine("The winner is " + players[winner].Name);
    }
}