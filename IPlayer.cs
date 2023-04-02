public interface IPlayer
{
    public IAction ChooseAction(Game game, Character character);
}

public class ComputerPlayer : IPlayer
{
    public IAction ChooseAction(Game game, Character character)
    {
        return new AttackAction();
    }
}

public class HumanPlayer : IPlayer
{
    public IAction ChooseAction(Game game, Character character)
    {
        Console.WriteLine($"1 - Standard Attack ({character.StandardAttack.Name})");
        Console.WriteLine($"2 - Use Item ({game.GetPartyFor(character).Items.Count} items in inventory)");
        Console.WriteLine("3 - Do Nothing");
        
        Console.Write("Choose an action: ");
        // Take [ Use Item] into a seperate menu, and number 2 on the switch statement can return whatever item was chosen.
        // For now, we assume every itme is a health potion.

        return int.Parse(Console.ReadLine()) switch
        {
            1 => new AttackAction(),
            2 => new HealthPotionAction(),
            3 => new DoNothingAction(),
            _ => new DoNothingAction()
        };
    }
}