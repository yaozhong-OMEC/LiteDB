using System;
using LiteDB.Studio.Core.ViewModels;
using MvvmCross.Platforms.Mac.Presenters.Attributes;
using MvvmCross.Platforms.Mac.Views;

namespace LiteDB.Studio.Mac.Views.ConnectionForm
{
    [MvxFromStoryboard("ConnectionForm")]
    [MvxWindowPresentation]
    public partial class ConnectionFormViewController : BaseViewController<ConnectionFormViewModel>
    {
        public ConnectionFormViewController()
        {
        }

        public ConnectionFormViewController(IntPtr handle) : base(handle)
        {
        }
    }
}
