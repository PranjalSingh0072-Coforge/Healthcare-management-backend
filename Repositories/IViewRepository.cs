
using HealthcareManagement.Models;

namespace HealthcareManagement.Repositories
{
  public interface IViewService
  {
    Task<IEnumerable<ViewModel>> GetViewModelsAsync();
    Task<int> AddViewModelAsync(ViewModel viewModel);
    Task<ViewModel> GetViewModelByIdAsync(int viewModelId);
  }


}
