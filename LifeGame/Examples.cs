namespace LifeGame;

public static class Examples
{
    public static Board Block =>
        new([new(0, 0), new(0, 1), new(1, 0), new(1, 1)]);

    public static Board BeeHive =>
        new([new(1, 0), new(2, 0), new(0, 1), new(3, 1), new(1, 2), new(2, 2)]);

    public static Board Loaf =>
        new([new(1, 0), new(2, 0), new(0, 1), new(3, 1), new(1, 2), new(3, 2), new(2, 3)]);

    public static Board Boat =>
        new([new(0, 0), new(0, 1), new(1, 0), new(2, 1), new(1, 2)]);

    public static Board Tub =>
        new([new(1, 0), new(0, 1), new(2, 1), new(1, 2)]);

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
}
