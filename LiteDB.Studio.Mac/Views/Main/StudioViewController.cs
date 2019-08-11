using System;
using LiteDB.Studio.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Presenters.Attributes;
using MvvmCross.Platforms.Mac.Views;

namespace LiteDB.Studio.Mac.Views.Main
{
    [MvxFromStoryboard("Studio")]
    [MvxWindowPresentation(Identifier = "Studio")]
    public partial class StudioViewController : BaseViewController<StudioViewModel>
    {
        public StudioViewController()
        {
        }

        public StudioViewController(IntPtr handle) : base(handle)
        {
        }

        protected override void ApplyBindings()
        {
            var set = this.CreateBindingSet<StudioViewController, StudioViewModel>();

            set.Bind(TestButton).To(vm => vm.OpenConnectionFormModalCommand);

            set.Apply();
        }
    }
}