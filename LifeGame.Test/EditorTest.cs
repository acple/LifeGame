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
            var truncated = Examples.Block.Truncate(1, 1);
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
            var truncated = Examples.Octagon.Truncate(6, 3);
            Assert.Equal(new([new(3, 0), new(4, 0), new(2, 1), new(5, 1), new(1, 2)]), truncated);
        }
    }

    [Fact]
    public void TranslateTest()
    {
        // [OO..]      [....]
        // [OO..]  =>  [..OO]
        // [....]      [..OO]
        var translated = Examples.Block.Translate(2, 1);
        Assert.Equal(new([new(2, 1), new(3, 1), new(2, 2), new(3, 2)]), translated);
    }

    [Fact]
    public void RotateTest()
    {
        // [.O..]      [....]
        // [.O..]  =>  [OOO.]
        // [.O..]      [....]
        var blinker = Examples.Blinker;
        Assert.Equal(blinker.Advance(), blinker.Rotate());

        var octagon = Examples.Octagon;
        Assert.Equal(octagon, octagon.Rotate());
    }

    [Fact]
    public void FlipTest()
    {
        var blinker = Examples.Blinker;
        Assert.Equal(blinker.Advance(), blinker.Flip());

        var clock = Examples.Clock;
        Assert.Equal(clock.Advance(), clock.Flip());
    }

    [Fact]
    public void NormalizeTest()
    {
        // [.O..]      [O...]
        // [.O..]  =>  [O...]
        // [.O..]      [O...]
        var vertical = Examples.Blinker;
        Assert.Equal(new([new(1, 0), new(1, 1), new(1, 2)]), vertical);
        Assert.Equal(new([new(0, 0), new(0, 1), new(0, 2)]), vertical.Normalize());

        var horizontal = vertical.Advance();
        Assert.Equal(new([new(0, 1), new(1, 1), new(2, 1)]), horizontal);
        Assert.Equal(new([new(0, 0), new(1, 0), new(2, 0)]), horizontal.Normalize());

        var after = Examples.Blinker.Normalize().Advance();
        Assert.Equal(new([new(-1, 1), new(0, 1), new(1, 1)]), after);
        Assert.Equal(new([new(0, 0), new(1, 0), new(2, 0)]), after.Normalize());
    }

    [Fact]
    public void MergeTest()
    {
        // [.O..]     [....]     [.O..]
        // [.O..]  +  [OOO.]  =  [OOO.]
        // [.O..]     [....]     [.O..]
        var merged = Examples.Blinker.Merge(Examples.Blinker.Advance());
        Assert.Equal(new([new(1, 0), new(0, 1), new(1, 1), new(2, 1), new(1, 2)]), merged);
    }

    [Fact]
    public void ExceptTest()
    {
        // [.O..]     [....]     [.O..]
        // [.O..]  -  [OOO.]  =  [....]
        // [.O..]     [....]     [.O..]
        var except = Examples.Blinker.Except(Examples.Blinker.Advance());
        Assert.Equal(new([new(1, 0), new(1, 2)]), except);
    }
}
