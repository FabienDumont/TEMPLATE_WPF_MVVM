using System;
using TEMPLATE_WPF_MVVM.MVVM.ViewModels;

namespace TEMPLATE_WPF_MVVM.Core.Stores; 

public class ModalNavigationStore
{
    private BaseVm? _currentViewModel;
    public BaseVm? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel?.Dispose();
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public bool IsOpen => CurrentViewModel != null;

    public event Action? CurrentViewModelChanged;

    public void Close()
    {
        CurrentViewModel = null;
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}