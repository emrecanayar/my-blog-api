﻿using Core.Domain.Entities;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Services.Repositories;

namespace webAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator =>
       _mediator ??=
           HttpContext.RequestServices.GetService<IMediator>()
           ?? throw new InvalidOperationException("IMediator cannot be retrieved from request services.");

        private IMediator? _mediator;
        protected IUserRepository _userRepository =>
           userRepository ??=
           HttpContext.RequestServices.GetService<IUserRepository>()
           ?? throw new InvalidOperationException("IUserRepository cannot be retrieved from request services.");

        private IUserRepository? userRepository;
        protected string getIpAddress()
        {
            string ipAddress = Request.Headers.ContainsKey("X-Forwarded-For")
                ? Request.Headers["X-Forwarded-For"].ToString()
                : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
                    ?? throw new InvalidOperationException("IP address cannot be retrieved from request.");
            return ipAddress;
        }

        protected Guid getUserIdFromRequest() //todo authentication behavior?
        {
            Guid userId = HttpContext.User.GetUserId();
            return userId;

        }

        protected User getUserFromRequest()
        {
            Guid userId = HttpContext.User.GetUserId();
            User? user = _userRepository.Get(x => x.Id == userId, enableTracking: false);
            return user;

        }
    }
}
