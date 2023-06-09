﻿public interface IAction
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

        Console.Write($"{character.Name} used ");
        ColouredConsole.Write($"{character.StandardAttack.Name} ", ConsoleColor.Yellow);
        Console.WriteLine($"on {enemy.Name}");

        Console.Write($"{character.StandardAttack.Name} dealt ");
        ColouredConsole.Write($"{character.StandardAttack.Damage} ", ConsoleColor.Yellow);
        Console.WriteLine($"to {enemy.Name}");

        int health = enemy.IsDead ? 0 : enemy.CurrentHP;
        Console.WriteLine($"{enemy.Name} is now at {health}/{enemy.MaxHP}.");

        // Check if enemy health == 0. If so, remove from party.
        if (enemy.IsDead)
        {
            ColouredConsole.WriteLine($"{enemy.Name} has been slain!", ConsoleColor.DarkRed);
            game.GetEnemyPartyFor(character).Characters.Remove(enemy);
        }            
    }
}

public class HealthPotionAction : IAction
{
    public void PerformAction(Game game, Character character)
    {
        List<IItem> inventory = game.GetPartyFor(character).Items;
        HealthPotion hp = inventory.OfType<HealthPotion>().First();
        hp.UseItem(game, character);

        Console.Write($"{character.Name} used ");
        ColouredConsole.Write($"{hp.Name} ", ConsoleColor.Magenta);
        Console.WriteLine("to restore 10 HP!");

        // Remove the item from the party inventory
        if (inventory.Remove(hp))
            ColouredConsole.WriteLine($"Sucessfully removed {hp}", ConsoleColor.Blue);
        else
            ColouredConsole.WriteLine($"Was not able to remove {hp}!", ConsoleColor.Blue);
    }
}