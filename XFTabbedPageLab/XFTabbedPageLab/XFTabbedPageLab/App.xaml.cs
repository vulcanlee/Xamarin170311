using Prism.Unity;
using XFTabbedPageLab.Views;

namespace XFTabbedPageLab
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
            NavigationService.NavigateAsync("MainTabPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<MainTabPage>();
            Container.RegisterTypeForNavigation<Web1Page>();
            Container.RegisterTypeForNavigation<Web2Page>();
        }
    }
}
