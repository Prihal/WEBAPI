using Microsoft.Identity.Client;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Interfaces
{
    public interface IPokimonRepository
    {
        ICollection<Pokemon> GetPokimons();

        public Pokemon GetPokemon(int id);
        public Pokemon GetPokemon(string name);

        decimal GetPokemonRating(int pokeid);
        bool PokemonExixst(int pokeid);

        bool CreatePokemon(int oid,int cid ,Pokemon pokemon);

        bool UpdatePokemon(Pokemon pokemon);

        bool DeletePokemon(Pokemon pokemon);
        bool Save();

    }
}
