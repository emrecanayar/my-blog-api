using Application.Features.Abouts.Commands.Create;
using Application.Features.Abouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using webAPI.Application.Features.UploadedFiles.Dtos;

namespace Application.Services.Abouts;

public class AboutsManager : IAboutsService
{
    private readonly IAboutRepository _aboutRepository;
    private readonly IMapper _mapper;
    private readonly AboutBusinessRules _aboutBusinessRules;

    public AboutsManager(IAboutRepository aboutRepository, AboutBusinessRules aboutBusinessRules, IMapper mapper)
    {
        _aboutRepository = aboutRepository;
        _aboutBusinessRules = aboutBusinessRules;
        _mapper = mapper;
    }

    public async Task<About?> GetAsync(
        Expression<Func<About, bool>> predicate,
        Func<IQueryable<About>, IIncludableQueryable<About, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        About? about = await _aboutRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return about;
    }

    public async Task<IPaginate<About>?> GetListAsync(
        Expression<Func<About, bool>>? predicate = null,
        Func<IQueryable<About>, IOrderedQueryable<About>>? orderBy = null,
        Func<IQueryable<About>, IIncludableQueryable<About, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<About> aboutList = await _aboutRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return aboutList;
    }

    public async Task<About> AddAsync(CreateAboutCommand createAboutCommand)
    {
        UploadedFileResponseDto uploadedFile = await _aboutBusinessRules.CheckCarouselItemTokenForAddAsync(createAboutCommand);
        About about = _mapper.Map<About>(createAboutCommand);
        MappedAboutItem(uploadedFile, about);
        About addedCarouselItem = await _aboutRepository.AddAsync(about);
        return addedCarouselItem;
    }

    public async Task<About> UpdateAsync(About about)
    {
        About updatedAbout = await _aboutRepository.UpdateAsync(about);

        return updatedAbout;
    }

    public async Task<About> DeleteAsync(About about, bool permanent = false)
    {
        About deletedAbout = await _aboutRepository.DeleteAsync(about);

        return deletedAbout;
    }

    private static void MappedAboutItem(UploadedFileResponseDto uploadedFile, About about)
    {
        about.UploadedFileId = uploadedFile.Id;
    }
}
