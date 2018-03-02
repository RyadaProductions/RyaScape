using System.Windows.Controls;
using System.Windows.Input;

namespace RyaScape.Views {
  /// <summary>
  /// Interaction logic for QuestingControl.xaml
  /// </summary>
  public partial class QuestingControl
  {
    public QuestingControl() {
      InitializeComponent();
    }

    private void DataGrid_MouseDown(object sender, MouseButtonEventArgs e)
    {
      var dataGrid = sender as DataGrid;
      if (dataGrid != null) dataGrid.SelectedItem = null;
    }
  }
}
