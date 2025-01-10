using Microsoft.EntityFrameworkCore;
using WEBAPI_REL2.Data;
using WEBAPI_REL2.Dto;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Repository
{
    public class PokimonRepository : IPokimonRepository
    {
        private readonly AppDbContext _context;

        public PokimonRepository(AppDbContext context)
        {
            _context= context;
        }

        public bool CreatePokemon(int oid, int cid, Pokemon pokemon)
        {
           var pokemonOwnerEntity=_context.Owners.Where(a=>a.Id == oid).FirstOrDefault();
            var catagory=_context.Categorys.Where(a=>a.Id==cid).FirstOrDefault();
            
            _context.Add(pokemon);
            _context.SaveChanges();
            var poc = _context.Pokemons.Where(a => a.Id == oid);
            var pokemonOwner = new Pokemonowner()
            {
                p_id = pokemon.Id,
                o_id = oid,
            };
            _context.Add(pokemonOwner);
            _context.SaveChanges();

            var pokemonCategory = new PokemonCatagory()
            {
                c_id = cid,
                p_id = pokemon.Id,
            };
            _context.Add(pokemonCategory);
            _context.SaveChanges();

            if (pokemon.Id == null)
            {
                return false;
            }
            return true;

        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }

        public ICollection<Pokemon> GetPokimons()
        {
            return _context.Pokemons.OrderBy(p=>p.Id).ToList();
           
        }

        public bool Save()
        {
            var saved= _context.SaveChanges();
            return saved>0?true:false;
        }

        public bool UpdatePokemon(Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }

        Pokemon IPokimonRepository.GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        Pokemon IPokimonRepository.GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        decimal IPokimonRepository.GetPokemonRating(int pokeid)
        {
            var review= _context.Reviews.Where(p => p.Id == pokeid );

            if (review.Count() <= 0)
                return 0;
            // return ((decimal)review.Sum(r=>r.Rating)/review.Count());
            return (review.Sum(r => r.rating) / review.Count())
 ;            

        }

      

        bool IPokimonRepository.PokemonExixst(int pokeid)
        {
            return _context.Pokemons.Any(p=>p.Id==pokeid);
        }
    }
}
