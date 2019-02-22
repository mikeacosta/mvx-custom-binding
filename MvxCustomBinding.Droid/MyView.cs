using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;

namespace MvxCustomBinding.Droid
{
    [Activity(Label = "Custom Binding", MainLauncher = true)]
    public class MyView : MvxActivity<MyViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.my_view);
        }
    }
}