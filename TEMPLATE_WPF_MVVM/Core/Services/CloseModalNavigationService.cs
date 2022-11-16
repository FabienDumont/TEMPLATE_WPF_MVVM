using System;
using TEMPLATE_WPF_MVVM.Core.Stores;

namespace TEMPLATE_WPF_MVVM.Core.Services;

public class CloseModalNavigationService : INavigationService {
    private readonly ModalNavigationStore _navigationStore;

    public CloseModalNavigationService(ModalNavigationStore navigationStore) {
        _navigationStore = navigationStore ?? throw new ArgumentNullException(nameof(navigationStore));
    }

    public void Navigate() {
        _navigationStore.Close();
    }
}