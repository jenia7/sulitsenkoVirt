using Autofac;
using MediatR;
using Virtable.Core.GridAggregate;
using Virtable.Core.SharedKernel;
using Virtable.Infrastructure.Data;

namespace Virtable.Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterEf(builder);
        RegisterMediatR(builder);

        builder.RegisterType<ColumnsReadRepo>().As<IColumnsReadRepo>().InstancePerLifetimeScope();
    }

    private void RegisterEf(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>))
            .As(typeof(IRepository<>))
            .InstancePerLifetimeScope();
    }

    private void RegisterMediatR(ContainerBuilder builder)
    {
        builder.RegisterType<Mediator>()
            .As<ISender>().As<IPublisher>()
            .InstancePerLifetimeScope();
    }
}
