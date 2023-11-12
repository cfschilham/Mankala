namespace Mankala;

public class Board : Control
{
    Game _game;
    IWinFormsGraphics _graphics;
    
    public Board(Game game, IRuleFactory rf)
    {
        _game = game;
        _graphics = rf.MakeWinFormsGraphics();
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        base.OnPaint(pea);
        _graphics.PaintBoard(_game.GetState(), pea);
        pea.Graphics.DrawString($"Turn: {_game.GetTurn().Name}", new Font("Arial", 14), new SolidBrush(Color.Black),
            10, 200);
    }

    protected override void OnMouseMove(MouseEventArgs mea)
    {
        base.OnMouseMove(mea);
        int i = _graphics.CupIndexAt(mea.Location);
        if (i == -1)
        {
            Cursor = Cursors.Default;
            return;
        }
        if (_game.IsValidMove(i))
        {
            Cursor = Cursors.Hand;
            return;
        }

        Cursor = Cursors.No;
    }

    protected override void OnMouseClick(MouseEventArgs mea)
    {
        base.OnMouseClick(mea);
        int i = _graphics.CupIndexAt(mea.Location);
        if (i == -1) return;
        if (!_game.IsValidMove(i)) return;
        _game.ApplyMove(i);
        Invalidate();
        if (_game.Winner() == -1) return;
        var text = "Tie!";
        int w = _game.Winner();
        if (w < 2) text = $"{_game.GetPlayers()[w].Name} wins!";
        MessageBox.Show(text);
        Application.Exit();
    }
}