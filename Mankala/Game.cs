namespace Mankala;

public class Game
{
    Cup[] _state;
    int _turn; 
    Player[] _players;
    IRuleset _ruleset;
    int cups, startingPebbles;

    public Game(IRuleFactory rf, Player[] ps)
    {
        _ruleset = rf.MakeRuleset();
        _state = rf.MakeState();
        _turn = 0;
        _players = ps;
    }

    public bool IsValidMove(int index) => _ruleset.PossibleMoves(_turn, _state).Contains(index);

    public void ApplyMove(int index)
    {
        if (!IsValidMove(index)) throw new IndexOutOfRangeException("move is not valid");
        _turn = _ruleset.ApplyMove(index, _state); //Turn is updated after a move
    }

    public Player GetTurn() => _players[_turn];

    public int Winner() => _ruleset.Winner(_state);

    public Cup[] GetState() => (_state.Clone() as Cup[] ?? Array.Empty<Cup>()).Select(c => new Cup(c.OwnerIndex, c.Pebbles, c.Type)).ToArray();

    public Player[] GetPlayers() => (_players.Clone() as Player[] ?? Array.Empty<Player>()).Select(p => new Player(p.Name)).ToArray();
}