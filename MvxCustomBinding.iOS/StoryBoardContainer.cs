using System;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using UIKit;

namespace MvxCustomBinding.iOS
{
    public class StoryBoardContainer : MvxIosViewsContainer
    {
        public override IMvxIosView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            return (IMvxIosView)UIStoryboard.FromName("Main", null)
                .InstantiateViewController(viewType.Name);
        }
    }
}
