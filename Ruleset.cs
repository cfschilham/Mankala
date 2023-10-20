namespace Mankala;

public interface Ruleset
{
    void ApplyMove(int player, int index, int[] state);
    byte Winner(int[] state);
    int GetCups();
    bool HasHomeCups();
}

public class StandardRules : Ruleset
{
    public void ApplyMove(int player, int index, int[] state)
    {
        
    }

    public byte Winner(int[] state)
    {
        throw new NotImplementedException();
    }

    public int GetCups() => 6;

    public bool HasHomeCups() => true;
}
