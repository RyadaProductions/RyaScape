using System.Windows.Navigation;

namespace RyaScape.UIControls {
  /// <summary>
  /// Interaction logic for AboutControl.xaml
  /// </summary>
  public partial class AboutControl
  {
    public AboutControl() {
      InitializeComponent();
    }

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e) {
      System.Diagnostics.Process.Start(e.Uri.ToString());
    }
  }
}
