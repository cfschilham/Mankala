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
        var factory = new MankalaRuleFactory();
        var form = new Form();
        form.Height = 500;
        form.Width = 800;
        var board = new Board(
            new Game(factory, new[] { new Player("one"), new Player("two") }),
            factory);
        board.Location = new Point(0, 0);
        board.Height = 500;
        board.Width = 800;
        form.Controls.Add(board);
        Application.Run(form);
        board.Invalidate();
    }
}