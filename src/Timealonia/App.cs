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
using Timealonia.Shell.Navigation;
using Timealonia.Shell.Pages;
using Timealonia.Shell.Styling;

var lifetime = new ClassicDesktopStyleApplicationLifetime { Args = args, ShutdownMode = ShutdownMode.OnLastWindowClose };

var services = new ServiceCollection();
services
    .AddTransient<ProjectsPage>()
    .AddTransient<SettingsPage>()
    .AddTransient<ProfilePage>()
    .AddSingleton<IStyleProvider, SemiStyleProvider>()
    .AddTransient<Func<string, PageBase>>(serviceProvider => page =>
    {
        var className = page + "Page";
        var pageType = Type.GetType($"Timealonia.Shell.Pages.{className}");
        if (pageType == null)
            throw new ArgumentException($"Page type '{className}' not found.");
        return (PageBase)serviceProvider.GetRequiredService(pageType);
    })
    .AddSingleton<INavigator>(sp =>
        new Navigator(Enum.GetNames<PageName>(), sp.GetRequiredService<Func<string, PageBase>>()));
var provider = services.BuildServiceProvider();

AppBuilder.Configure<Application>()
    .UsePlatformDetect()
    .AfterSetup(b =>
    {
        IconProvider.Current.Register<MaterialDesignIconProvider>();
        b.Instance?.Styles.Add(new SemiTheme() { Locale = CultureInfo.GetCultureInfo("en-US") });
    })
    .UseServiceProvider(provider)
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
/*var dataStore = provider.GetRequiredService<AppDataStore>();
lifetime.Startup += async (_, _) =>
{
    await dataStore.LoadAppDataAsync();
};
lifetime.ShutdownRequested += async (_, _) =>
{
    await dataStore.SaveAsync();
};*/

lifetime.Start(args);