using Autofac;
using Domain.Interfaces;
using Domain.Interfaces.Bookmark;
using Domain.Interfaces.Notification;
using Domain.Interfaces.TypeBookmark;
using Infrastructure.Repositories.Bookmarks;
using Infrastructure.Repositories.Notification;
using Infrastructure.Repositories.TypeBookmarks;

namespace Infrastructure.Repositories;

public class Modules : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

        builder.RegisterType<BookmarksCommandRepository>().As<IBookmarkCommandRepository>().InstancePerLifetimeScope();
        
        builder.RegisterType<BookmarksReadRepository>().As<IBookmarkReadRepository>().InstancePerLifetimeScope();
        
        builder.RegisterType<TypeBookmarksCommandRepository>().As<ITypeBookmarkCommandRepository>().InstancePerLifetimeScope();
        
        builder.RegisterType<TypeBookmarksReadRepository>().As<ITypeBookmarkRepository>().InstancePerLifetimeScope();
        
        builder.RegisterType<NotificationCommandRepository>().As<INotificationCommandRepository>().InstancePerLifetimeScope();
        
        builder.RegisterType<NotificationReadRepository>().As<INotificationReadRepository>().InstancePerLifetimeScope();
        
    }
}