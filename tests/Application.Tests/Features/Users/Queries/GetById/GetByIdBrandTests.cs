﻿using Application.Features.Users.Queries.GetById;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Application.ResponseTypes.Concrete;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Users.Queries.GetById.GetByIdUserQuery;

namespace Application.Tests.Features.Users.Queries.GetById;

public class GetByIdUserTests : UserMockRepository
{
    private readonly GetByIdUserQuery _query;
    private readonly GetByIdUserQueryHandler _handler;

    public GetByIdUserTests(UserFakeData fakeData, GetByIdUserQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetByIdUserQueryHandler(MockRepository.Object, Mapper, BusinessRules);
    }

    [Fact]
    public async Task GetByIdUserShouldSuccessfully()
    {
        _query.Id = Guid.Parse("e16d144a-8684-4f28-8d24-e816a560dfb3");

        CustomResponseDto<GetByIdUserResponse> result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: "example@email.com", result.Data.Email);
    }

}
