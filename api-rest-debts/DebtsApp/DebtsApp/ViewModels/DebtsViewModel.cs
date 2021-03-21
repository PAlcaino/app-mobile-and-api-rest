using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace debts_app.ViewModels
{
    public class DebtsViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public DebtsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //public IMvxCommand GetDebtsCommand(() =>{ });
    }
}
