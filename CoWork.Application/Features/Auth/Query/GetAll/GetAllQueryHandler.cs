using AutoMapper;
using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.DTOs.Member;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Auth.Query.GetAll
{
    public class GetAllQueryHandler : IQueryHandler<GetAllQuery, IEnumerable<UserDto>>
    {
        private readonly IAuthService _authService;
        public GetAllQueryHandler(IAuthService authService)
        {
            _authService = authService; 
        }
        public Task<IEnumerable<UserDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return _authService.GetAllAsync();

        }
    }
}
