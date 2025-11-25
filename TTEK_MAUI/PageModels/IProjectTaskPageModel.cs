using CommunityToolkit.Mvvm.Input;
using TTEK_MAUI.Models;

namespace TTEK_MAUI.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}