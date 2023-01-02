using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.Dto;
using Be_bitirme.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserRequest, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public CheckUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(CheckUserRequest request, CancellationToken cancellationToken)
        {
            var dto = new UserDto();
            var user = await _userRepository.GetByFilterAsync(x => x.Email == request.Email && x.Password == request.Password);
            if(user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.Email = request.Email;
                dto.IsExist=true;
                dto.UserStatus = user.UserId;
                dto.UserStatus = user.UserStatus;
            }

            return dto;
        }
    }
}
