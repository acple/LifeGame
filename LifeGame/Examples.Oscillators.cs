namespace LifeGame;

public static partial class Examples
{
    public static Board Blinker =>
        new([new(1, 0), new(1, 1), new(1, 2)]);

    public static Board Toad =>
        new([new(2, 0), new(0, 1), new(3, 1), new(0, 2), new(3, 2), new(1, 3)]);

    public static Board Beacon =>
        new([new(0, 0), new(1, 0), new(0, 1), new(3, 2), new(2, 3), new(3, 3)]);

    public static Board Clock =>
        new([new(2, 0), new(0, 1), new(2, 1), new(1, 2), new(3, 2), new(1, 3)]);

    public static Board Octagon =>
        new([
            new(3, 0), new(4, 0),
            new(2, 1), new(5, 1),
            new(1, 2), new(6, 2),
            new(0, 3), new(7, 3),
            new(0, 4), new(7, 4),
            new(1, 5), new(6, 5),
            new(2, 6), new(5, 6),
            new(3, 7), new(4, 7),
        ]);

    public static Board Galaxy =>
        new([
            new(0, 0), new(1, 0), new(2, 0), new(3, 0), new(4, 0), new(5, 0), new(7, 0), new(8, 0),
            new(0, 1), new(1, 1), new(2, 1), new(3, 1), new(4, 1), new(5, 1), new(7, 1), new(8, 1),
            new(7, 2), new(8, 2),
            new(0, 3), new(1, 3), new(7, 3), new(8, 3),
            new(0, 4), new(1, 4), new(7, 4), new(8, 4),
            new(0, 5), new(1, 5), new(7, 5), new(8, 5),
            new(0, 6), new(1, 6),
            new(0, 7), new(1, 7), new(3, 7), new(4, 7), new(5, 7), new(6, 7), new(7, 7), new(8, 7),
            new(0, 8), new(1, 8), new(3, 8), new(4, 8), new(5, 8), new(6, 8), new(7, 8), new(8, 8),
        ]);
}
