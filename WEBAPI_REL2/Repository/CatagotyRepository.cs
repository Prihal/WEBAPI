using Microsoft.EntityFrameworkCore.Diagnostics;
using WEBAPI_REL2.Data;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Repository
{
    public class CatagotyRepository : ICatagoryRepository
    {
        private readonly AppDbContext _context;

        public CatagotyRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool CreateCategory(Category category)
        {
           _context.Add(category);
           
            return Save();
         
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved>0?true:false;
        }

        public bool UpdateCategory(Category category)
        {
           _context.Update(category);
            return Save();

        }

        bool ICatagoryRepository.CatagoryExist(int id)
        {
            return _context.Categorys.Any(c => c.Id == id);
        }

        object ICatagoryRepository.GetCatagory()
        {
            throw new NotImplementedException();
        }

        ICollection<Category> ICatagoryRepository.GetCategories()
        {
            return _context.Categorys.ToList();
        }

        Category ICatagoryRepository.GetCategory(int id)
        {
            return _context.Categorys.Where(e => e.Id == id).FirstOrDefault();
        }

        ICollection<Pokemon> ICatagoryRepository.GetPokemonByCatogory(int cid)
        {
            return _context.PokemonCatagories.Where(e => e.c_id == cid).Select(c => c.Pokemons).ToList();
        }
    }
}
