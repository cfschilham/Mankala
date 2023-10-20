namespace Mankala;

 

public interface Ruleset
{
    Cup[] GenerateCups();
    int ApplyMove(int index, Cup[] state);
    int Winner(Cup[] state);
    string PrintBoard(Cup[] state);
}

public class MankalaRules : Ruleset
{
    public Cup[] GenerateCups()
    {
        return new[]
        {
            new Cup(0, 4),
            new Cup(0, 4),
            new Cup(0, 4),
            new Cup(0, 4),
            new Cup(0, 4),
            new Cup(0, 4),
            new HomeCup(0, 0),
            new Cup(0, 4),
            new Cup(0, 4),
            new Cup(0, 4),
            new Cup(0, 4),
            new Cup(0, 4),
            new Cup(0, 4),
            new HomeCup(0, 0),
        };
    }

    public int ApplyMove(int index, Cup[] state) => ApplyMoveTail(index, state, state[index].OwnerIndex);
    
    public int Winner(Cup[] state)
    {
        return -1;
    }

    public string PrintBoard(Cup[] state)
    {
        throw new NotImplementedException();
    }

    int ApplyMoveTail(int index, Cup[] state, int turn)
    {
        int pebbles = state[index].Pebbles;
        state[index].Pebbles = 0;
        int i;
        for (i = index; pebbles > 0; i = (i + 1) % (state.Length - 1))
        {
            if (state[i].GetType() == typeof(HomeCup) && state[i].OwnerIndex != turn) continue;
            state[i].Pebbles++;
            pebbles--;
        }

        if (state[i].GetType() == typeof(HomeCup)) return turn;
        if (state[i].Pebbles > 1) return ApplyMoveTail(i, state, turn);
        if (state[i].OwnerIndex != turn) return 1 - turn;
        if (state[12 - i].Pebbles > 0)
        {
            state[HomeCupIndex(turn)].Pebbles += state[12 - i].Pebbles + 1;
            state[12 - i].Pebbles = 0;
            state[i].Pebbles = 0;
        }
        return 1 - turn;
    }

    int HomeCupIndex(int ownerIndex) => ownerIndex == 0 ? 6 : 13;
}