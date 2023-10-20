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

    public void ApplyMove(int index) => _turn = _ruleset.ApplyMove(index, _state);

    public override string ToString() => _ruleset + $"\n\nTurn: {_players[_turn].Name} ({_turn + 1})";

    public Player GetTurn() => _players[_turn];

    public string PrintBoard() => _ruleset.PrintBoard(_state);

    public int Winner() => _ruleset.Winner(_state);
}