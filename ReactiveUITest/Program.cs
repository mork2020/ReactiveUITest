﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using AvaloniaNugetSearcher.Views;

namespace AvaloniaNugetSearcher
{
    class Program
    {
        public static void Main(string[] args)
        {
            BuildAvaloniaApp().Start(AppMain, args);
        }

        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder
                .Configure<App>()
                .UseReactiveUI()
                .UsePlatformDetect()
                .LogToDebug();
        }

        private static void AppMain(Application app, string[] args)
        {
            app.Run(new MainWindow());
        }
    }
}
