using RyaScape.Mvvm;
using System.Windows;

namespace RyaScape.ViewModels
{
    public class RequirementsViewModel : BaseViewModel
    {
        private string _name = string.Empty;
        private TextDecorationCollection _status;

        public string Name
        {
            get => _name;
            set => SetAndNotify(ref _name, value);
        }

        public TextDecorationCollection Status
        {
            get => _status;
            set => SetAndNotify(ref _status, value);
        }
    }
}
