namespace Mankala.Tests;

public class MankalaRulesTests
{
    MankalaRules _ruleset;
    Cup[] _state;

    public MankalaRulesTests()
    {
        _ruleset = new MankalaRules();
        _state = new Cup[14];
        for (int i = 0; i < 6; i++)
        {
            _state[i + 1] = new Cup(0, 4, Cup.CupType.Regular);
            _state[i + 8] = new Cup(1, 4, Cup.CupType.Regular);
        }
        _state[0] = new Cup(0, 0, Cup.CupType.Home);
        _state[7] = new Cup(1, 0, Cup.CupType.Home);
    }

    [Fact]
    public void ApplyMove_ValidMove_ChangesState()
    {
        int turn = _ruleset.ApplyMove(0, _state);
        Assert.Equal(0, _state[0].Pebbles);
        Assert.Equal(5, _state[1].Pebbles);
        Assert.Equal(5, _state[2].Pebbles);
        Assert.Equal(5, _state[3].Pebbles);
        Assert.Equal(5, _state[4].Pebbles);
        Assert.Equal(4, _state[5].Pebbles);
        Assert.Equal(4, _state[6].Pebbles);
        Assert.Equal(0, turn);
    }
}

public class WariRulesTests
{
    WariRules _ruleset;
    Cup[] _state;

    public WariRulesTests()
    {
        _ruleset = new WariRules();
        _state = new Cup[12];
        for (int i = 0; i < 6; i++)
        {
            _state[i] = new Cup(0, 4, Cup.CupType.Regular);
            _state[i + 6] = new Cup(1, 4, Cup.CupType.Regular);
        }
    }

    [Fact]
    public void ApplyMove_ValidMove_ChangesState()
    {
        int turn = _ruleset.ApplyMove(0, _state);
        Assert.Equal(0, _state[0].Pebbles);
        Assert.Equal(5, _state[1].Pebbles);
        Assert.Equal(5, _state[2].Pebbles);
        Assert.Equal(5, _state[3].Pebbles);
        Assert.Equal(5, _state[4].Pebbles);
        Assert.Equal(4, _state[5].Pebbles);
        Assert.Equal(1, turn);
    }
}

public class WankalaRulesTests
{
    WankalaRules _ruleset;
    Cup[] _state;

    public WankalaRulesTests()
    {
        _ruleset = new WankalaRules();
        _state = new Cup[14];
        for (int i = 0; i < 6; i++)
        {
            _state[i + 1] = new Cup(0, 4, Cup.CupType.Regular);
            _state[i + 8] = new Cup(1, 4, Cup.CupType.Regular);
        }
        _state[0] = new Cup(0, 0, Cup.CupType.Home);
        _state[7] = new Cup(1, 0, Cup.CupType.Home);
    }

    [Fact]
    public void ApplyMove_ValidMove_ChangesState()
    {
        int turn = _ruleset.ApplyMove(0, _state);
        Assert.Equal(0, _state[0].Pebbles);
        Assert.Equal(5, _state[1].Pebbles);
        Assert.Equal(5, _state[2].Pebbles);
        Assert.Equal(5, _state[3].Pebbles);
        Assert.Equal(5, _state[4].Pebbles);
        Assert.Equal(4, _state[5].Pebbles);
        Assert.Equal(1, _state[6].Pebbles);
        Assert.Equal(1, turn);
    }
}
