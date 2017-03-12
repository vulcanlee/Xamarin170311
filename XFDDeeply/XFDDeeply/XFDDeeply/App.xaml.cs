﻿using Prism.Unity;
using XFDDeeply.Views;

namespace XFDDeeply
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NaviPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<Page1Page>();
            Container.RegisterTypeForNavigation<Page2Page>();
            Container.RegisterTypeForNavigation<Page3Page>();
            Container.RegisterTypeForNavigation<NaviPage>();
        }
    }
}
