using System.Collections.Generic;

namespace PokemonApp.Models
{
    public class CreateRequest
    {
        public string PokemonName { get; set; } // Nombre del Pokémon seleccionado
        public string Description { get; set; } // Descripción del problema
        public string AssignedNurse { get; set; } // Enfermera asignada
        public List<Pokemon> Pokemons { get; set; } // Lista de Pokémon disponibles
        public List<Nurse> Nurses { get; set; } // Lista de enfermeras disponibles
    }
}
