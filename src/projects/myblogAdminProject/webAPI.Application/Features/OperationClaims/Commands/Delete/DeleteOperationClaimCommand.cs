﻿using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using webAPI.Application.Features.OperationClaims.Constants;
using webAPI.Application.Features.OperationClaims.Rules;
using webAPI.Application.Services.Repositories;
using static webAPI.Application.Features.OperationClaims.Constants.OperationClaimsOperationClaims;


namespace webAPI.Application.Features.OperationClaims.Commands.Delete
{
    public class DeleteOperationClaimCommand : IRequest<CustomResponseDto<DeletedOperationClaimResponse>>, ISecuredRequest
    {
        public Guid Id { get; set; }

        public string[] Roles => new[] { Admin, Write, OperationClaimsOperationClaims.Delete };

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, CustomResponseDto<DeletedOperationClaimResponse>>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public DeleteOperationClaimCommandHandler(
                IOperationClaimRepository operationClaimRepository,
                IMapper mapper,
                OperationClaimBusinessRules operationClaimBusinessRules
            )
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<CustomResponseDto<DeletedOperationClaimResponse>> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(
                    predicate: oc => oc.Id == request.Id,
                    include: q => q.Include(oc => oc.UserOperationClaims),
                    cancellationToken: cancellationToken
                );
                await _operationClaimBusinessRules.OperationClaimShouldExistWhenSelected(operationClaim);

                await _operationClaimRepository.DeleteAsync(entity: operationClaim!);

                DeletedOperationClaimResponse response = _mapper.Map<DeletedOperationClaimResponse>(operationClaim);
                return CustomResponseDto<DeletedOperationClaimResponse>.Success((int)HttpStatusCode.OK, response, true);
            }
        }
    }
}
