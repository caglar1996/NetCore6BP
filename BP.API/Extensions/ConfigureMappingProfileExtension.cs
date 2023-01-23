using AutoMapper;

namespace BP.API.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton<IMapper>(mapper);

            return service;
        }
    }
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<BP.API.Data.Models.Contact, BP.API.Models.ContactDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id)) // propertie isimleri aynı olunca direk atama yapabiliyor. örnek olsun diye yazdım
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName))
                .ReverseMap();// ReverseMap 2 türlüde dönüşümü desteklesin diye
        }
    }
}
