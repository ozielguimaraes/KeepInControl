using System;
using Autofac;
using KeepInControl.Services.Mocks;
using KeepInControl.Services.Interfaces;
using KeepInControl.ViewModels;

namespace KeepInControl.IoC
{
    public static class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            //ViewModels
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<TransactionsViewModel>();
            builder.RegisterType<ListExpenseViewModel>();

            //General
            //builder.RegisterType<ConnectionService>().As<IConnectionService>();
            //builder.RegisterType<NavigationService>().As<INavigationService>();
            //builder.RegisterType<GenericRepository>().As<IGenericRepository>();
            //builder.RegisterType<DialogServices>().As<IDialogService>();
            //builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();
            //builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();

            //Services
            builder.RegisterType<TransactionServiceMock>().As<ITransactionService>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        //Resolve: casos em que eh necessario instancia, e nao ha injecao de dependencia no construtor(casos VM)
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}