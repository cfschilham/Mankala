namespace Mankala;

public class Board
{
    protected Cup[] _state;
    protected int _turn;
    protected Player[] _players;
    protected Ruleset _ruleset;

    public Board(Ruleset rs, Player[] ps)
    {
        _ruleset = rs;
        _state = rs.GenerateCups();
        _turn = 0;
        _players = ps;
    }

    public void ApplyMove(int idx)
    {
        
    }

    public string Print()
    {
        
    }

    public Player GetTurn() => _players[_turn];
}