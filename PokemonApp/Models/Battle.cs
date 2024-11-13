using PokemonApp.Models;
using System;

public class Battle
{
    public Pokemon Pokemon1 { get; set; }
    public Pokemon Pokemon2 { get; set; }
    public int Pokemon1Health { get; set; } = 3;
    public int Pokemon2Health { get; set; } = 3;

    public string StartRound()
    {
        Random random = new Random();
        int pokemon1Attack = random.Next(1, 100);
        int pokemon2Attack = random.Next(1, 100);

        if (pokemon1Attack > pokemon2Attack)
        {
            Pokemon2Health--;
            return $"{Pokemon1.Nombre} wins this round!";
        }
        else if (pokemon2Attack > pokemon1Attack)
        {
            Pokemon1Health--;
            return $"{Pokemon2.Nombre} wins this round!";
        }
        else
        {
            return "It's a draw!";
        }
    }

    public bool IsBattleOver()
    {
        return Pokemon1Health == 0 || Pokemon2Health == 0;
    }
}
