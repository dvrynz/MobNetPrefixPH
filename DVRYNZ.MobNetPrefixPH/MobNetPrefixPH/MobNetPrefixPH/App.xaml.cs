using MobNetPrefixPH.Services;
using MobNetPrefixPH.Views;
using Newtonsoft.Json;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using static MobNetPrefixPH.Infa.Contants;
using static MobNetPrefixPH.Infa.Contants.Pages;

namespace MobNetPrefixPH
{
    public partial class App : PrismApplication
    {
        private IContainerRegistry _containerRegistry;

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _containerRegistry = containerRegistry;
            IocContainer.Initialize(_containerRegistry.GetContainer());

            RegisterServices();
            InitializeLocalData();
            _containerRegistry.RegisterForNavigation<NavigationPage>();
            _containerRegistry.RegisterForNavigation<IdentificationPage>();
        }

        private void RegisterServices()
        {
            _containerRegistry.RegisterSingleton<IMapperService, MapperService>();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            var rootPage = $"{APPLICATION_ROOT_URI}/{NAVIGATIONPAGE}/{IDENTIFICATIONPAGE}";
            NavigationService.NavigateAsync(rootPage);
        }

        private void InitializeLocalData()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("MobNetPrefixPH.mobilePrefix.json");
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<IEnumerable<Entities.NetworkProvider>>(json);
                Storage.Initilialize(data);
            }
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
