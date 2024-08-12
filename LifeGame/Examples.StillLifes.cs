namespace LifeGame;

public static partial class Examples
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
}
