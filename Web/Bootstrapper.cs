using Autofac;
using Autofac.Integration.Mvc;
using Core.Infrastructure;
using Core.Repository;
using Data.Model;
using System.Web.Mvc;

namespace Web
{
    public static class Bootstrapper
    {
        public static void RunConfig()
        {
            BuildAutofac();
        }

        private static void BuildAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<RolRepository>().As<IRolRepository<Rol>>();
            builder.RegisterType<ElemanRepository>().As<IElemanRepository<Eleman>>();
            builder.RegisterType<IzinRepository>().As<IIzinRepository<Izin>>();
            builder.RegisterType<DepartmanRepository>().As<IDepartmanRepository<Departman>>();
            builder.RegisterType<IsRepository>().As<IIsRepository<Is>>();
            builder.RegisterType<IsMaddeRepository>().As<IIsMaddeRepository<IsMadde>>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
