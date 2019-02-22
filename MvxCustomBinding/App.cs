using MvvmCross.ViewModels;

namespace MvxCustomBinding
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MyViewModel>();
        }
    }
}
