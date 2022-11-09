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
        CreateTestMaps();
        CreateAuthorMaps();
        CreateCategoryMaps();
        CreateBookMaps();
        CreateBookTagMaps();
        CreateChapterMaps();
        CreateLanguageMaps();
        CreatePageMaps();
        CreateRatingMaps();
        CreateStatusMaps();
        CreateTagMaps();
        CreateUserBookMaps();
    }

    private void CreateTestMaps()
    {
        CreateMap<Test, TestDTO>();
        CreateMap<TestDTO, Test>();
    }

    private void CreateAuthorMaps()
    {
        CreateMap<AuthorRequestDTO, Author>();
        CreateMap<Author, AuthorResponseDTO>();
    }

    private void CreateBookMaps()
    {
        CreateMap<BookRequestDTO, Book>();
        CreateMap<Book, BookResponseDTO>();
    }

    private void CreateBookTagMaps()
    {
        CreateMap<BookTagRequestDTO, BookTag>();
        CreateMap<BookTag, BookTagResponseDTO>();
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

    private void CreateUserBookMaps()
    {
        CreateMap<UserBookRequestDTO, UserBook>();
        CreateMap<UserBook, UserBookResponseDTO>();
    }
    
}