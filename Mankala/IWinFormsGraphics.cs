namespace Mankala;

public interface IWinFormsGraphics
{
    public void PaintBoard(Cup[] state, PaintEventArgs pea);
    public int CupIndexAt(Point p);
}

public class BasicWinFormsGraphics : IWinFormsGraphics
{
    Dictionary<Rectangle, int> _cupLookup = new();
    
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
        if (index > state.Length / 2) x -= (index - (state.Length / 2)) * 100;

        return new Rectangle(x, y, w, h);
    }

    public int CupIndexAt(Point p)
    {
        Rectangle r = _cupLookup.Keys.FirstOrDefault(r => r.Contains(p));
        if (r == Rectangle.Empty) return -1;
        return _cupLookup[r];
    }
}