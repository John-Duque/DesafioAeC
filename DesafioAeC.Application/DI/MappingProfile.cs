using AutoMapper;
using DesafioAeC.Domain.Entities;
using DesafioAeC.Domain.Views;

namespace DesafioAeC.Application.DI
{
    public class MappingProfile : Profile
    {
		public MappingProfile()
		{
            CreateMap<AluraEntity, AluraView>().ReverseMap();
        }
    }
}

