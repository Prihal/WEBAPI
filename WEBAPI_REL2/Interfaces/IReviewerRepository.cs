using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> reviewers();
        Reviewer Reviewer(int id);
        bool ReviewExist(int id);

        ICollection<Reviewer> GetReviewByViewer(int id);

        bool CreateReviewer(Reviewer id);

        bool UpdateReviewer(Reviewer reviewer);

        bool DeleteReviewer(Reviewer reviewer);
        bool Save();

      

    }
}
