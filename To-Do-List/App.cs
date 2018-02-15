using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using JimBobBennett.MvvmLight.AppCompat;
using To_Do_List.ViewModel;

namespace To_Do_List
{
    public static class App
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                if (_locator == null)
                {
                    // Initialize the MVVM Light DispatcherHelper.
                    // This needs to be called on the UI thread.
                    DispatcherHelper.Initialize();

                    // Configure and register the MVVM Light NavigationService
                    var nav = new AppCompatNavigationService();

                    
                    nav.Configure(ViewModelLocator.TaskPageKey, typeof(TaskActivity));

                    SimpleIoc.Default.Register<INavigationService>(() => nav);

                    // Register the MVVM Light DialogService
                    SimpleIoc.Default.Register<IDialogService, DialogService>();

                    _locator = new ViewModelLocator();
                }

                return _locator;
            }
        }
    }
}