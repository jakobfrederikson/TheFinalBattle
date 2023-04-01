public class MonsterPartyManager
{
    public List<Party> MonsterList { get; set; } = new List<Party>();

    // If a party is still alive, return false. Else, return true.
    public bool AllPartiesDead()
    {
        foreach (Party p in MonsterList)
        {
            if (p.PartyIsDead == false)
                return false;
        }
        return true;
    }
}

