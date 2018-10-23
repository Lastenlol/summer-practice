using BLL.Logging;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reviews.BLL.Interface;
using Reviews.DAL.Interface;

namespace Reviews.BLL.Logic
{
    public class ReviewLogic : IReviewLogic
    {
        private readonly IReviewDao _reviewDao;

        public ReviewLogic(IReviewDao reviewDao)
        {
            _reviewDao = reviewDao;
        }

        public bool AddReview(int userId, Review review)
        {
            _reviewDao.AddReview(userId, review);

            Logger.Log($"Added review {review.Id}");

            return true;
        }

        public IEnumerable<Review> GetReviews()
        {
            Logger.Log($"Accessed reviews");

            return _reviewDao.GetReviews().ToList();
        }

        public Review GetReviewById(int id)
        {
            Logger.Log($"Accessed review {id}");

            return _reviewDao.GetReviewById(id);
        }

        public bool UpdateReview(int id, string name, string comment)
        {
            _reviewDao.UpdateReview(id, name, comment);

            Logger.Log($"Updated review {id}");

            return true;
        }

        public bool DeleteReview(int id)
        {
            _reviewDao.DeleteReview(id);

            Logger.Log($"Deleted review {id}");

            return true;
        }

        public IEnumerable<Review> GetReviewsForUser(int id)
        {
            Logger.Log($"Accessed reviews for user {id}");

            return _reviewDao.GetReviewsForUsers(id);
        }
    }
}
