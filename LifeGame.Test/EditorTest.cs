namespace LifeGame.Test;

public class EditorTest
{
    [Fact]
    public void TruncateTest()
    {
        {
            // [OO..]  =>  [O]
            // [OO..]
            // [....]
            var truncated = Patterns.Block.Truncate(1, 1);
            Assert.Equal(new([new(0, 0)]), truncated);
        }

        {
            // [...OO...]      [...OO.]
            // [..O..O..]  =>  [..O..O]
            // [.O....O.]      [.O....]
            // [O......O]
            // [O......O]
            // [.O....O.]
            // [..O..O..]
            // [...OO...]
            var truncated = Patterns.Octagon.Truncate(6, 3);
            Assert.Equal(new([new(3, 0), new(4, 0), new(2, 1), new(5, 1), new(1, 2)]), truncated);
        }
    }

    [Fact]
    public void TranslateTest()
    {
        // [OO..]      [....]
        // [OO..]  =>  [..OO]
        // [....]      [..OO]
        var translated = Patterns.Block.Translate(2, 1);
        Assert.Equal(new([new(2, 1), new(3, 1), new(2, 2), new(3, 2)]), translated);
    }

    [Fact]
    public void RotateTest()
    {
        // [.O..]      [....]
        // [.O..]  =>  [OOO.]
        // [.O..]      [....]
        var blinker = Patterns.Blinker;
        Assert.Equal(blinker.Advance(), blinker.Rotate(1, 1));

        // [OO..]      [.OO.]      [....]      [....]      [OO..]
        // [OO..]  =>  [.OO.]  =>  [.OO.]  =>  [OO..]  =>  [OO..]
        // [....]      [....]      [.OO.]      [OO..]      [....]
        var block = Patterns.Block;
        Assert.Equal(block.Translate(1, 0), block.Rotate(1, 1));
        Assert.Equal(block.Translate(1, 1), block.Rotate(1, 1).Rotate(1, 1));
        Assert.Equal(block.Translate(0, 1), block.Rotate(1, 1).Rotate(1, 1).Rotate(1, 1));
        Assert.Equal(block, block.Rotate(1, 1).Rotate(1, 1).Rotate(1, 1).Rotate(1, 1));

        // [...OO....]      [....OO...]
        // [..O..O...]      [...O..O..]
        // [.O....O..]      [..O....O.]
        // [O......O.]  =>  [.O......O]
        // [O...*..O.]      [.O..*...O]
        // [.O....O..]      [..O....O.]
        // [..O..O...]      [...O..O..]
        // [...OO....]      [....OO...]
        var octagon = Patterns.Octagon;
        Assert.Equal(octagon, octagon.Rotate(4, 4).Translate(-1, 0));
    }

    [Fact]
    public void TransposeTest()
    {
        var blinker = Patterns.Blinker;
        Assert.Equal(blinker.Advance(), blinker.Transpose());

        var clock = Patterns.Clock;
        Assert.Equal(clock.Advance(), clock.Transpose());
    }

    [Fact]
    public void NormalizeTest()
    {
        // [.O..]      [O...]
        // [.O..]  =>  [O...]
        // [.O..]      [O...]
        var vertical = Patterns.Blinker;
        Assert.Equal(new([new(1, 0), new(1, 1), new(1, 2)]), vertical);
        Assert.Equal(new([new(0, 0), new(0, 1), new(0, 2)]), vertical.Normalize());

        var horizontal = vertical.Advance();
        Assert.Equal(new([new(0, 1), new(1, 1), new(2, 1)]), horizontal);
        Assert.Equal(new([new(0, 0), new(1, 0), new(2, 0)]), horizontal.Normalize());

        var after = Patterns.Blinker.Normalize().Advance();
        Assert.Equal(new([new(-1, 1), new(0, 1), new(1, 1)]), after);
        Assert.Equal(new([new(0, 0), new(1, 0), new(2, 0)]), after.Normalize());
    }

    [Fact]
    public void MergeTest()
    {
        // [.O..]     [....]     [.O..]
        // [.O..]  +  [OOO.]  =  [OOO.]
        // [.O..]     [....]     [.O..]
        var merged = Patterns.Blinker.Merge(Patterns.Blinker.Advance());
        Assert.Equal(new([new(1, 0), new(0, 1), new(1, 1), new(2, 1), new(1, 2)]), merged);
    }

    [Fact]
    public void ExceptTest()
    {
        // [.O..]     [....]     [.O..]
        // [.O..]  -  [OOO.]  =  [....]
        // [.O..]     [....]     [.O..]
        var except = Patterns.Blinker.Except(Patterns.Blinker.Advance());
        Assert.Equal(new([new(1, 0), new(1, 2)]), except);
    }

    [Fact]
    public void FillTest()
    {
        var empty = Board.Empty;

        var blinker = empty.Fill(new(1, 0), new(1, 2));

        Assert.Equal(Patterns.Blinker, blinker);

        var galaxy = empty
            .Fill(new(0, 0), new(5, 1))
            .Fill(new(7, 0), new(8, 5))
            .Fill(new(8, 7), new(3, 8))
            .Fill(new(1, 8), new(0, 3));

        Assert.Equal(Patterns.Galaxy, galaxy);
    }
}
