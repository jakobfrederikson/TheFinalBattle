public interface IAction
{
    public void PerformAction(Game game, Character character);
}

public class DoNothingAction : IAction
{
    public void PerformAction(Game game, Character character) => Console.WriteLine($"{character.Name} did NOTHING");
}

public class AttackAction : IAction
{
    public void PerformAction(Game game, Character character)
    {
        Character enemy = game.GetEnemyPartyFor(character).Characters[0];
        character.StandardAttack.Attack(enemy);
        Console.WriteLine($"{character.Name} used {character.StandardAttack.Name} on {enemy.Name}");
        Console.WriteLine($"{character.StandardAttack.Name} dealt {character.StandardAttack.Damage} to {enemy.Name}");

        int health = enemy.IsDead ? 0 : enemy.CurrentHP;
        Console.WriteLine($"{enemy.Name} is now at {health}/{enemy.MaxHP}.");

        // Check if enemy health == 0. If so, remove from party.
        if (enemy.IsDead)
        {
            Console.WriteLine($"{enemy.Name} has been slain!");
            game.GetEnemyPartyFor(character).Characters.Remove(enemy);
        }            
    }
}