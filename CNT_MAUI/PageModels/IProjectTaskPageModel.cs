using CNT_MAUI.Models;
using CommunityToolkit.Mvvm.Input;

namespace CNT_MAUI.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}