using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.Extensions.DependencyInjection;
using Avalonia.Markup.Declarative;
using Projektanker.Icons.Avalonia;
using Projektanker.Icons.Avalonia.MaterialDesign;
using Semi.Avalonia;
using Timealonia;
using Timealonia.Navigation;
using Timealonia.Pages;
using Timealonia.Styling;

var services = new ServiceCollection();
services.AddTransient<ProjectsPage>()
    .AddTransient<SettingsPage>()
    .AddTransient<ProfilePage>()
    .AddSingleton<IStyleProvider, SemiStyleProvider>()
    .AddTransient<Func<string, PageBase>>(serviceProvider => page => 
    {
        var className = page + "Page";
        var pageType = Type.GetType($"Timealonia.Pages.{className}");
        if (pageType == null)
            throw new ArgumentException($"Page type '{className}' not found.");
        return (PageBase)serviceProvider.GetRequiredService(pageType);
    })
    .AddSingleton<INavigator>(sp => new Navigator(Enum.GetNames<PageName>(), sp.GetRequiredService<Func<string, PageBase>>()));
IconProvider.Current.Register<MaterialDesignIconProvider>();

var lifetime = new ClassicDesktopStyleApplicationLifetime { Args = args, ShutdownMode = ShutdownMode.OnLastWindowClose };

AppBuilder.Configure<Application>()
    .UsePlatformDetect()
    .AfterSetup(b =>
    {
        b.Instance?.Styles.Add(new SemiTheme() { Locale = CultureInfo.GetCultureInfo("en-US") });
    })
    .UseServiceProvider(services.BuildServiceProvider())
    // uncomment the line below to enable rider ht reload workaround
    .UseRiderHotReload()
    .SetupWithLifetime(lifetime);

lifetime.MainWindow = new Window()
    .Title("Timealonia")
    .Width(1200)
    .Height(700)
    .Content(new MainView());

#if DEBUG
lifetime.MainWindow.AttachDevTools();
#endif

lifetime.Start(args);