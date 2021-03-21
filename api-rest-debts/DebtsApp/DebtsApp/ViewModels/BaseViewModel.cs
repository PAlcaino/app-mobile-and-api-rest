using MvvmCross.ViewModels;

namespace debts_app.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected BaseViewModel()
        {
        }
    }

    public abstract class BaseViewModel<TParameter, TResult> : MvxViewModel<TParameter, TResult>
        where TParameter : class
        where TResult : class
    {
        protected BaseViewModel()
        {
        }
    }
}