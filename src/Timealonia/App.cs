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

var services = new ServiceCollection();
IconProvider.Current.Register<MaterialDesignIconProvider>();

var lifetime = new ClassicDesktopStyleApplicationLifetime { Args = args, ShutdownMode = ShutdownMode.OnLastWindowClose };

AppBuilder.Configure<Application>()
    .UsePlatformDetect()
    .AfterSetup(b => b.Instance?.Styles.Add(new SemiTheme(){Locale = CultureInfo.GetCultureInfo("en-US")}))
    .UseServiceProvider(services.BuildServiceProvider())
    // uncomment the line below to enable rider ht reload workaround
    //.UseRiderHotReload()
    .SetupWithLifetime(lifetime);

lifetime.MainWindow = new Window()
    .Title("Timealonia")
    .Width(1200)
    .Height(700)
    .Content(new MainView());

#if DEBUGq
lifetime.MainWindow.AttachDevTools();
#endif

lifetime.Start(args);