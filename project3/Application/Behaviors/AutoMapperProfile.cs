using Application.Bookmark.Commands.CreateBookmark;
using Application.Bookmark.Commands.UpdateBookmark;
using Application.Bookmark.Queries;
using Application.Notification.Commands;
using Application.Notification.Commands.CreateNotification;
using Application.TypeBookmark.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Behaviors;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateTypeBookmarkMaps();
        CreateBookmarkMaps();
        CreateNotificationMaps();
    }

    private void CreateTypeBookmarkMaps()
    {
        CreateMap<TypeBookmarkDTO, TypeBookmarks>();
        CreateMap<TypeBookmarks, TypeBookmark.Queries.TypeBookmarkDTO>();
    }

    private void CreateBookmarkMaps()
    {
        CreateMap<CreateBookmarkDTO, Bookmarks>();
        CreateMap<UpdateBookmarkDTO, Bookmarks>();
        CreateMap<Bookmarks, BookmarkDTO>();
    }

    private void CreateNotificationMaps()
    {
        CreateMap<CreateNotificationDTO, Domain.Entities.Notification>();
        CreateMap<NotificationDTO, Domain.Entities.Notification>();
        CreateMap<Domain.Entities.Notification, Notification.Queries.NotificationDTO>();
    }
}