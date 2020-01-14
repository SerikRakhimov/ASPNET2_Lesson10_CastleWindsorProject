using Castle.Windsor;
using CastleWindsorProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CastleWindsorProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // ������� ���������
            var container = new WindsorContainer();
            // ������������ ���������� � ������� ������� ApplicationCastleInstaller
            container.Install(new ApplicationCastleInstaller());

            // �������� ���� ������� ������������
            var castleControllerFactory = new CastleControllerFactory(container);

            // ��������� ������� ������������ ��� ��������� ��������
            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
