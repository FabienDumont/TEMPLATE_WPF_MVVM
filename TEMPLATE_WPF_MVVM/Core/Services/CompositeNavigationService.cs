using System.Collections.Generic;

namespace TEMPLATE_WPF_MVVM.Core.Services;

public class CompositeNavigationService : INavigationService {
    private readonly IEnumerable<INavigationService> _navigationServices;

    public CompositeNavigationService(params INavigationService[] navigationServices) {
        _navigationServices = navigationServices;
    }

    public void Navigate() {
        foreach (INavigationService navigationService in _navigationServices) {
            navigationService.Navigate();
        }
    }
}