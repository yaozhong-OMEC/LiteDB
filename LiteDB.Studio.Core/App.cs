using LiteDB.Studio.Core.Attributes;
using LiteDB.Studio.Core.ViewModels;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace LiteDB.Studio.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            typeof(App).Assembly.CreatableTypes()
                .WithAttribute<TransientServiceAttribute>()
                .AsInterfaces()
                .RegisterAsDynamic();
            typeof(App).Assembly.CreatableTypes()
                .WithAttribute<LazySingletonServiceAttribute>()
                .AsInterfaces()
                .RegisterAsLazySingleton();
            typeof(App).Assembly.CreatableTypes()
                .WithAttribute<NonLazySingletonServiceAttribute>()
                .AsInterfaces()
                .RegisterAsSingleton();
            
            RegisterCustomAppStart<AppStarter>();
        }
    }
}