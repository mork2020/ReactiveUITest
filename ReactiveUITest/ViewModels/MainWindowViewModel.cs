using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace AvaloniaNugetSearcher.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IActivatableViewModel
    {        
        private string _searchTerm;
        public string SearchTerm
        {
            get => _searchTerm;
            set => this.RaiseAndSetIfChanged(ref _searchTerm, value);
        }       

        public ViewModelActivator Activator { get; }

        public MainWindowViewModel()
        {
            Console.WriteLine("MainWindowViewModel created");

            Activator = new ViewModelActivator();
                                
            this
                .WhenAnyValue(x => x.SearchTerm)
                .Skip(1) // ignore the initial NullOrEmpty value of SearchTerm                                                        
                .Subscribe(val =>
                {
                    String n = val;
                    if (n.Equals("aaa"))
                    {
                        n = "bbb";
                    }
                    Console.WriteLine("WhenAnyValue Subscribe() -> " + $"SearchTerm value changed to: \"{n}\"\n");
                    SearchTerm = n;
                });        
        }        
    }
}
