namespace Mankala;

public interface IRuleFactory
{
    Cup[] MakeState();
    IRuleset MakeRuleset();
    IGraphics MakeGraphics();
}

public class MankalaRuleFactory : IRuleFactory
{
    int _cupsAmount;
    int _startingPebbles;
    public MankalaRuleFactory(int cupsAmount = 6, int startingPebbles = 4)
    {
        _cupsAmount = cupsAmount;
        _startingPebbles = startingPebbles;
    }
    public Cup[] MakeState()
    {
        Cup[] cups = new Cup[_cupsAmount * 2 + 2];
        cups[0] = new Cup(1, 0, Cup.CupType.Home);
        cups[_cupsAmount + 1] = new Cup(0, 0, Cup.CupType.Home);
        for (int i = 1; i <= _cupsAmount; i++) cups[i] = new Cup(0, _startingPebbles, Cup.CupType.Regular);
        for (int i = _cupsAmount + 2; i <= _cupsAmount * 2 + 1; i++) cups[i] = new Cup(1, _startingPebbles, Cup.CupType.Regular);

        return cups;
    }

    public IRuleset MakeRuleset() => new MankalaRules();

    public IGraphics MakeGraphics() => new BasicGraphics();
}

public class WariRuleFactory : IRuleFactory
{
    int _cupsAmount;
    int _startingPebbles;
    public WariRuleFactory(int cupsAmount, int startingPebbles)
    {
        _cupsAmount = cupsAmount;
        _startingPebbles = startingPebbles;
    }
    public Cup[] MakeState()
    {
        Cup[] cups = new Cup[_cupsAmount * 2 + 2];
        cups[0] = new Cup(1, 0, Cup.CupType.Home);
        cups[_cupsAmount + 1] = new Cup(0, 0, Cup.CupType.Home);
        for (int i = 1; i <= _cupsAmount; i++) cups[i] = new Cup(0, _startingPebbles, Cup.CupType.Regular);
        for (int i = _cupsAmount + 2; i <= _cupsAmount * 2 + 1; i++) cups[i] = new Cup(1, _startingPebbles, Cup.CupType.Regular);

        return cups;
    }

    public IRuleset MakeRuleset() => new WariRules();

    public IGraphics MakeGraphics() => new BasicGraphics();
}

public class WankalaRuleFactory : IRuleFactory
{
    int _cupsAmount;
    int _startingPebbles;
    public WankalaRuleFactory(int cupsAmount, int startingPebbles)
    {
        _cupsAmount = cupsAmount;
        _startingPebbles = startingPebbles;
    }
    public Cup[] MakeState()
    {
        Cup[] cups = new Cup[_cupsAmount * 2 + 2];
        cups[0] = new Cup(1, 0, Cup.CupType.Home);
        cups[_cupsAmount + 1] = new Cup(0, 0, Cup.CupType.Home);
        for (int i = 1; i <= _cupsAmount; i++) cups[i] = new Cup(0, _startingPebbles, Cup.CupType.Regular);
        for (int i = _cupsAmount + 2; i <= _cupsAmount * 2 + 1; i++) cups[i] = new Cup(1, _startingPebbles, Cup.CupType.Regular);

        return cups;
    }

    public IRuleset MakeRuleset() => new WankalaRules();

    public IGraphics MakeGraphics() => new BasicGraphics();
}

