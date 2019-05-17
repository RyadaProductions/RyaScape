using System.Windows.Controls;
using System.Windows.Input;

namespace RyaScape.Views
{
    /// <summary>
    /// Interaction logic for QuestingControl.xaml
    /// </summary>
    public partial class QuestingControl
    {
        public QuestingControl()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid) dataGrid.SelectedItem = null;
        }
    }
}
