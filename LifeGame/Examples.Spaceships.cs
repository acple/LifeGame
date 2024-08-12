namespace LifeGame;

public static partial class Examples
{
    public static Board Glider =>
        new([new(1, 0), new(2, 1), new(0, 2), new(1, 2), new(2, 2)]);

    public static Board Spaceship =>
        new([
            new(2, 0), new(0, 1), new(4, 1), new(5, 2), new(0, 3), new(5, 3),
            new(1, 4), new(2, 4), new(3, 4), new(4, 4), new(5, 4)
        ]);

    public static Board LightweightSpaceship =>
        new([new(0, 0), new(3, 0), new(4, 1), new(0, 2), new(4, 2), new(1, 3), new(2, 3), new(3, 3), new(4, 3)]);
}
