namespace LifeGame.Test;

public class PrinterTest
{
    [Fact]
    public void PrintTest()
    {
        var board = Examples.Octagon;
        var printer = new Printer(8, 8);
        var stringRepresentation = """
            □□□■■□□□
            □□■□□■□□
            □■□□□□■□
            ■□□□□□□■
            ■□□□□□□■
            □■□□□□■□
            □□■□□■□□
            □□□■■□□□
            """;

        Assert.Equal(stringRepresentation, printer.PrintBoard(board));
    }
}
