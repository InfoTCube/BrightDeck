using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Utility;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DeckForCreationDto, Deck>();
        CreateMap<FlashcardForCreationDto, Flashcard>();
        CreateMap<Deck, DeckDto>()
            .ForMember(d => d.AuthorUsername, opt => opt.MapFrom(src => src.Author.UserName));
        CreateMap<UserForRegistrationDto, AppUser>();
    }
}