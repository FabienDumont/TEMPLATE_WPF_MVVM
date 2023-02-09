using System.Windows;
using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using TEMPLATE_WPF_MVVM.Core.Commands;
using TEMPLATE_WPF_MVVM.Core.Services;

namespace TEMPLATE_WPF_MVVM.MVVM.ViewModels;

public class NavigationBarVm : BaseVm {
    public ICommand FirstNavigateCommand { get; set; }
    public ICommand SecondNavigateCommand { get; set; }
        
    public NavigationBarVm(INavigationService firstNavigationService, INavigationService secondNavigationService) {
        FirstNavigateCommand = new NavigateCommand(firstNavigationService);
        SecondNavigateCommand = new NavigateCommand(secondNavigationService);
    }
}