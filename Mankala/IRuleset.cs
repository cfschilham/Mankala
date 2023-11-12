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
    
    public int Winner(Cup[] state) //This method checks if the game has ended and if so, which player has won
    {
        int[] cupContent = state.Select(c => c.Pebbles).ToArray();
        int sum1 = cupContent.Skip(1).Take(state.Length/2-1).Sum();
        int sum2 = cupContent.Skip(state.Length/2+1).Sum();
        if (sum1 != 0 && sum2 != 0) return -1;
        if (state[HomeCupIndex(0, state.Length)].Pebbles == state[HomeCupIndex(1, state.Length)].Pebbles) return 2;
        return state[HomeCupIndex(0, state.Length)].Pebbles > state[HomeCupIndex(1, state.Length)].Pebbles ? 0 : 1;
    }

    public int[] PossibleMoves(int turn, Cup[] state) => state.Select((_, i) => i).Where(i =>
        state[i].Type == Cup.CupType.Regular && state[i].Pebbles > 0 && state[i].OwnerIndex == turn).ToArray(); //This method returns the possible moves the current player has

    int ApplyMoveTail(int index, Cup[] state, int turn) //This method contains all the logic for moves
    {
        int pebbles = state[index].Pebbles;
        state[index].Pebbles = 0;
        int i;
        for (i = (index + 1)%state.Length; pebbles > 0; i = (i + 1) % state.Length) //Rotate trough all the different cups
        {
            if (state[i].Type == Cup.CupType.Home && state[i].OwnerIndex != turn) continue; //Skip opponents homecup (in other rulesets the players homecup might also be skipped)
            state[i].Pebbles++;
            pebbles--;
        }

        i--; // Make i equal the last cup into which a pebble was put.
        if (i == -1) i = state.Length - 1;
        if (state[i].Type == Cup.CupType.Home) return turn; //Move end result logic
        if (state[i].Pebbles > 1) return ApplyMoveTail(i, state, turn);
        if (state[i].OwnerIndex != turn) return 1 - turn;
        if (state[^i].Pebbles > 0)
        {
            state[HomeCupIndex(turn, state.Length)].Pebbles += state[^i].Pebbles + 1;
            state[^i].Pebbles = 0;
            state[i].Pebbles = 0;
        }
        return 1 - turn; //Returns the next player
    }

    int HomeCupIndex(int turn, int stateLength) => turn == 0 ? stateLength / 2 : 0;
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
        if (state[HomeCupIndex(0, state.Length)].Pebbles == state[HomeCupIndex(1, state.Length)].Pebbles) return 2;
        return state[HomeCupIndex(0, state.Length)].Pebbles > state[HomeCupIndex(1, state.Length)].Pebbles ? 0 : 1;
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
            state[HomeCupIndex(turn, state.Length)].Pebbles += state[i].Pebbles;
            state[i].Pebbles = 0;
        }
        return 1 - turn;
    }

    int HomeCupIndex(int turn, int stateLength) => turn == 0 ? stateLength / 2 : 0;
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
        if (state[HomeCupIndex(0, state.Length)].Pebbles == state[HomeCupIndex(1, state.Length)].Pebbles) return 2;
        return state[HomeCupIndex(0, state.Length)].Pebbles > state[HomeCupIndex(1, state.Length)].Pebbles ? 0 : 1;
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
            state[HomeCupIndex(turn, state.Length)].Pebbles += state[^i].Pebbles + 1;
            state[^i].Pebbles = 0;
            state[i].Pebbles = 0;
        }
        return 1 - turn;
    }

    int HomeCupIndex(int turn, int stateLength) => turn == 0 ? stateLength / 2 : 0;
}