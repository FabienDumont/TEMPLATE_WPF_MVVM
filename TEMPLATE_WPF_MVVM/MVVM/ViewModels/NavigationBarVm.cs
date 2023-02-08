using System.Windows;
using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using TEMPLATE_WPF_MVVM.Core.Commands;
using TEMPLATE_WPF_MVVM.Core.Services;

namespace TEMPLATE_WPF_MVVM.MVVM.ViewModels;

public class NavigationBarVm : BaseVm {

    public ICommand OpenSecondViewCommand { get; set; }
    public ICommand CloseCommand { get; set; }
        
    public NavigationBarVm(INavigationService secondViewNavigationService) {
        OpenSecondViewCommand = new NavigateCommand(secondViewNavigationService);
        
        CloseCommand = new RelayCommand(parameter => {
            SystemCommands.CloseWindow((Window)parameter!);
        });
    }
}