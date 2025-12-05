using System.Collections.ObjectModel;
using CNT_MAUI.Models.POCOs;
using CNT_MAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CNT_MAUI.ViewModels
{
    public partial class LookupDataTypeViewModel : ObservableObject
    {
        private readonly ILookupDataTypeService _service;

        [ObservableProperty]
        private ObservableCollection<LookupDataType> lookupDataTypes = new();

        public LookupDataTypeViewModel(ILookupDataTypeService service)
        {
            _service = service;
            _ = LoadDataAsync();
        }

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            try
            {
                var data = await _service.GetLookupDataTypeAsync();
                LookupDataTypes = new ObservableCollection<LookupDataType>(data);

                //LookupDataTypes.Clear();
                //foreach (var item in data)
                //{
                //    LookupDataTypes.Add(item);
                //}
            }
            catch(Exception e)
            {
                Console.WriteLine($"Failed to load lookup data types: {e.Message}");
            }
        }
    }
}
