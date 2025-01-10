using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using WEBAPI_REL2.Data;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly AppDbContext _context;

        public OwnerRepository(AppDbContext context)
        {
            _context=context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);

            return Save();

        }

        public bool DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            return Save();
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(p => p.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfPokemoon(int pokeid)
        {
            return _context.Pokemonowners.Where(c => c.Pokemons.Id == pokeid).Select(o=>o.Owners).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(p => p.Id).ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return _context.Pokemonowners.Where(c => c.Owners.Id == ownerId).Select(p => p.Pokemons).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(p=>p.Id == ownerId);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }
    }
}
