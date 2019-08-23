using System.Linq;
using System.Threading.Tasks;
using AppKit;
using MvvmCross.Platforms.Mac.Presenters;
using MvvmCross.Platforms.Mac.Views;
using MvvmCross.ViewModels;

namespace LiteDB.Studio.Mac.Presenters
{
    public class CustomMacViewPresenter : MvxMacViewPresenter
    {
        public CustomMacViewPresenter(INSApplicationDelegate applicationDelegate) : base(applicationDelegate)
        {
        }

        public override Task<bool> Close(IMvxViewModel viewModel)
        {
            var currentWindows = Windows;
            for (var i = currentWindows.Count - 1; i >= 0; i--)
            {
                var window = currentWindows[i];

                // Fix / Work-around for runtime-crash
                // TODO: report this on the MvvmCross repository or find definitive fix
                if (window.ContentViewController == null)
                {
                    continue;
                }

                // if toClose is a sheet or modal
                if (window.ContentViewController.PresentedViewControllers.Any())
                {
                    var modal = window.ContentViewController.PresentedViewControllers
                        .Select(v => v as MvxViewController)
                        .FirstOrDefault(v => v.ViewModel == viewModel);

                    if (modal != null)
                    {
                        window.ContentViewController.DismissViewController(modal);
                        return Task.FromResult(true);
                    }
                }
                // if toClose is a tab
                if (window.ContentViewController is IMvxTabViewController tabViewController && tabViewController.CloseTabView(viewModel))
                {
                    return Task.FromResult(true);
                }

                // toClose is a content
                if (window.ContentViewController is MvxViewController controller && controller.ViewModel == viewModel)
                {
                    window.Close();
                    return Task.FromResult(true);
                }
            }
            return Task.FromResult(true);
        }
    }
}