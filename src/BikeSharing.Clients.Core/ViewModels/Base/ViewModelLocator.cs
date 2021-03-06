﻿using BikeSharing.Clients.Core.DataServices;
using BikeSharing.Clients.Core.DataServices.Base;
using BikeSharing.Clients.Core.DataServices.Fake;
using BikeSharing.Clients.Core.DataServices.Interfaces;
using BikeSharing.Clients.Core.Services;
using BikeSharing.Clients.Core.Services.Interfaces;
using BikeSharing.Clients.Core.ViewModels.SignUp;
using Microsoft.Practices.Unity;
using System;

namespace BikeSharing.Clients.Core.ViewModels.Base
{
    public class ViewModelLocator
    {
        private readonly IUnityContainer _unityContainer;

        private static readonly ViewModelLocator _instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get
            {
                return _instance;
            }
        }

        protected ViewModelLocator()
        {
            _unityContainer = new UnityContainer();

            // providers
            _unityContainer.RegisterType<IRequestProvider, RequestProvider>();
            _unityContainer.RegisterType<ILocationProvider, LocationProvider>();
            _unityContainer.RegisterType<IMediaPickerService, MediaPickerService>();

            // services
            _unityContainer.RegisterType<IDialogService, DialogService>();
            RegisterSingleton<INavigationService, NavigationService>();

            // data services
            _unityContainer.RegisterType<IAuthenticationService, FakeAuthenticationService>();
            _unityContainer.RegisterType<IProfileService, FakeProfileService>();
            _unityContainer.RegisterType<IRidesService, RidesService>();
            _unityContainer.RegisterType<IEventsService, FakeEventsService>();
            _unityContainer.RegisterType<IMembersService, MembersService>();
            _unityContainer.RegisterType<IWeatherService, OpenWeatherMapService>();
            _unityContainer.RegisterType<IFeedbackService, FeedbackService>();

            // view models
            _unityContainer.RegisterType<CustomRideViewModel>();
            _unityContainer.RegisterType<CredentialViewModel>();
            _unityContainer.RegisterType<EventSummaryViewModel>();
            _unityContainer.RegisterType<GenreViewModel>();
            _unityContainer.RegisterType<HomeViewModel>();
            _unityContainer.RegisterType<LoginViewModel>();
            _unityContainer.RegisterType<MainViewModel>();
            _unityContainer.RegisterType<MenuViewModel>();
            _unityContainer.RegisterType<MyRidesViewModel>();
            _unityContainer.RegisterType<PaymentViewModel>();
            _unityContainer.RegisterType<ProfileViewModel>();
            _unityContainer.RegisterType<SignUpViewModel>();
            _unityContainer.RegisterType<UserViewModel>();
            _unityContainer.RegisterType<ReportIncidentViewModel>();
            _unityContainer.RegisterType<BookingViewModel>();
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _unityContainer.Resolve(type);
        }

        public void Register<T>(T instance)
        {
            _unityContainer.RegisterInstance<T>(instance);
        }

        public void Register<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>();
        }

        public void RegisterSingleton<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>(new ContainerControlledLifetimeManager());
        }
    }
}
