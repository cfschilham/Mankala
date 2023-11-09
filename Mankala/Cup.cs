namespace Mankala;

public class Cup
{
    public int OwnerIndex { get; }
    public int Pebbles { get; set; }

    public CupType Type { get; }
    public enum CupType : byte
    {
        Regular,
        Home,
        Outside,
    }

    public Cup(int ownerIndex, int pebbles, CupType type)
    {
        OwnerIndex = ownerIndex;
        Pebbles = pebbles;
        Type = type;
    }
    
    
}
