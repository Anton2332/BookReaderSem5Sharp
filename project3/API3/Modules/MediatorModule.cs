using System.Reflection;
using Application.Behaviors;
using Application.Bookmark.Commands.CreateBookmark;
using Application.Bookmark.Queries.GetBookmark;
using Application.Notification.Commands.CreateNotification;
using Application.Notification.Queries.GetNotification;
using Application.TypeBookmark.Commands.CreateTypeBookmark;
using Application.TypeBookmark.Queries.GetTypeBookmark;
using Autofac;
using MediatR;

namespace API3.Modules;

public class MediatorModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<Mediator>()
            .As<IMediator>()
            .InstancePerLifetimeScope();

        builder.Register<ServiceFactory>(context =>
        {
            var c = context.Resolve<IComponentContext>();
            return t => c.Resolve(t);
        });

        builder.RegisterAssemblyTypes(IntrospectionExtensions.GetTypeInfo(typeof(CreateBookmarkCommand)).Assembly)
            .AsImplementedInterfaces();
        
        builder.RegisterAssemblyTypes(IntrospectionExtensions.GetTypeInfo(typeof(CreateTypeBookmarkCommand)).Assembly)
            .AsImplementedInterfaces();
        
        builder.RegisterAssemblyTypes(IntrospectionExtensions.GetTypeInfo(typeof(CreateNotificationCommand)).Assembly)
            .AsImplementedInterfaces();
        
        builder.RegisterAssemblyTypes(IntrospectionExtensions.GetTypeInfo(typeof(GetBookmarkQuery)).Assembly)
            .AsImplementedInterfaces();
        
        builder.RegisterAssemblyTypes(IntrospectionExtensions.GetTypeInfo(typeof(GetTypeBookmarkQuery)).Assembly)
            .AsImplementedInterfaces();
        
        builder.RegisterAssemblyTypes(IntrospectionExtensions.GetTypeInfo(typeof(GetNotificationQuery)).Assembly)
            .AsImplementedInterfaces();

        builder.RegisterGeneric(typeof(ValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    }
}