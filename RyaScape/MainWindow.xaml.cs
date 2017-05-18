using System.Windows;
using RyaScape.ViewModel;

namespace RyaScape {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    private readonly MainViewModel _model;
    public MainWindow() {
      InitializeComponent();
      _model = new MainViewModel();

      DataContext = _model;
    }
  }
}
