using PokemonApp.Models;
using System;

public class Battle
{
    public Pokemon Pokemon1 { get; set; }
    public Pokemon Pokemon2 { get; set; }

    public string StartBattle()
    {
        Random random = new Random();
        int pokemon1Attack = random.Next(1, 100);
        int pokemon2Attack = random.Next(1, 100);

        if (pokemon1Attack > pokemon2Attack)
        {
            return $"{Pokemon1.Nombre} wins the battle with an attack power of {pokemon1Attack}!";
        }
        else if (pokemon2Attack > pokemon1Attack)
        {
            return $"{Pokemon2.Nombre} wins the battle with an attack power of {pokemon2Attack}!";
        }
        else
        {
            return "It's a draw! Both Pokémon have equal attack power!";
        }
    }
}
