using ATAN_MAUI.Models;
using CommunityToolkit.Mvvm.Input;

namespace ATAN_MAUI.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}