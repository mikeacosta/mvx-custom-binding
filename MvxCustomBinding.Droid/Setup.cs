using Android.Widget;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Android.Core;

namespace MvxCustomBinding.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterFactory(new MvxCustomBindingFactory<Button>(
                CustomButtonTargetBinding.BindingPropertyName,
                button => new CustomButtonTargetBinding(button)));
        }
    }
}