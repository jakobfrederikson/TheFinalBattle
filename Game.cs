﻿public class Game
{
    private Party _heroes { get; }
    private MonsterPartyManager _monsterManager { get; } = new MonsterPartyManager();
    private Party _monsters { get; set; }

    public Game (Party heroes, MonsterPartyManager monsterManager)
    {
        _heroes = heroes;
        _monsterManager = monsterManager;
    }

    public void Run()
    {
        bool isOver = false;
        while (!isOver)
        {
            _monsters = _monsterManager.MonsterList[0];
            foreach (var party in new[] { _heroes, _monsters })
            {
                foreach (var character in party.Characters)
                {
                    // Display who's turn it is.
                    Console.WriteLine();
                    Console.WriteLine($"It is {character.Name}'s turn.");

                    // Decide characters action for the round.
                    IAction action = party.Player.ChooseAction(this, character);
                    action.PerformAction(this, character);

                    // Check win condition
                    if (_monsterManager.AllPartiesDead() || _heroes.PartyIsDead)
                    {
                        isOver = true;
                        break;
                    }
                    
                    // Check if a monster party has died.
                    // It will get reasigned another party at the start of the while loop.
                    if (_monsters.PartyIsDead)
                        _monsterManager.MonsterList.Remove(_monsters);

                    if (isOver) break;
                }
            }
        }   
        
        if (GetWinningParty() == _heroes)
            Console.WriteLine("The heroes have won! The lands have been cleansed of The Uncoded one!");
        else
            Console.WriteLine("The monsters have won! The Uncoded One reigns supreme over the lands!");
    }

    public Party GetPartyFor (Character c) => _heroes.Characters.Contains(c) ? _heroes : _monsters;
    public Party GetEnemyPartyFor (Character c) => _heroes.Characters.Contains(c) ? _monsters : _heroes;
    public Party GetWinningParty() => _heroes.PartyIsDead ? _monsters : _heroes; // Only use when isOver == true
}