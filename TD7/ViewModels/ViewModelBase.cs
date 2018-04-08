using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using TD7.Models.Interfaces;
using CommonServiceLocator;

namespace TD7.ViewModels
{
    class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        private readonly Task _emptyTask = new Task(() => { });
        private int _loadingCounter = 0;

        public ViewModelBase() : this(ServiceLocator.Current.GetInstance<IAlarmDataService>(), ServiceLocator.Current.GetInstance<IAlarmNavigationService>())
        {
            this.OnLoadedAsync();
        }
        /// Création du ViewModel de base
        public ViewModelBase(IAlarmDataService dataservice, IAlarmNavigationService navigationService)
        {
            this.DataService = dataservice;
            this.NavigationService = navigationService;
        }
        // Pointe vers le service de données. Initialisé dansle constructeur
        protected IAlarmDataService DataService { get; private set; }
        // Pointe vers le service de navigation. Initialisé dansle constructeur
        protected IAlarmNavigationService NavigationService { get; private set; }
        // Enregistrement de la pasge dans le système de navigation
        public void NavigationRegistering<T>()
        {
            // Registering to the Messenger
            Messenger.Default.Register<T>
            (
                 this,
                 async (message) =>
                 {
                     await OnNavigationFrom(message);
                     Messenger.Default.Unregister<T>(this);
                 }
            );
        }
        // Méthode à surcharger dans les pages
        protected virtual Task OnNavigationFrom(object parameter)
        {
            // Empty
            return _emptyTask;
        }
        // Indique si le View Model est en cours de chargement
        public bool IsLoading
        {
            get { return _loadingCounter > 0; }
            set
            {
                if (value)
                    _loadingCounter++;
                else if (_loadingCounter > 0)
                    _loadingCounter--;
                RaisePropertyChanged();
            }
        }
        // Indique si le View Model est chargé
        public bool IsViewLoaded { get; private set; }
        public async Task CallOnLoaded()
        {
            if (!IsViewLoaded)
            {
                await OnLoadedAsync();
                IsViewLoaded = true;
            }
        }
        // chargement du View Model - à surcharger dans les sous-classes
        protected virtual Task OnLoadedAsync()
        {
            // Must be empty
            return _emptyTask;
        }
        // Déchargement du View Model - à surcharger dans les sous classes
        protected virtual Task OnUnloadedAsync()
        {
            // Must be empty
            return _emptyTask;
        }

    }
}
