using System.Collections.Generic;
using Entity;

namespace Reviews.DAL.Interface
{
    public interface IReviewDao
    {
        void AddReview(int userId, Review review);
        IEnumerable<Review> GetReviews();
        Review GetReviewById(int id);
        int UpdateReview(int id, string name, string comment);
        int DeleteReview(int id);
        IEnumerable<Review> GetReviewsForUsers(int id);
    }
}