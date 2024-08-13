using LifeGame;

var parser = new PlaintextParser();

var source = """
    !Name: Gosper glider gun
    !Author: Bill Gosper
    !The first known gun and the first known finite pattern with unbounded growth.
    !www.conwaylife.com/wiki/index.php?title=Gosper_glider_gun
    ........................O
    ......................O.O
    ............OO......OO............OO
    ...........O...O....OO............OO
    OO........O.....O...OO
    OO........O...O.OO....O.O
    ..........O.....O.......O
    ...........O...O
    ............OO
    """;

var board = parser.Parse(source);

var runner = new ConsoleRunner(36, 20);

await runner.RunGame(board);
