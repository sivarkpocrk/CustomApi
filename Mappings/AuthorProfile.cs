
using AutoMapper;
using CustomApi.Models;
namespace CustomApi.Mappings
{
public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorDTO>().ReverseMap();
    }
}
}