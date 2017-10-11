using Autofac;
using Autofac.Core;
using FVG.FiscalPrinter.Domain.Core.Decorators;
using FVG.FiscalPrinter.Domain.Core.Helpers;
using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Core.Print;
using System;
using System.Linq;

namespace FVG.FiscalPrinter.Domain.Core.Modules
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder
                .RegisterAssemblyTypes(assemblies)
                .As(type => type.GetInterfaces()
                .Where(iType => iType.IsClosedTypeOf(typeof(IPrintHandler<,>)))
                 .Select(iType => new KeyedService("printHandler", iType)));

            builder
                .RegisterAssemblyTypes(assemblies)
                .As(type => type.GetInterfaces()
                .Where(iType => iType.IsClosedTypeOf(typeof(ICommandHandler<>))));

            builder
               .RegisterAssemblyTypes(assemblies)
               .As(type => type.GetInterfaces()
               .Where(iType => iType.IsClosedTypeOf(typeof(IQueryHandler<,>))));

            builder
              .RegisterAssemblyTypes(assemblies)
              .AsClosedTypesOf(typeof(IValidator<>))
              .AsImplementedInterfaces();

            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();
            builder.RegisterType<QueryProcessor>().As<IQueryProcessor>();
            builder.RegisterType<ServiceManager.ServiceManager>().As<IServiceManager>();

            builder.RegisterGenericDecorator(
                typeof(ValidatePrintHandlerDecorator<>),
                typeof(IPrintHandler<,>),
                fromKey: "printHandler",
                toKey: "validationHandler");
        }
    }
}