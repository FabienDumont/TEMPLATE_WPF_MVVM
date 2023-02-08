using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using TEMPLATE_WPF_MVVM.Core.Commands;
using TEMPLATE_WPF_MVVM.Core.Services;

namespace TEMPLATE_WPF_MVVM.MVVM.ViewModels; 

public class SecondVm : BaseVm {
    public ICommand ReturnCommand { get; set; }
    public SecondVm(INavigationService closeNavigationService) {
        ReturnCommand = new NavigateCommand(closeNavigationService);
    }
}