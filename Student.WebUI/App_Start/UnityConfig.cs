using Student.Core.Contracts;
using Student.Core.Models;
using Student.DataAccess.SQL;
using Student.Services;
using System;

using Unity;

namespace Student.WebUI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            //container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IRepository<Appointment>, SQLRepository<Appointment>>();
            container.RegisterType<IRepository<Application>, SQLRepository<Application>>();
            container.RegisterType<IRepository<Job>, SQLRepository<Job>>();
            container.RegisterType<IRepository<Device>, SQLRepository<Device>>();
            container.RegisterType<IRepository<Basket>, SQLRepository<Basket>>();
            container.RegisterType<IRepository<BasketItem>, SQLRepository<BasketItem>>();
            container.RegisterType<IRepository<Customer>, SQLRepository<Customer>>();
            container.RegisterType<IRepository<Order>, SQLRepository<Order>>();
            container.RegisterType<IRepository<Listing>, SQLRepository<Listing>>();
            container.RegisterType<IRepository<Driver>, SQLRepository<Driver>>();
            container.RegisterType<IRepository<Students>, SQLRepository<Students>>();
            container.RegisterType<IRepository<FaultLog>, SQLRepository<FaultLog>>();
            container.RegisterType<IRepository<Technician>, SQLRepository<Technician>>();


            container.RegisterType<IBasketService, BasketService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IAppointmentService, AppointmentService>();

        }
    }
}