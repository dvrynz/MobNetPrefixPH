using System;
using Unity;

namespace MobNetPrefixPH.Services
{
    public sealed class IocContainer 
    {
        private static IUnityContainer _instance;

        public static IUnityContainer Instance
        {
            get
            {
                if (_instance == null)
                    throw new ArgumentNullException("The IOC container is not initialized yet!");
                return _instance;
            }
        }

        public static void Initialize(IUnityContainer unityContainer)
        {
            _instance = unityContainer;
        }
    }
}
