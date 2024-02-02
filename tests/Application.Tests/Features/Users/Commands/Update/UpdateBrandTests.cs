﻿using Application.Features.Users.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Application.ResponseTypes.Concrete;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Users.Commands.Update.UpdateUserCommand;

namespace Application.Tests.Features.Users.Commands.Update;

public class UpdateUserTests : UserMockRepository
{
    private readonly UpdateUserCommandValidator _validator;
    private readonly UpdateUserCommand _command;
    private readonly UpdateUserCommandHandler _handler;

    public UpdateUserTests(UserFakeData fakeData, UpdateUserCommandValidator validator, UpdateUserCommand command)
        : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new UpdateUserCommandHandler(MockRepository.Object, Mapper, BusinessRules);
    }

    [Fact]
    public void UserEmailEmptyShouldReturnError()
    {
        _command.Email = string.Empty;

        ValidationFailure? result = _validator
            .Validate(_command)
            .Errors.FirstOrDefault(x => x.PropertyName == "Email" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator);

        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }

    [Fact]
    public void UserEmailNotMatchEmailRuleShouldReturnError()
    {
        _command.Email = "NotEmailFormat";

        ValidationFailure? result = _validator
            .Validate(_command)
            .Errors.FirstOrDefault(x => x.PropertyName == "Email" && x.ErrorCode == ValidationErrorCodes.EmailValidator);

        Assert.Equal(ValidationErrorCodes.EmailValidator, result?.ErrorCode);
    }

    [Fact]
    public async Task UpdateShouldSuccessfully()
    {
        _command.Id = Guid.Parse("e16d144a-8684-4f28-8d24-e816a560dfb3");
        _command.FirstName = "First";
        _command.LastName = "Last";
        _command.Email = "test@email.com";
        _command.Password = "password";

        CustomResponseDto<UpdatedUserResponse> result = await _handler.Handle(_command, CancellationToken.None);

        Assert.Equal(expected: "test@email.com", result.Data.Email);
    }

}
