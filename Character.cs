public abstract class Character
{
    public abstract string Name { get; }
    public abstract IAttack StandardAttack { get; set; }
    public abstract int MaxHP { get; }
    public abstract int CurrentHP { get; set; }
    public bool IsDead => CurrentHP <= 0;
}

public class Skeleton : Character
{
    public override string Name { get; } = "SKELETON";
    public override IAttack StandardAttack { get; set; } = new BoneCrunch();
    public override int MaxHP { get; } = 5;
    public override int CurrentHP { get; set; } = 5;
}

public class TrueProgrammer : Character
{
    public override string Name { get; }
    public override IAttack StandardAttack { get; set; } = new Punch();
    public override int MaxHP { get; } = 25;
    public override int CurrentHP { get; set; } = 25;

    public TrueProgrammer(string name) => Name = name;
}

public class TheUncodedOne : Character
{
    public override string Name { get; } = "THE UNCODED ONE";
    public override IAttack StandardAttack { get; set; } = new Unraveling();
    public override int MaxHP { get; } = 15;
    public override int CurrentHP { get; set; } = 15;
}