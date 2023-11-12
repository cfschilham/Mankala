using System;
using System.Linq;

namespace Mankala;

public interface IRuleset
{
    int ApplyMove(int index, Cup[] state);
    int Winner(Cup[] state);
    int[] PossibleMoves(int turn, Cup[] state);
}

public class MankalaRules : IRuleset
{
    public int ApplyMove(int index, Cup[] state) => ApplyMoveTail(index, state, state[index].OwnerIndex);
    
    public int Winner(Cup[] state)
    {
        int[] cupContent = state.Select(c => c.Pebbles).ToArray();
        int sum1 = cupContent.Skip(1).Take(state.Length/2-1).Sum();
        int sum2 = cupContent.Skip(state.Length/2+1).Sum();
        if (sum1 != 0 && sum2 != 0) return -1;
        if (state[0].Pebbles == state[state.Length/2].Pebbles) return 2;
        return state[0].Pebbles > state[state.Length/2].Pebbles ? 0 : 1;
    }

    public int[] PossibleMoves(int turn, Cup[] state) => state.Select((_, i) => i).Where(i =>
        state[i].Type == Cup.CupType.Regular && state[i].Pebbles > 0 && state[i].OwnerIndex == turn).ToArray();

    int ApplyMoveTail(int index, Cup[] state, int turn)
    {
        int pebbles = state[index].Pebbles;
        state[index].Pebbles = 0;
        int i;
        for (i = (index + 1)%state.Length; pebbles > 0; i = (i + 1) % state.Length)
        {
            if (state[i].Type == Cup.CupType.Home && state[i].OwnerIndex != turn) continue;
            state[i].Pebbles++;
            pebbles--;
        }

        i--; // Make i equal the last cup into which a pebble was put.
        if (i == -1) i = state.Length;
        if (state[i].Type == Cup.CupType.Home) return turn;
        if (state[i].Pebbles > 1) return ApplyMoveTail(i, state, turn);
        if (state[i].OwnerIndex != turn) return 1 - turn;
        if (state[^i].Pebbles > 0)
        {
            state[turn].Pebbles += state[^i].Pebbles + 1;
            state[^i].Pebbles = 0;
            state[i].Pebbles = 0;
        }
        return 1 - turn;
    }
}

public class WariRules : IRuleset
{
    public int ApplyMove(int index, Cup[] state) => ApplyMoveTail(index, state, state[index].OwnerIndex);

    public int Winner(Cup[] state)
    {
        int[] cupContent = state.Select(c => c.Pebbles).ToArray();
        int sum1 = cupContent.Skip(1).Take(state.Length/2-1).Sum();
        int sum2 = cupContent.Skip(state.Length/2+1).Sum();
        if (sum1 != 0 && sum2 != 0) return -1;
        if (state[0].Pebbles == state[state.Length/2].Pebbles) return 2;
        return state[0].Pebbles > state[state.Length/2].Pebbles ? 0 : 1;
    }

    public int[] PossibleMoves(int turn, Cup[] state) => state.Select((_, i) => i).Where(i =>
        state[i].Type == Cup.CupType.Regular && state[i].Pebbles > 0 && state[i].OwnerIndex == turn).ToArray();

    int ApplyMoveTail(int index, Cup[] state, int turn)
    {
        int pebbles = state[index].Pebbles;
        state[index].Pebbles = 0;
        int i;
        for (i = (index + 1) % state.Length; pebbles > 0; i = (i + 1) % state.Length)
        {
            if (state[i].Type == Cup.CupType.Home) continue;
            state[i].Pebbles++;
            pebbles--;
        }

        i--; // Make i equal the last cup into which a pebble was put.
        if (i == -1) i = state.Length - 1;
        if (state[i].OwnerIndex != turn && new [] {2,3}.Contains(state[i].Pebbles))
        {
            state[turn].Pebbles += state[i].Pebbles;
            state[i].Pebbles = 0;
        }
        return 1 - turn;
    }

}

public class WankalaRules : IRuleset
{
    public int ApplyMove(int index, Cup[] state) => ApplyMoveTail(index, state, state[index].OwnerIndex);

    public int Winner(Cup[] state)
    {
        int[] cupContent = state.Select(c => c.Pebbles).ToArray();
        int sum1 = cupContent.Skip(1).Take(state.Length/2-1).Sum();
        int sum2 = cupContent.Skip(state.Length/2+1).Sum();
        if (sum1 != 0 && sum2 != 0) return -1;
        if (state[0].Pebbles == state[state.Length/2].Pebbles) return 2;
        return state[0].Pebbles > state[state.Length/2].Pebbles ? 0 : 1;
    }

    public int[] PossibleMoves(int turn, Cup[] state) => state.Select((_, i) => i).Where(i =>
        state[i].Type == Cup.CupType.Regular && state[i].Pebbles > 0 && state[i].OwnerIndex == turn).ToArray();

    int ApplyMoveTail(int index, Cup[] state, int turn)
    {
        int pebbles = state[index].Pebbles;
        state[index].Pebbles = 0;
        int i;
        for (i = (index + 1) % state.Length; pebbles > 0; i = (i + 1) % state.Length)
        {
            if (state[i].Type == Cup.CupType.Home) continue;
            state[i].Pebbles++;
            pebbles--;
        }

        i--; // Make i equal the last cup into which a pebble was put.
        if (i == -1) i = state.Length - 1;
        if (state[i].OwnerIndex != turn && new [] {2,3}.Contains(state[i].Pebbles))
        {
            state[turn].Pebbles += state[i].Pebbles;
            state[i].Pebbles = 0;
        }
        if (state[i].OwnerIndex != turn) return 1 - turn;
        if (state[^i].Pebbles > 0 && state[i].Pebbles == 1)
        {
            state[turn].Pebbles += state[^i].Pebbles + 1;
            state[^i].Pebbles = 0;
            state[i].Pebbles = 0;
        }
        return 1 - turn;
    }

}