using System;
using Foundation;
using LiteDB.Studio.Core.Converters;
using LiteDB.Studio.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Presenters.Attributes;
using MvvmCross.Platforms.Mac.Views;

namespace LiteDB.Studio.Mac.Views.ConnectionForm
{
    [MvxFromStoryboard(StoryboardName = "ConnectionForm")]
    [MvxSheetPresentation(WindowIdentifier = "Root", ViewModelType = typeof(ConnectionFormViewModel))]
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

            set.Bind(connectionModeEmbeddedRadioButton).To(vm => vm.SetConnectionModeCommand).CommandParameter(ConnectionMode.Embedded);

            set.Bind(filePathTextField).To(vm => vm.AbsoluteFilePath);
            set.Bind(browseFileButton).To(vm => vm.BrowseFileCommand);

            set.Bind(passwordTextField).To(vm => vm.Password);

            set.Bind(upgradeCheckbox).For(checkBox => checkBox.State).To(vm => vm.Upgrade);
            set.Bind(utcTimeCheckbox).For(checkBox => checkBox.State).To(vm => vm.UseUtc);
            set.Bind(openInReadonlyCheckbox).For(checkBox => checkBox.State).To(vm => vm.IsReadOnly);
            set.Bind(timeoutTextField).To(vm => vm.Timeout).WithConversion<NullableTimeSpanToSecondsValueConverter>();

            set.Bind(cancelButton).To(vm => vm.CancelCommand);
            set.Bind(confirmButton).To(vm => vm.ConfirmCommand);

            set.Apply();
        }
    }
}