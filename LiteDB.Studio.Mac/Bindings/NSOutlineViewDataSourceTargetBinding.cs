using System;
using AppKit;
using MvvmCross.Binding;
using MvvmCross.Platforms.Mac.Binding.Target;

namespace LiteDB.Studio.Mac.Bindings
{
    public class NSOutlineViewDataSourceTargetBinding : MvxMacTargetBinding
    {
        protected NSOutlineView View => (NSOutlineView) Target;

        public NSOutlineViewDataSourceTargetBinding(NSOutlineView view) : base(view)
        {
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        public override Type TargetType => typeof(NSOutlineViewDataSource);

        protected override void SetValueImpl(object target, object value)
        {
            var view = this.View;
            if (view == null)
            {
                return;
            }

            var datasource = value as NSOutlineViewDataSource;
            view.DataSource = datasource;
        }
    }
}