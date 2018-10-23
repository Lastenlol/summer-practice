using System;
using Entity;
using Ninject;
using Reviews.BLL.Interface;

namespace Reviews
{
    class Program
    {
        private static IUserLogic _userLogic;
        private static IReviewLogic _reviewLogic;

        public static void Main()
        {
            NinjectCommon.NinjectCommon.Registration();

            _userLogic = NinjectCommon.NinjectCommon.Kernel.Get<IUserLogic>();
            _reviewLogic = NinjectCommon.NinjectCommon.Kernel.Get<IReviewLogic>();

            var userIllario = new User {Id = 3, Name = "Illario", Password = "123", Role = 3};
            _userLogic.AddUser(userIllario);
            _reviewLogic.AddReview(userIllario.Id, new Review {Id = 2, Name = "Google Play", Comment = "OK"});

            Console.WriteLine("Users: ");
            foreach (var item in _userLogic.GetUsers())
            {
                Console.WriteLine($"{item.Id} : {item.Name} : {item.Role} ");
            }

            Console.WriteLine();

            Console.WriteLine("Reviews: ");
            foreach (var item in _reviewLogic.GetReviews())
            {
                Console.WriteLine($"{item.Id} : {item.Name} : {item.Comment}");
            }

            Console.WriteLine();

            foreach (var item in _reviewLogic.GetReviewsForUser(1))
            {
                Console.WriteLine($"{item.Name} : {item.Comment}");
            }

            _reviewLogic.AddReview(userIllario.Id, new Review {Id = 1, Name = "App store", Comment = "Not OK"});

            Console.WriteLine("Reviews: ");
            foreach (var item in _reviewLogic.GetReviews())
            {
                Console.WriteLine($"{item.Id} : {item.Name} : {item.Comment}");
            }


            _userLogic.UpdateUserForAdmin(1, 2);
            _userLogic.UpdateUserForUsers(1, "Petro");

            _reviewLogic.UpdateReview(1, "App store", "Now it's OK");

            _userLogic.DeleteUser(4);
            _reviewLogic.DeleteReview(3);

            var user = _userLogic.GetUserById(1);

            Console.WriteLine(user.Name);

            var review = _reviewLogic.GetReviewById(1);

            Console.WriteLine(review.Name);


            Console.ReadKey();
        }
    }
}