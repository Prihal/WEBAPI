using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Interfaces
{
    public interface ICatagoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCatogory(int cid);

        bool CatagoryExist(int id);
        object GetCatagory();

        bool CreateCategory(Category category);

        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);

        bool Save();
    }
}
