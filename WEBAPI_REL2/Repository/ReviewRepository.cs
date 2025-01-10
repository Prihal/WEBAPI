using WEBAPI_REL2.Data;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context; 
        }

        public bool CreateReview(Review review)
        {
           _context.Reviews.Add(review);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _context.Remove(review);
            return Save();
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviewByPokemon(int id)
        {
            return _context.Reviews.Where(c => c.Pokemons.Id == id).ToList();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.OrderBy(p => p.Id).ToList();
        }

        public bool ReviewExist(int id)
        {
            return _context.Reviews.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved=_context.SaveChanges();
            return saved>0?true:false;
        }

        public bool UpdateReview(Review review)
        {
            _context.Update(review);
            return Save();
        }
    }
}
