using Ninject;
using Reviews.BLL.Interface;
using Reviews.BLL.Logic;
using Reviews.DAL.DAO;
using Reviews.DAL.Interface;

namespace NinjectCommon
{
    public static class NinjectCommon
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Kernel => _kernel;

        public static void Registration()
        {
            _kernel.Bind<IUserDao>().To<UserDao>();
            _kernel.Bind<IUserLogic>().To<UserLogic>();

            _kernel.Bind<IReviewDao>().To<ReviewDao>();
            _kernel.Bind<IReviewLogic>().To<ReviewLogic>();
        }
    }
}
