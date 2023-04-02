Console.WriteLine("1 - Player vs Player");
Console.WriteLine("2 - Player vs Computer");
Console.WriteLine("3 - Computer vs Computer");
Console.Write("What mode would you like to play? ");
int input = int.Parse(Console.ReadLine());
List<IPlayer> players = input switch
{
    1 => PlayerVersusPlayer(),
    2 => PlayerVersusComputer(),
    3 => ComputerVsComputer(),
    _ => throw new Exception()
};
Party heroes = new Party(players[0]);
Party monsterParty1 = new Party(players[1]);
Party monsterParty2 = new Party(players[1]);
Party monsterParty3 = new Party(players[1]);

// Add Items to parties
heroes.Items.Add(new HealthPotion());
heroes.Items.Add(new HealthPotion());
heroes.Items.Add(new HealthPotion());
monsterParty1.Items.Add(new HealthPotion());
monsterParty2.Items.Add(new HealthPotion());
monsterParty3.Items.Add(new HealthPotion());

// Add characters to parties
if (input != 3)
{
    Console.Write("What is your name? ");
    string name = Console.ReadLine();
    heroes.Characters.Add(new TrueProgrammer(name));
}
else
    heroes.Characters.Add(new TrueProgrammer("TrueProgrammer"));

monsterParty1.Characters.Add(new Skeleton());
monsterParty2.Characters.Add(new Skeleton());
monsterParty2.Characters.Add(new Skeleton());
monsterParty3.Characters.Add(new TheUncodedOne());

MonsterPartyManager monsterManager = new MonsterPartyManager();
monsterManager.MonsterList.Add(monsterParty1);
monsterManager.MonsterList.Add(monsterParty2);
monsterManager.MonsterList.Add(monsterParty3);
Game game = new Game(heroes, monsterManager);
game.Run();

List<IPlayer> PlayerVersusPlayer () => new List<IPlayer>() { new HumanPlayer(), new HumanPlayer() };
List<IPlayer> PlayerVersusComputer() => new List<IPlayer>() { new HumanPlayer(), new ComputerPlayer() };
List<IPlayer> ComputerVsComputer() => new List<IPlayer>() { new ComputerPlayer(), new ComputerPlayer() };