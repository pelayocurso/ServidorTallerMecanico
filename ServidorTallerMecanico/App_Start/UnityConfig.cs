using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using ServidorTallerMecanico.Models;
using ServidorTallerMecanico.Repositories;
using ServidorTallerMecanico.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Unity.WebApi;

namespace ServidorTallerMecanico
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.AddNewExtension<Interception>();

            container.RegisterType<IToolsService, ToolsService>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<DbInterceptor>()
            );
            container.RegisterType<IToolsRepository, ToolsRepository>();

            container.RegisterType<IVehiclesService, VehiclesService>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<DbInterceptor>()
            );
            container.RegisterType<IVehiclesRepository, VehiclesRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public class DbInterceptor : IInterceptionBehavior
        {

            public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
            {
                IMethodReturn result;
                if (ApplicationDbContext.applicationDbContext == null)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        ApplicationDbContext.applicationDbContext = context;

                        using (var dbContextTransaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                result = getNext()(input, getNext);

                                if (result.Exception != null)
                                {
                                    throw new Exception("Ocurrio una excepcion " + result.Exception);
                                }
                                context.SaveChanges();
                                dbContextTransaction.Commit();
                            }
                            catch (Exception e)
                            {
                                dbContextTransaction.Rollback();

                                throw new Exception("He hecho rollback de la transaccion", e);
                            }
                        }
                    }

                    ApplicationDbContext.applicationDbContext = null;
                    return result;
                }
                else
                {
                    result = getNext()(input, getNext);
                    if (result.Exception != null)
                    {
                        throw new Exception("Ocurrio una excepcion " + result.Exception);
                    }
                    return result;
                }
            }

            public IEnumerable<Type> GetRequiredInterfaces()
            {
                return Type.EmptyTypes;
            }

            public bool WillExecute
            {
                get { return true; }
            }

            // private void WriteLog(string message)
            // {}
        }
    }
}
