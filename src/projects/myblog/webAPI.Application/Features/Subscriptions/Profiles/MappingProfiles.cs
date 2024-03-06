using Application.Features.Subscriptions.Commands.Create;
using AutoMapper;
using Core.Domain.Entities;

namespace Application.Features.Subscriptions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Subscription, CreateSubscriptionCommand>().ReverseMap();
        CreateMap<Subscription, CreatedSubscriptionResponse>().ReverseMap();
    }
}