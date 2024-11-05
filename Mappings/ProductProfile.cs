using AutoMapper;
using CustomApi.Models; // Replace with the correct namespace for Product

namespace CustomApi.Mappings 
{

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
}


