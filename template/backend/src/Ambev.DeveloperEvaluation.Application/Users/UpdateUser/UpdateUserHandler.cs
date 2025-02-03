using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAddressReporitory _addressReporitory;

        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, IAddressReporitory addressReporitory)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _addressReporitory = addressReporitory;
        }

        public async Task<UpdateUserResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Id, cancellationToken);


            if (existingUser == null)
                throw new KeyNotFoundException("User not found");

            var newUser = _mapper.Map<User>(request);
            newUser.Password = _passwordHasher.HashPassword(request.Password);
            var userResult = await _userRepository.UpdateUser(newUser, existingUser, cancellationToken);

            if (userResult == null)
                throw new Exception("User not updated");

            var address = _mapper.Map<UserAddress>(request.Address);
            await _addressReporitory.AddOrUpdateAddresses(userResult.Id, address, cancellationToken);

            userResult.UserAddress = address;

            return _mapper.Map<UpdateUserResult>(userResult);

        }
    }
}
