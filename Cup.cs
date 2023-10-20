namespace Mankala;

public class Cup
{
    public int OwnerIndex { get; set; }
    public int Pebbles { get; set; }

    public Cup(int ownerIndex, int pebbles)
    {
        OwnerIndex = ownerIndex;
        Pebbles = pebbles;
    }
}

public class HomeCup : Cup
{
    public HomeCup(int ownerIndex, int pebbles) : base(ownerIndex, pebbles) {}
}