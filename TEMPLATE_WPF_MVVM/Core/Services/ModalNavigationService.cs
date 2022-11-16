using System;
using TEMPLATE_WPF_MVVM.Core.Stores;
using TEMPLATE_WPF_MVVM.MVVM.ViewModels;

namespace TEMPLATE_WPF_MVVM.Core.Services; 

public class ModalNavigationService<TViewModel> : INavigationService 
    where TViewModel : BaseVm
{
    private readonly ModalNavigationStore _navigationStore;
    private readonly Func<TViewModel> _createViewModel;

    public ModalNavigationService(ModalNavigationStore navigationStore, Func<TViewModel> createViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public void Navigate()
    {
        _navigationStore.CurrentViewModel = _createViewModel();
    }
}