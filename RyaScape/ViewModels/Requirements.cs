using RyaScape.Mvvm;
using System.Windows;

namespace RyaScape.ViewModels
{
    public class Requirements : BaseViewModel
    {
        private string _requirementName = string.Empty;
        private TextDecorationCollection _requirementStatus;

        public string RequirementName
        {
            get => _requirementName;
            set => SetAndNotify(ref _requirementName, value);
        }

        public TextDecorationCollection RequirementStatus
        {
            get => _requirementStatus;
            set => SetAndNotify(ref _requirementStatus, value);
        }
    }
}
