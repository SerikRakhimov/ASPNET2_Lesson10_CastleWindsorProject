using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CastleWindsorProject.Interfaces;
using CastleWindsorProject.Interfaces.Release;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CastleWindsorProject.Util
{
    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // регистрируем компоненты приложения
//          container.Register(Component.For<IRepository>().ImplementedBy<JsonRepository>());
            container.Register(Component.For<IRepository>().ImplementedBy<SQLRepository>());

            // регистрируем каждый контроллер по отдельности
            var controllers = Assembly.GetExecutingAssembly()
                .GetTypes().Where(x => x.BaseType == typeof(Controller)).ToList();
            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestyleSingleton());
                //              container.Register(Component.For(controller).LifestylePerThread());
                //              container.Register(Component.For(controller).LifestylePerWebRequest());
            }
        }
    }
}