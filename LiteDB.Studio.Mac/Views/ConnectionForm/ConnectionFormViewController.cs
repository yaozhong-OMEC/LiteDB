using System;
using Foundation;
using LiteDB.Studio.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Presenters.Attributes;
using MvvmCross.Platforms.Mac.Views;

namespace LiteDB.Studio.Mac.Views.ConnectionForm
{
    [MvxFromStoryboard(StoryboardName = "ConnectionForm")]
    [MvxSheetPresentation(WindowIdentifier = "Root")]
    public partial class ConnectionFormViewController : BaseViewController<ConnectionFormViewModel>
    {
        public ConnectionFormViewController()
        {
        }

        public ConnectionFormViewController(IntPtr handle) : base(handle)
        {
        }

        protected ConnectionFormViewController(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public ConnectionFormViewController(NSCoder coder) : base(coder)
        {
        }

        protected override void ApplyBindings()
        {
            var set = this.CreateBindingSet<ConnectionFormViewController, ConnectionFormViewModel>();

            set.Bind(cancelButton).To(vm => vm.CancelCommand);
            set.Bind(confirmButton).To(vm => vm.ConfirmCommand);
            
            set.Apply();
        }
    }
}
