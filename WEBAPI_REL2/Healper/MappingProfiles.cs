using AutoMapper;
using WEBAPI_REL2.Dto;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Healper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<PokemonDto, Pokemon>();
            CreateMap<Category,CatagoryDto>();
            CreateMap<CatagoryDto, Category>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto,Country>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            CreateMap<Reviewer, ReviewerDto>();
            CreateMap<ReviewerDto, Reviewer>();
        }
    }
}
