namespace Mankala;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var gsd = new GameSettingsDialog();
        DialogResult res = gsd.ShowDialog();
        if (res != DialogResult.OK) throw new Exception();
        IRuleFactory factory = new MankalaRuleFactory(gsd.CupsAmount, gsd.StartingPebbles);
        switch (gsd.Variant)
        {
            case "Wari":
                factory = new WariRuleFactory(gsd.CupsAmount, gsd.StartingPebbles);
                break;
            case "Wankala":
                factory = new WankalaRuleFactory(gsd.CupsAmount, gsd.StartingPebbles);
                break;
        }
        var form = new Form();
        form.Height = 500;
        form.Width = 800;
        var board = new Board(
            new Game(factory, new[] { new Player(gsd.Player1Name), new Player(gsd.Player2Name) }),
            factory);
        board.Location = new Point(0, 0);
        board.Height = 500;
        board.Width = 800;
        form.Controls.Add(board);
        Application.Run(form);
        board.Invalidate();
    }
}