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
            new Cup(1, 4),
            new Cup(1, 4),
            new Cup(1, 4),
            new Cup(1, 4),
            new Cup(1, 4),
            new Cup(1, 4),
            new HomeCup(1, 0),
        };
    }

    public int ApplyMove(int index, Cup[] state) => ApplyMoveTail(index, state, state[index].OwnerIndex);
    
    public int Winner(Cup[] state)
    {
        int[] cupContent = state.Select(c => c.Pebbles).ToArray();
        int sum1 = cupContent.Take(state.Length/2).Sum();
        int sum2 = cupContent.Skip(state.Length/2).Sum();
        if (sum1 != 0 && sum2 != 0) return -1;
        if (state[HomeCupIndex(0)].Pebbles == state[HomeCupIndex(1)].Pebbles) return 2;
        return state[HomeCupIndex(0)].Pebbles > state[HomeCupIndex(1)].Pebbles ? 0 : 1;
    }

    public string PrintBoard(Cup[] state)
    {
        int[] cupContent = state.Select(c => c.Pebbles).ToArray();
        string PrintSixNumbers(int skip) => string.Join(" ", cupContent.Skip(skip).Take(6).Select(n => n.ToString()));

        string result = "";
        result += "  " + PrintSixNumbers(1) + "  \n";
        result += cupContent[HomeCupIndex(0)] + " " + Enumerable.Repeat("-", 6) + " " + cupContent[HomeCupIndex(1)] + "\n";
        result += "  " + PrintSixNumbers(7) + "  ";
        return result;
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