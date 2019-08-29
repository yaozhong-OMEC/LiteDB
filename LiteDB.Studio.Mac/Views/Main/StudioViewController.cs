using System;
using LiteDB.Studio.Core.Converters;
using LiteDB.Studio.Core.ViewModels;
using LiteDB.Studio.Mac.Converters;
using LiteDB.Studio.Mac.Views.Controls.CollectionOutlineView;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Presenters.Attributes;
using MvvmCross.Platforms.Mac.Views;

namespace LiteDB.Studio.Mac.Views.Main
{
    [MvxFromStoryboard(StoryboardName = "Studio")]
    [MvxWindowPresentation(WindowControllerName = nameof(StudioToolbarWindowController), StoryboardName = "Studio", Identifier = "Root")]
    public partial class StudioViewController : BaseViewController<StudioViewModel>
    {
        public StudioViewController()
        {
        }

        public StudioViewController(IntPtr handle) : base(handle)
        {
        }

        public StudioToolbarWindowController WindowController => (StudioToolbarWindowController) View.Window?.WindowController;

        public override void ViewWillAppear()
        {
            base.ViewWillAppear();
            SetupOutlineView();
        }

        public override void ViewDidAppear()
        {
            base.ViewDidAppear();
            ApplyToolbarBindings();
        }

        private void ApplyToolbarBindings()
        {
            var set = this.CreateBindingSet<StudioViewController, StudioViewModel>();

            set.Bind(WindowController.ConnectButton).To(vm => vm.ConnectToDatabaseCommand);
            set.Bind(WindowController.ConnectButton).For(btn => btn.Enabled).WithConversion<InvertedBooleanValueConverter>().To(vm => vm.IsConnectedToDatabase);

            set.Bind(WindowController.DisconnnectButton).To(vm => vm.DisconnectFromDatabaseCommand);
            set.Bind(WindowController.DisconnnectButton).For(btn => btn.Enabled).To(vm => vm.IsConnectedToDatabase);

            set.Apply();
        }

        private void SetupOutlineView()
        {
            databaseCollectionsView.Delegate = new OutlineViewDelegate();
        }

        protected override void ApplyBindings()
        {
            var set = this.CreateBindingSet<StudioViewController, StudioViewModel>();

            set.Bind(databaseCollectionsView).For(vw => vw.DataSource).To(vm => vm.CollectionItemTree).WithConversion<ListToOutlineViewDataSourceValueConverter>().OneWay();

            set.Apply();
        }
    }
}