public interface IAttack
{
    public string Name { get; }
    public int Damage { get; set; }
    public void Attack(Character c);
}

// Attack for the TrueProgrammer character.
public class Punch : IAttack
{
    public string Name { get; } = "PUNCH";
    public int Damage { get; set; } = 1;
    public void Attack(Character c) => c.CurrentHP -= Damage;
}

// Attack for the Skeleton character.
public class BoneCrunch : IAttack
{
    public string Name { get; } = "BONE CRUNCH";
    public int Damage { get; set; }
    public void Attack(Character c)
    {
        Damage = CalculateDamge();
        c.CurrentHP -= Damage;
    }

    private int CalculateDamge()
    {
        Random random = new Random();
        return random.Next(2) switch
        {
            0 => 0,
            1 => 1,
            _ => 0
        };
    }
}

// Attack for TheUncodedOne
public class Unraveling : IAttack
{
    public string Name { get; } = "UNRAVELING";
    public int Damage { get; set; }
    public void Attack(Character c)
    {
        Damage = CalculateDamge();
        c.CurrentHP -= Damage;
    }

    private int CalculateDamge()
    {
        Random random = new Random();

        return random.Next(3) switch
        {
            0 => 0,
            1 => 1,
            2 => 2,
            _ => 0
        };
    }
}