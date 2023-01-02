using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Handlers
{
    public class RegisterUserRequestHandler: IRequestHandler<RegisterUserRequest>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserRequestHandler(IUserRepository userRepository)
        {
           _userRepository = userRepository;
        }

        public async Task<Unit> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            await _userRepository.CreateAsync(new User
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                City = request.City,
                Password = request.Password,
                UserStatus = 1
            });
            return Unit.Value;
        }
    }

    public class UserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public UserRequestValidator(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(u => u.Email).NotEmpty().NotNull().EmailAddress()
                .WithMessage("Email must be an email 'example@exaple.com'");
            RuleFor(u => u.Email).Must(UniqueEmail).WithMessage("There is already a user with this email.");
            RuleFor(u => u.Password).NotEmpty().NotNull().MinimumLength(10).Must(password => password.Any(char.IsUpper))
                .WithMessage("Password must be atleast 10 charters long and have an upper character");
            RuleFor(u => u.SecondPassword).NotEmpty().NotNull().MinimumLength(10).Must(pass => pass.Any(char.IsUpper))
                .WithMessage("Second Password must be atleast 10 charters long and have an upper character");
            RuleFor(x => x.Password).Equal(x => x.SecondPassword)
                .WithMessage("Password and Second Password must match");
            _context = context;
        }
        private readonly ApplicationDbContext _context;
        private bool UniqueEmail(string email)
        {
            
            var dbUser = _context.Users.SingleOrDefault(u => u.Email == email);

            if (dbUser == null)
                return true;
            else
                return false;        
        }
    }
}
