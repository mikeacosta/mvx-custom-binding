using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Binding.Target;

namespace MvxCustomBinding.Droid
{
    public class CustomButtonTargetBinding : MvxAndroidTargetBinding<Button, bool>
    {
        public const string BindingPropertyName = "CustomButton";

        private readonly Button _button;

        public CustomButtonTargetBinding(Button target) : base(target)
        {
            _button = target;
        }

        protected override void SetValueImpl(Button target, bool value)
        {
            _button.SetBackgroundResource(value
                ? Resource.Drawable.ic_outline_touch_app_24px
                : Resource.Drawable.ic_outline_verified_user_24px);
        }
    }
}