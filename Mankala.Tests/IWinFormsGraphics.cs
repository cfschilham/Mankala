using System.Drawing;
using System.Windows.Forms;

namespace Mankala.Tests;

public class BasicWinFormsGraphicsTests
{
    BasicWinFormsGraphics _basicWinFormsGraphics;
    Cup[] _state;
    PaintEventArgs _pea;

    public BasicWinFormsGraphicsTests()
    {
        _basicWinFormsGraphics = new BasicWinFormsGraphics();
        _state = new Cup[4];
        _pea = new PaintEventArgs(Graphics.FromImage(new Bitmap(100, 100)), new Rectangle());
    }

    [Fact]
    public void PaintBoard_StateLengthIsOdd_ThrowsArgumentException()
    {
        _state = new Cup[3];
        Assert.Throws<ArgumentException>(() => _basicWinFormsGraphics.PaintBoard(_state, _pea));
    }

    [Fact]
    public void PaintBoard_StateTypesMismatch_ThrowsArgumentException()
    {
        _state[0] = new Cup(0, 0, Cup.CupType.Regular);
        _state[1] = new Cup(0, 0, Cup.CupType.Regular);
        _state[2] = new Cup(0, 0, Cup.CupType.Regular);
        _state[3] = new Cup(0, 0, Cup.CupType.Home);
        Assert.Throws<ArgumentException>(() => _basicWinFormsGraphics.PaintBoard(_state, _pea));
    }

    [Fact]
    public void PaintBoard_ValidState_PaintsBoard()
    {
        _state[0] = new Cup(0, 0, Cup.CupType.Regular);
        _state[1] = new Cup(0, 0, Cup.CupType.Regular);
        _state[2] = new Cup(0, 0, Cup.CupType.Regular);
        _state[3] = new Cup(0, 0, Cup.CupType.Regular);
        _basicWinFormsGraphics.PaintBoard(_state, _pea);
        Assert.True(_basicWinFormsGraphics._cupLookup.Count > 0);
    }

    [Fact]
    public void CupIndexAt_PointInsideCup_ReturnsCupIndex()
    {
        _state[0] = new Cup(1, 0, Cup.CupType.Regular);
        _state[1] = new Cup(1, 0, Cup.CupType.Regular);
        _state[2] = new Cup(1, 0, Cup.CupType.Regular);
        _state[3] = new Cup(1, 0, Cup.CupType.Regular);
        _basicWinFormsGraphics.PaintBoard(_state, _pea);
        int index = _basicWinFormsGraphics.CupIndexAt(new Point(20, 20));
        Assert.True(index >= 0);
    }

    [Fact]
    public void CupIndexAt_PointOutsideCup_ReturnsMinusOne()
    {
        _state[0] = new Cup(0, 0, Cup.CupType.Regular);
        _state[1] = new Cup(0, 0, Cup.CupType.Regular);
        _state[2] = new Cup(0, 0, Cup.CupType.Regular);
        _state[3] = new Cup(0, 0, Cup.CupType.Regular);
        _basicWinFormsGraphics.PaintBoard(_state, _pea);
        int index = _basicWinFormsGraphics.CupIndexAt(new Point(1000, 1000));
        Assert.Equal(-1, index);
    }
}
