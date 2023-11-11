using System;
using System.Linq;

namespace Mankala;

public interface IRuleset
{
    int ApplyMove(int index, Cup[] state);
    int Winner(Cup[] state);
    int[] PossibleMoves(int turn, Cup[] state);
}

public interface IRuleFactory
{
    Cup[] MakeState();
    IRuleset MakeRuleset();
    IGraphics MakeGraphics();
}

public interface IGraphics
{
    public void PaintBoard(Cup[] state, PaintEventArgs pea);
    public int CupIndexAt(Point p);
}

public class MankalaRuleFactory : IRuleFactory
{
    public Cup[] MakeState()
    {
        return new[]
        {
            new Cup(1, 0, Cup.CupType.Home),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 0, Cup.CupType.Home),
            new Cup(1, 4, Cup.CupType.Regular),
            new Cup(1, 4, Cup.CupType.Regular),
            new Cup(1, 4, Cup.CupType.Regular),
            new Cup(1, 4, Cup.CupType.Regular),
            new Cup(1, 4, Cup.CupType.Regular),
            new Cup(1, 4, Cup.CupType.Regular),
        };
    }

    public IRuleset MakeRuleset() => new MankalaRules(t => t == 0 ? 7 : 0);

    public IGraphics MakeGraphics() => new BasicGraphics();
}

public class MankalaRules : IRuleset
{
    Func<int, int> HomeCupIndex;
    
    public MankalaRules(Func<int, int> homeCupIndex)
    {
        HomeCupIndex = homeCupIndex;
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
        if (i == -1) i = 13;
        if (state[i].Type == Cup.CupType.Home) return turn;
        if (state[i].Pebbles > 1) return ApplyMoveTail(i, state, turn);
        if (state[i].OwnerIndex != turn) return 1 - turn;
        if (state[^i].Pebbles > 0)
        {
            state[HomeCupIndex(turn)].Pebbles += state[^i].Pebbles + 1;
            state[^i].Pebbles = 0;
            state[i].Pebbles = 0;
        }
        return 1 - turn;
    }
}

public class BasicGraphics : IGraphics
{
    Dictionary<Rectangle, int> _cupLookup = new Dictionary<Rectangle, int>();
    
    public void PaintBoard(Cup[] state, PaintEventArgs pea)
    {
        if (state.Length%2 != 0) throw new ArgumentException("invalid state structure");
        for (int i = 0; i < state.Length/2; i++)
            if (state[i].Type != state[i+state.Length/2].Type) 
                throw new ArgumentException("invalid state structure");
        
        _cupLookup.Clear();
        for (int i = 0; i < state.Length; i++)
        {
            Rectangle cupRect = CupRect(i, state);
            _cupLookup[cupRect] = i; 
            pea.Graphics.DrawEllipse(new Pen(Color.Black), cupRect);
            pea.Graphics.DrawString(state[i].Pebbles.ToString(), new Font("Arial", 11), new SolidBrush(Color.Black),
                cupRect.X + cupRect.Width / 2 - 5, cupRect.Y + cupRect.Height / 2 - 5);
        }
    }

    Rectangle CupRect(int index, Cup[] state)
    {
        int h = 120;
        int w = 40;
        int y = 0;
        int x = index * 50;
        if (state[index].Type != Cup.CupType.Regular) return new Rectangle(x, y, w, h);
        h = 40;
        y = state[index].OwnerIndex == 0 ? 80 : 0;
        x -= state[index].OwnerIndex == 1 ? state.Length / 2 * 50 : 0;

        return new Rectangle(x, y, w, h);
    }

    public int CupIndexAt(Point p)
    {
        Rectangle r = _cupLookup.Keys.FirstOrDefault(r => r.Contains(p));
        if (r == Rectangle.Empty) return -1;
        return _cupLookup[r];
    }
}


public class WariRuleFactory : IRuleFactory
{
    public Cup[] MakeState()
    {
        return new[]
        {
            new Cup(1, 0, Cup.CupType.Home),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 4, Cup.CupType.Regular),
            new Cup(0, 0, Cup.CupType.Home),
            new Cup(1, 4, Cup.CupType.Regular),
            new Cup(1, 4, Cup.CupType.Regular),
            new Cup(1, 4, Cup.CupType.Regular),
            new Cup(1, 4, Cup.CupType.Regular),
            new Cup(1, 4, Cup.CupType.Regular),
            new Cup(1, 4, Cup.CupType.Regular),
        };
    }

    public IRuleset WariRuleset() => new WariRules;

    public IGraphics MakeGraphics() => new BasicGraphics();
}

public class WariRules : IRuleset
{
    Func<int, int> HomeCupIndex;

    public MankalaRules(Func<int, int> homeCupIndex)
    {
        HomeCupIndex = homeCupIndex;
    }

    public int ApplyMove(int index, Cup[] state) => ApplyMoveTail(index, state, state[index].OwnerIndex);

    public int Winner(Cup[] state)
    {
        int[] cupContent = state.Select(c => c.Pebbles).ToArray();
        int sum1 = cupContent.Take(state.Length / 2).Sum();
        int sum2 = cupContent.Skip(state.Length / 2).Sum();
        if (sum1 != 0 && sum2 != 0) return -1;
        if (state[HomeCupIndex(0)].Pebbles == state[HomeCupIndex(1)].Pebbles) return 2;
        return state[HomeCupIndex(0)].Pebbles > state[HomeCupIndex(1)].Pebbles ? 0 : 1;
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
        if (i == -1) i = state[index].length -1;
        if (state[i].OwnerIndex != turn) && (state[i].Pebbles == (2 || 3))
        {
            state[HomeCupIndex(turn)].Pebbles += state[i].Pebbles;
            state[i].Pebbles = 0;
        }
        return 1 - turn;
    }

}