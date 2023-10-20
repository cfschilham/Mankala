namespace Mankala;

public class Cup
{
    public Player Owner { get; set; }
    public int Pebbles { get; set; }

    public Cup(Player owner, int pebbles)
    {
        Owner = owner;
        Pebbles = pebbles;
    }
}

public class HomeCup : Cup
{
    public HomeCup(Player owner, int pebbles) : base(owner, pebbles) {}
}