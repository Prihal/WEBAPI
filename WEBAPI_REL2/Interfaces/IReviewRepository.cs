using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int id);

        ICollection<Review> GetReviewByPokemon(int id);
        bool ReviewExist(int id);

        bool CreateReview(Review review);

        bool UpdateReview(Review review);

        bool DeleteReview(Review review);

        bool Save();
    }
}
