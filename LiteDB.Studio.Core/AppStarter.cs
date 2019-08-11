using System.Threading.Tasks;
using LiteDB.Studio.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace LiteDB.Studio.Core
{
    public class AppStarter : MvxAppStart
    {
        public AppStarter(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<StudioViewModel>();
        }
    }
}