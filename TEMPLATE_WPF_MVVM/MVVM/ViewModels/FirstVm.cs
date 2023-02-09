using System.Windows;
using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using TEMPLATE_WPF_MVVM.Core.Commands;
using TEMPLATE_WPF_MVVM.Core.Services;

namespace TEMPLATE_WPF_MVVM.MVVM.ViewModels;

public class FirstVm : BaseVm {
    
    public ICommand OpenModalCommand { get; set; }
    public FirstVm(INavigationService modalNavigationService) {
        OpenModalCommand = new NavigateCommand(modalNavigationService);
    }
}