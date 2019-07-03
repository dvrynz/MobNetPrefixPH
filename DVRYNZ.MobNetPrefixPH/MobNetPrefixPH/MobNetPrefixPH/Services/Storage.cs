using MobNetPrefixPH.Entities;
using System;
using System.Collections.Generic;

namespace MobNetPrefixPH.Services
{
    public static class Storage
    {
        private static IEnumerable<NetworkProvider> _networkProviders;

        public static IEnumerable<NetworkProvider> NetworkProviders
        {
            get
            {
                if (_networkProviders == null)
                    throw new ArgumentNullException("Database is not initialized yet!");

                return _networkProviders;
            }
        }

        public static void Initilialize(IEnumerable<NetworkProvider> networkProviders)
        {
            _networkProviders = networkProviders;
        }
    }
}
