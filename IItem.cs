public interface IItem
{
    public string Name { get; }
    public void UseItem(Game game, Character character);
}

public class HealthPotion : IItem
{
    public string Name { get; } = "HEALTH POTION";

    public void UseItem(Game game, Character character)
    {

    }
}