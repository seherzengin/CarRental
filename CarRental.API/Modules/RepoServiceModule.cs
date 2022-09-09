using Autofac;
using CarRental.Caching;
using CarRental.Core.Repositories;
using CarRental.Core.Services;
using CarRental.Core.UnitOfWorks;
using CarRental.Repository;
using CarRental.Repository.Repositories;
using CarRental.Repository.UnitOfWorks;
using CarRental.Service.Mapping;
using CarRental.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace CarRental.API.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();



            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(carrentaldbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<CarServiceWithCaching>().As<ICarService>();//Arrık ICarService'i gördüğünde CarServiceWithCaching'i alacak.
            builder.RegisterType<CarImageServiceWithCaching>().As<ICarImageService>();

        }
    }
}
