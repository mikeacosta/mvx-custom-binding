using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using MvvmCross;
using MvvmCross.Logging;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using UIKit;

namespace MvxCustomBinding.iOS
{
    public class Setup : MvxIosSetup
    {
        //private MvxApplicationDelegate _applicationDelegate;
        //UIWindow _window;

        //public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        //{
        //    _applicationDelegate = applicationDelegate;
        //    _window = window;
        //}

        //public Setup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter viewPresenter) : base(applicationDelegate, viewPresenter)
        //{
        //}

        protected override IMvxApplication CreateApp() => new App();

        protected override IMvxIosViewsContainer CreateIosViewsContainer()
        {
            return new StoryBoardContainer();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();

            Mvx.IoCProvider.RegisterType<IBluetoothHelper, BluetoothHelper>();
        }

        //protected override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.None;
    }
}
