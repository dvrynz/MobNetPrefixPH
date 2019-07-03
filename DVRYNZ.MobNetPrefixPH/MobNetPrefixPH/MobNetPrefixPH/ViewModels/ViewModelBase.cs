using MobNetPrefixPH.Services;
using Prism.Mvvm;
using PropertyChanged;
using Unity;

namespace MobNetPrefixPH.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class ViewModelBase : BindableBase
    {
        protected readonly IMapperService _mapperService;

        protected IMapperService MapperService { get => _mapperService;}

        public string Title { get; set; }

        public ViewModelBase()
        {
            _mapperService = IocContainer.Instance.Resolve<IMapperService>();
        }
    }
}
