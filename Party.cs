public class Party
{
    public IPlayer Player { get; }
    public List<Character> Characters { get; set; } = new List<Character>();
    public List<IItem> Items { get; set; } = new List<IItem>();
    public bool PartyIsDead => Characters.Count <= 0;

    public Party(IPlayer player) => Player = player;
}