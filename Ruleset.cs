namespace Mankala;

public interface Ruleset
{
    Cup[] GenerateCups(Player player1, Player player2);
    Player ApplyMove(int index, Cup[] state, Player current);
    int Winner(Cup[] state);
}

public class MankalaRules : Ruleset
{
    public Cup[] GenerateCups(Player player1, Player player2)
    {
        Cup[] state = new Cup[14];
        for (int i = 0; i < state.Length; i++)
        {
            if (i < 6)
                state[i] = new Cup(player1, 4);
            else if (i == 6)
                state[i] = new HomeCup(player1, 4);
            else if (i < 13)
                state[i] = new Cup(player2, 4);
            else
                state[i] = new HomeCup(player2, 4);
        }
        return state;
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
        bool empty1 = true, empty2 = true;
        for (int i = 0; i<6; i++)
        {
            if (state[i].Pebbles != 0)
                empty1 = false;
        }
        for (int i = 7; i < 13; i++)
        {
            if (state[i].Pebbles != 0)
                empty2 = false;
        }
        if (!empty1 && !empty2) return -1;

        if (state[6].Pebbles > state[13].Pebbles)
            return 0;
        else if (state[13].Pebbles > state[6].Pebbles)
            return 1;
        else return 2;
    }
}
