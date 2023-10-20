namespace Mankala;

public interface Ruleset
{
    Cup[] GenerateCups();
    int ApplyMove(int index, Cup[] state);
    int Winner(Cup[] state);
}

public class MankalaRules : Ruleset
{
    public Cup[] GenerateCups()
    {
        throw new NotImplementedException();
    }

    public int ApplyMove(int index, Cup[] state)
    {
        throw new NotImplementedException();
    }

    public int Winner(Cup[] state)
    {
        throw new NotImplementedException();
    }
}
