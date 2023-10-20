namespace Mankala;

public interface Ruleset
{
    Cup[] GenerateCups();
    Player ApplyMove(int index, Cup[] state, Player current);
    int Winner(Cup[] state);
}

public class MankalaRules : Ruleset
{
    public Cup[] GenerateCups()
    {
        throw new NotImplementedException();
    }

    public Player ApplyMove(int index, Cup[] state, Player current)
    {
        int Currentpebbles = state[index].Pebbles;
        state[index].Pebbles = 0;

        while(Currentpebbles > 0) 
        {
            if (index < state.Length - 1) 
            {
                index++;
                if (index != 6 && index != 13 || state[index].Owner == current)
                {
                    state[index].Pebbles++;
                    Currentpebbles--;
                }
            }
            else 
            {
                index = 0;
                if (state[index].Owner == current)
                {
                    state[index].Pebbles++;
                    Currentpebbles--;
                }
            }
        }

        if (state[index].Owner == current && (index == 6 || index == 13))
            return current;

        if (state[index].Pebbles - 1 != 0)
            return ApplyMove(index, state, current);

        if (state[index].Owner == current && (state[12 - index].Pebbles != 0))
        {
            int newPebbles = state[12 - index].Pebbles + 1;
            state[12 - index].Pebbles = 0; state[index].Pebbles = 0;
            if (state[6].Owner == current)
                state[6].Pebbles += newPebbles;
            else
                state[13].Pebbles += newPebbles;
        }

        return state[index].Owner; 
    }

    public int Winner(Cup[] state)
    {
        throw new NotImplementedException();
    }
}
