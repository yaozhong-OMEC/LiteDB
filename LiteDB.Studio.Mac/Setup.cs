using AppKit;
using LiteDB.Studio.Core;
using LiteDB.Studio.Core.Attributes;
using LiteDB.Studio.Mac.Bindings;
using LiteDB.Studio.Mac.Presenters;
using LiteDB.Studio.Mac.Views.Controls;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.IoC;
using MvvmCross.Logging;
using MvvmCross.Platforms.Mac.Core;
using MvvmCross.Platforms.Mac.Presenters;

namespace LiteDB.Studio.Mac
{
    public class Setup : MvxMacSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            MvvmCross.Binding.MvxBindingLog.TraceBindingLevel = MvxLogLevel.Trace;

            typeof(Setup).Assembly.CreatableTypes()
                .WithAttribute<TransientServiceAttribute>()
                .AsInterfaces()
                .RegisterAsDynamic();
            typeof(Setup).Assembly.CreatableTypes()
                .WithAttribute<LazySingletonServiceAttribute>()
                .AsInterfaces()
                .RegisterAsLazySingleton();
            typeof(Setup).Assembly.CreatableTypes()
                .WithAttribute<NonLazySingletonServiceAttribute>()
                .AsInterfaces()
                .RegisterAsSingleton();

            base.InitializeFirstChance();
        }

        protected override void FillBindingNames(IMvxBindingNameRegistry registry)
        {
            base.FillBindingNames(registry);

            registry.AddOrOverwrite(typeof(NSExtendedToolbarItem), nameof(NSExtendedToolbarItem.Activated));
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterCustomBindingFactory<NSOutlineView>("DataSource", outlineView => new NSOutlineViewDataSourceTargetBinding(outlineView));
        }

        protected override IMvxMacViewPresenter CreateViewPresenter()
        {
            return new CustomMacViewPresenter(ApplicationDelegate);
        }
    }
}