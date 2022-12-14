using AutoMapper;
using BLL2.DTO;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using DAL2.Entitys;

namespace BLL2.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateAuthorMaps();
        CreateBookAuthorMaps();
        CreateBookCategoryMaps();
        CreateCategoryMaps();
        CreateBookMaps();
        CreateBookTagMaps();
        CreateChapterMaps();
        CreateLanguageMaps();
        CreatePageMaps();
        CreateRatingMaps();
        CreateStatusMaps();
        CreateTagMaps();
    }

    private void CreateAuthorMaps()
    {
        CreateMap<AuthorRequestDTO, Author>();
        CreateMap<Author, AuthorResponseDTO>();
    }
    
    private void CreateBookAuthorMaps()
    {
        CreateMap<BookAuthorRequestDTO, BookAuthor>();
        CreateMap<BookAuthor, BookAuthorResponseDTO>()
            .ForMember("AuthorName" , x => x.MapFrom(a => a.Author.Name));

    }

    private void CreateBookCategoryMaps()
    {
        CreateMap<BookCategoryRequestDTO, BookCategory>();
        CreateMap<BookCategory, BookCategoryResponseDTO>()
            .ForMember("CategoryName", x => x.MapFrom(c => c.Category.Name));

    }

    private void CreateBookMaps()
    {
        CreateMap<BookRequestDTO, Book>();
        CreateMap<Book, BookResponseDTO>();
    }

    private void CreateBookTagMaps()
    {
        CreateMap<BookTagRequestDTO, BookTag>();
        CreateMap<BookTag, BookTagResponseDTO>()
            .ForMember("TagName", x => x.MapFrom(t => t.Tag.Name));
    }
    
    private void CreateCategoryMaps()
    {
        CreateMap<CategoryRequestDTO, Category>();
        CreateMap<Category, CategoryResponseDTO>();
    }

    private void CreateChapterMaps()
    {
        CreateMap<ChapterRequestDTO, Chapter>();
        CreateMap<Chapter, ChapterResponseDTO>();
    }

    private void CreateLanguageMaps()
    {
        CreateMap<LanguageRequestDTO, Language>();
        CreateMap<Language, LanguageResponseDTO>();
    }

    private void CreatePageMaps()
    {
        CreateMap<PageRequestDTO, Page>();
        CreateMap<Page, PageResponseDTO>();
    }

    private void CreateRatingMaps()
    {
        CreateMap<RatingRequestDTO, Rating>();
        CreateMap<Rating, RatingResponseDTO>();
    }

    private void CreateStatusMaps()
    {
        CreateMap<StatusRequestDTO, Status>();
        CreateMap<Status, StatusResponseDTO>();
    }

    private void CreateTagMaps()
    {
        CreateMap<TagRequestDTO, Tag>();
        CreateMap<Tag, TagResponseDTO>();
    }
    
}