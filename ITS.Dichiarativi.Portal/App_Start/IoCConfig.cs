using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ITS.Dichiarativi.AzureStorage;
using ITS.Dichiarativi.Contracts;
using ITS.Dichiarativi.Dummy;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITS.Dichiarativi.Portal.App_Start
{
    public class IoCConfig : IControllerFactory
    {
        private WindsorContainer _container;

        public IoCConfig()
        {
            _container = new WindsorContainer();
            //_container.Register(
            //    Component
            //    .For<IDichiarativiQueries>()
            //    .ImplementedBy<DummyDichiarazioniQueries>());
            _container.Register(
                Component
                .For<StorageCredentials>()
                .Instance(new StorageCredentials(
                    ConfigurationManager.AppSettings["storageName"]                    
                    ,
                    ConfigurationManager.AppSettings["storageKey"]                    
                )));
            _container.Register(
                Component
                .For<IDichiarativiQueries>()
                .ImplementedBy<DichiarativiQueriesTableStorage>());
            _container.Register(
                Classes
                .FromThisAssembly()
                .InNamespace("ITS.Dichiarativi.Portal.Controllers", true)
                .LifestylePerWebRequest()
            );
        }
        

        public static void Register()
        {
            ControllerBuilder.Current.SetControllerFactory(new IoCConfig());
        }

        IController IControllerFactory.CreateController
            (System.Web.Routing.RequestContext requestContext
            , string controllerName
            )
        {
            try
            {
                return _container.Resolve<IController>("ITS.Dichiarativi.Portal.Controllers." + controllerName + "Controller");
            }
            catch
            {
                return null;
            }
        }

        System.Web.SessionState.SessionStateBehavior IControllerFactory.GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return System.Web.SessionState.SessionStateBehavior.Disabled;
        }

        void IControllerFactory.ReleaseController(IController controller)
        {
        }
    }
}