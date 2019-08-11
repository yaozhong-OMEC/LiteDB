using LiteDB.Studio.Core;
using LiteDB.Studio.Core.Attributes;
using MvvmCross.IoC;
using MvvmCross.Logging;
using MvvmCross.Platforms.Mac.Core;

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
    }
}