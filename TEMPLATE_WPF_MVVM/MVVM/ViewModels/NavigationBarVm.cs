using System.Windows;
using TEMPLATE_WPF_MVVM.Core.Commands;
using TEMPLATE_WPF_MVVM.Core.Services;

namespace TEMPLATE_WPF_MVVM.MVVM.ViewModels;

public class NavigationBarVm : BaseVm {

    public RelayCommand OpenSecondViewCommand { get; set; }
    public RelayCommand CloseCommand { get; set; }
        
    public NavigationBarVm(INavigationService secondViewNavigationService) {
        OpenSecondViewCommand = new RelayCommand(_ => {
            secondViewNavigationService.Navigate();
        });
        
        CloseCommand = new RelayCommand(parameter => {
            SystemCommands.CloseWindow((Window)parameter!);
        });
    }
}