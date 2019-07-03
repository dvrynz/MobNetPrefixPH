using MobNetPrefixPH.Services;
using System.Linq;

namespace MobNetPrefixPH.ViewModels
{
    public class IdentificationPageViewModel : ViewModelBase
    {
        private string _inputPrefix;
        public string InputPrefix
        {
            get => _inputPrefix;
            set
            {
                SetProperty(ref _inputPrefix, value);
                if(value != null)
                    IdentifyNetworkProvider();
            }
        }
        public string Network { get; set; }

        public IdentificationPageViewModel() : base()
        {
            Title = "Identification Page";
        }

        private void IdentifyNetworkProvider()
        {
            var input = $"0{InputPrefix}";
            var foundNetwork = Storage.NetworkProviders.FirstOrDefault(np => np.prefix.FirstOrDefault(p => p == input) != null);

            if (foundNetwork == null) Network = "";
            else Network = foundNetwork.network;
        }
    }
}
