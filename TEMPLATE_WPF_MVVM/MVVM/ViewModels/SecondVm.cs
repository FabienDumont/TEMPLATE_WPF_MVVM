using TEMPLATE_WPF_MVVM.Core.Commands;
using TEMPLATE_WPF_MVVM.Core.Services;

namespace TEMPLATE_WPF_MVVM.MVVM.ViewModels; 

public class SecondVm : BaseVm {
    public RelayCommand ReturnCommand { get; set; }
    public SecondVm(INavigationService closeNavigationService) {
        ReturnCommand = new RelayCommand(_ => {
            closeNavigationService.Navigate();
        });
    }
}