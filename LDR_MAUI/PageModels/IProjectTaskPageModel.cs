using CommunityToolkit.Mvvm.Input;
using LDR_MAUI.Models;

namespace LDR_MAUI.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}