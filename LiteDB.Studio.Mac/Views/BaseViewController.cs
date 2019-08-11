using System;
using Foundation;
using MvvmCross.Platforms.Mac.Views;
using MvvmCross.ViewModels;

namespace LiteDB.Studio.Mac.Views
{
    public class BaseViewController<TViewModel> : MvxViewController<TViewModel> where TViewModel : MvxViewModel
    {
        public BaseViewController()
        {
        }

        public BaseViewController(IntPtr handle) : base(handle)
        {
        }

        protected BaseViewController(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public BaseViewController(NSCoder coder) : base(coder)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ApplyStyling();
            ApplyBindings();
        }

        protected virtual void ApplyStyling()
        {
        }

        protected virtual void ApplyBindings()
        {
        }
    }
}