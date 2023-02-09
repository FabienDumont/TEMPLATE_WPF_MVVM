using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using TEMPLATE_WPF_MVVM.Core.Services;
using TEMPLATE_WPF_MVVM.Core.Stores;
using TEMPLATE_WPF_MVVM.MVVM.ViewModels;
using TEMPLATE_WPF_MVVM.Views;

namespace TEMPLATE_WPF_MVVM;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App {
    private readonly IHost _host;
    private readonly ServiceProvider _serviceProvider;

    public App() {
        _host = Host.CreateDefaultBuilder().ConfigureAppConfiguration(
            c => {
                c.AddJsonFile("appsettings.json");
                c.AddEnvironmentVariables();
            }
        ).ConfigureServices(
            (context, services) => {
                // Store classes to send information through ViewModels
                services.AddSingleton<StringStore>();
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<ModalNavigationStore>();

                services.AddSingleton(CreateFirstViewNavigationService);
                services.AddSingleton<CloseModalNavigationService>();

                // Services creation to allow ViewModels to navigate from one to another

                services.AddTransient(s => new FirstVm(CreateModalViewNavigationService(s)));
                services.AddTransient(s => new SecondVm());
                services.AddTransient(s => new ModalVm(s.GetRequiredService<CloseModalNavigationService>()));

                // Nav Bar
                services.AddTransient(
                    s => new NavigationBarVm(CreateFirstViewNavigationService(s), CreateSecondViewNavigationService(s))
                );

                // Creation of the Main Window which can display the User Controls
                services.AddSingleton<MainVm>();
                services.AddSingleton(s => new MainWindow() { DataContext = s.GetRequiredService<MainVm>() });
            }
        ).Build();
    }

    protected override void OnStartup(StartupEventArgs e) {
        _host.Start();

        INavigationService initialNavigationService = _host.Services.GetRequiredService<INavigationService>();
        initialNavigationService.Navigate();

        // Showing the main Window
        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e) {
        await _host.StopAsync();
        _host.Dispose();
    }

    private static INavigationService CreateFirstViewNavigationService(IServiceProvider serviceProvider) {
        // A layout is applied 
        return new LayoutNavigationService<FirstVm>(
            serviceProvider.GetRequiredService<NavigationStore>(), serviceProvider.GetRequiredService<FirstVm>,
            serviceProvider.GetRequiredService<NavigationBarVm>
        );
    }
    
    private static INavigationService CreateSecondViewNavigationService(IServiceProvider serviceProvider) {
        // A layout is applied 
        return new LayoutNavigationService<SecondVm>(
            serviceProvider.GetRequiredService<NavigationStore>(), serviceProvider.GetRequiredService<SecondVm>,
            serviceProvider.GetRequiredService<NavigationBarVm>
        );
    }

    private static INavigationService CreateModalViewNavigationService(IServiceProvider serviceProvider) {
        return new ModalNavigationService<ModalVm>(
            serviceProvider.GetRequiredService<ModalNavigationStore>(), serviceProvider.GetRequiredService<ModalVm>
        );
    }
}