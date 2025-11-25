using BCN_MAUI.Models;
using CommunityToolkit.Mvvm.Input;

namespace BCN_MAUI.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}