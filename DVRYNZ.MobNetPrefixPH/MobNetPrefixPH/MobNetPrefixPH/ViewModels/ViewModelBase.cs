using Prism.Mvvm;
using PropertyChanged;

namespace MobNetPrefixPH.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class ViewModelBase : BindableBase
    {
        public string Title { get; set; }
    }
}
