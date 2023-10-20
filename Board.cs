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

    public void ApplyMove(int index)
    {
        if (!_ruleset.PossibleMoves(_turn, _state).Contains(index))
        {
            throw new IndexOutOfRangeException("move is not valid");
        }
        _turn = _ruleset.ApplyMove(index, _state);
    }

    // TODO: Make more universal to different rulesets (??)
    public override string ToString() => _players[0].Name + "\n" + _ruleset.PrintBoard(_state) + $"\n{_players[1].Name}" + $"\n\nTurn: {_players[_turn].Name} ({_turn + 1})";

    public Player GetTurn() => _players[_turn];

    public int Winner() => _ruleset.Winner(_state);
}