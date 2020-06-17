using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaNugetSearcher.ViewModels;
using ReactiveUI;
using System;
using System.Reactive.Disposables;

namespace AvaloniaNugetSearcher.Views
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {      
        private TextBox TbSearchTerm => this.FindControl<TextBox>("tbSearchTerm");
        public MainWindow()
        {
            Console.WriteLine("MainWindow created");

            ViewModel = new MainWindowViewModel();       

            this
                .WhenActivated(
                    disposables =>
                    {                        
                        this
                         .Bind(ViewModel, viewModel => viewModel.SearchTerm, view => view.TbSearchTerm.Text)
                         .DisposeWith(disposables);                                                
                    });                      
            
            InitializeComponent();

#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
