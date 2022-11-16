using System;
using TEMPLATE_WPF_MVVM.MVVM.ViewModels;

namespace TEMPLATE_WPF_MVVM.Core.Stores;

public class NavigationStore {
    private BaseVm? _currentViewModel;

    public BaseVm? CurrentViewModel {
        get => _currentViewModel;
        set {
            _currentViewModel?.Dispose();
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public event Action? CurrentViewModelChanged;

    private void OnCurrentViewModelChanged() {
        CurrentViewModelChanged?.Invoke();
    }
}