using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Web.Http;
using DeletableExample.Contracts;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace DeletableExample
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var nav = new NavigationService();
            nav.Configure(nameof(MainPage), typeof(MainPage));
            nav.Configure(nameof(MaterialsPage), typeof(MaterialsPage));
            nav.Configure(nameof(MaterialPage), typeof(MaterialPage));


            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<HttpClient>(() => new HttpClient());
            SimpleIoc.Default.Register<IHttpClientWrapper, HttpClientWrapper>();
            SimpleIoc.Default.Register<IMaterialClient, MaterialClient>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MaterialsViewModel>();
            SimpleIoc.Default.Register<MaterialViewModel>();
            Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
        }

        public MainViewModel MainViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public MaterialsViewModel MaterialsViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MaterialsViewModel>(); }
        }

        public MaterialViewModel MaterialViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MaterialViewModel>(); }
        }

        private async void NotifyUserMethod(NotificationMessage message)
        {
            var dialog = new MessageDialog(message.Notification);
            await dialog.ShowAsync();
        }

    }
}
