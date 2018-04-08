using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using TD7.Models.Interfaces;
using TD7.Views;

namespace TD7.ViewModels
{
    public class ViewModelLocator
    {
        public const string MAIN_PAGE = "Main";
        public const string CREER_ALARME_PAGE = "NewAlarm";

        public ViewModelLocator()
        {
            // SimpleIoC
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            // Enregistrement de notre modèle
            SimpleIoc.Default.Register<Models.Interfaces.IAlarmDataService, Models.AlarmDataService>();
            SimpleIoc.Default.Register<IAlarmNavigationService>(() => CreateNavigationService());
            // Enregistrement de notre MainViewModel
            SimpleIoc.Default.Register<ViewModels.MainViewModel>();
            SimpleIoc.Default.Register<ViewModels.NewAlarmViewModel>();
        }

        private IAlarmNavigationService CreateNavigationService()
        {
            var navigationService = new Views.AlarmNavigationService();
            navigationService.Configure(MAIN_PAGE, typeof(Views.MainPage));
            navigationService.Configure(CREER_ALARME_PAGE, typeof(Views.NewAlarm));
            return navigationService;
        }
    }
}
