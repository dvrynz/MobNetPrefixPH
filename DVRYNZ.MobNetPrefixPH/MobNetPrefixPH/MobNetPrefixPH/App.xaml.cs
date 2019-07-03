using MobNetPrefixPH.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace MobNetPrefixPH
{
    public partial class App : PrismApplication
    {
        private IContainerRegistry _containerRegistry;

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _containerRegistry = containerRegistry;

            _containerRegistry.RegisterForNavigation<NavigationPage>();
            _containerRegistry.RegisterForNavigation<MainPage>();
            _containerRegistry.RegisterForNavigation<IdentificationPage>();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            var rootPage = $"http://www.mobnetprefixph.com/{nameof(NavigationPage)}/{nameof(IdentificationPage)}";
            NavigationService.NavigateAsync(rootPage);
        }

        #region DEFAULT OVERRIDES FROM APPLICATION
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion

    }
}
