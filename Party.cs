public class Party
{
    public IPlayer Player { get; }
    public List<Character> Characters { get; set; } = new List<Character>();
    public bool PartyIsDead => Characters.Count <= 0;

    public Party(IPlayer player) => Player = player;
}