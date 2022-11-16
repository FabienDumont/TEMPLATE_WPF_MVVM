using TEMPLATE_WPF_MVVM.Core.Stores;

namespace TEMPLATE_WPF_MVVM.MVVM.ViewModels; 

public class MainVm : BaseVm {
    private readonly NavigationStore _navigationStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    public BaseVm? CurrentViewModel => _navigationStore.CurrentViewModel;
    public BaseVm? CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
    public bool IsOpen => _modalNavigationStore.IsOpen;

    public MainVm(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore) {
        _navigationStore = navigationStore;
        _modalNavigationStore = modalNavigationStore;

        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        _modalNavigationStore.CurrentViewModelChanged += OnCurrentModalViewModelChanged;
    }

    private void OnCurrentViewModelChanged() {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

    private void OnCurrentModalViewModelChanged() {
        OnPropertyChanged(nameof(CurrentModalViewModel));
        OnPropertyChanged(nameof(IsOpen));
    }
}