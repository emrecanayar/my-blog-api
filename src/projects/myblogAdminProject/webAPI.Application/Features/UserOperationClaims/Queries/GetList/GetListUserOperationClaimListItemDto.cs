﻿using Core.Application.Dtos;

namespace webAPI.Application.Features.UserOperationClaims.Queries.GetList
{
    public class GetListUserOperationClaimListItemDto : IDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
