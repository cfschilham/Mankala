using System.Text;

namespace Mankala;

 

public interface Ruleset
{
    Cup[] GenerateCups();
    int ApplyMove(int index, Cup[] state);
    int Winner(Cup[] state);
    string PrintBoard(Cup[] state);
    int[] PossibleMoves(int turn, Cup[] state);
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
        string result = "";
        result += "  " + string.Join(" ", cupContent.Skip(7).Take(6).Reverse().Select(n => n.ToString())) + "  \n";
        result += cupContent[HomeCupIndex(1)] + " " + new string('-', 11) + " " + cupContent[HomeCupIndex(0)] + "\n";
        result += "  " + string.Join(" ", cupContent.Skip(0).Take(6).Select(n => n.ToString())) + "  ";
        return result;
    }

    public int[] PossibleMoves(int turn, Cup[] state)
    {
        int[] playersCups = turn == 0 ? new [] {0,1,2,3,4,5} : new [] {7,8,9,10,11,12};
        return playersCups.Where((c, i) => state[i].Pebbles != 0).ToArray();
    }

    int ApplyMoveTail(int index, Cup[] state, int turn)
    {
        int pebbles = state[index].Pebbles;
        state[index].Pebbles = 0;
        int i;
        for (i = index + 1; pebbles > 0; i = (i + 1) % (state.Length - 1))
        {
            if (state[i].GetType() == typeof(HomeCup) && state[i].OwnerIndex != turn) continue;
            state[i].Pebbles++;
            pebbles--;
        }

        i--; // Make i equal the last cup into which a pebble was put.
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