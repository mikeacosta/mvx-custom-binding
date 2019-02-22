using Android.Widget;
using MvvmCross;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Android.Core;
using MvxCustomBinding.Android;

namespace MvxCustomBinding.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();

            Mvx.RegisterType<INotificationService>(() => new NotificationService(ApplicationContext));
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterFactory(new MvxCustomBindingFactory<Button>(
                CustomButtonTargetBinding.BindingPropertyName,
                button => new CustomButtonTargetBinding(button)));
        }
    }
}