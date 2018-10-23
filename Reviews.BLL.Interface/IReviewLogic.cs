using System.Collections.Generic;
using Entity;

namespace Reviews.BLL.Interface
{
    public interface IReviewLogic
    {
        bool AddReview(int userId, Review review);
        IEnumerable<Review> GetReviews();
        Review GetReviewById(int id);
        bool UpdateReview(int id, string name, string comment);
        bool DeleteReview(int id);
        IEnumerable<Review> GetReviewsForUser(int id);
    }
}