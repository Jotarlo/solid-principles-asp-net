[assembly: WebActivator.PostApplicationStartMethod(typeof(ProductManager.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace ProductManager.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using ControllerContracts;
    using ControllerImpl.Implementation;
    using Model.Contracts;
    using ModelImpl.Implementation;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);
                        
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            //#error Register your services here (remove this line).

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<IProductRepository, ProductRepositoryImpl>(Lifestyle.Scoped);
            container.Register<ICategoryRepository, CategoryRepositoryImpl>(Lifestyle.Scoped);
            container.Register<ICategoryController, CategoryControllerImpl>(Lifestyle.Scoped);
            container.Register<IProductController, ProductControllerImpl>(Lifestyle.Scoped);
            container.RegisterMvcControllers();
        }
    }
}