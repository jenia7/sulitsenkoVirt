using Autofac;
using MediatR;

namespace Virtable.UseCases;

public class UseCasesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        Type[] openTypes = [typeof(IRequest<>), typeof(IRequestHandler<>), typeof(IRequestHandler<,>)];

        foreach (var openType in openTypes)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(openType)
                .InstancePerLifetimeScope();
        }
    }
}
