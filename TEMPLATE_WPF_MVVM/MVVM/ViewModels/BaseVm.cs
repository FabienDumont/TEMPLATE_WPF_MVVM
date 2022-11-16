using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TEMPLATE_WPF_MVVM.MVVM.ViewModels;

public class BaseVm : INotifyPropertyChanged, IDisposable {
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string? name = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    
    public virtual void Dispose() { }
}