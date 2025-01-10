using WEBAPI_REL2.Data;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly AppDbContext _context;

        public ReviewerRepository(AppDbContext context)
        {
            _context=context;
        }

       

        public bool CreateReviewer(Reviewer id)
        {
            _context.Add(id);
            return Save();
        }

        public bool DeleteReviewer(Reviewer reviewer)
        {
           _context.Remove(reviewer);
            return Save();
        }

        public ICollection<Reviewer> GetReviewByViewer(int id)
        {
            return _context.Reviews.Where(c => c.Reviewers.Id == id).Select(o => o.Reviewers).ToList();
        }

        public Reviewer Reviewer(int id)
        {
            return _context.Reviewers.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Reviewer> reviewers()
        {
            return _context.Reviewers.OrderBy(p => p.Id).ToList();
        }

        public bool ReviewExist(int id)
        {
            return _context.Reviewers.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved=_context.SaveChanges();
            return saved>0?true:false;
        }

        public bool UpdateReviewer(Reviewer reviewer)
        {
           _context.Update(reviewer);
            return Save();

        }
    }
}
