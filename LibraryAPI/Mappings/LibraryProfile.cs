using AutoMapper;
using LibraryAPI.DTOs;
using LibraryAPI.Models;

namespace LibraryAPI.Mappings
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            // Mapping from Book to BookDto
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));

            // Mapping from BookDto to Book
            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Author, opt => opt.Ignore()); // Author will be set separately

            // Mapping from Author to AuthorDto
            CreateMap<Author, AuthorDto>();

            // Reverse mapping (from DTOs back to entities)
            CreateMap<AuthorDto, Author>();
        }
    }
}
