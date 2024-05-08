using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Dtos;
using DataAccessLayer.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUser _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUser userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserRegisterDto> Login(UserRegisterDto user)
        {
            var userModel = await _userRepository.GetByUser(user.UserName);

           

            if (userModel != null && VerifyPasswordHash(user.Password,Convert.FromBase64String(userModel.PasswordHash),Convert.FromBase64String(userModel.PasswordSalt)))
            {
                return _mapper.Map<UserRegisterDto>(userModel);
            }

            return null;
        }

        public async Task Register(UserRegisterDto user)
        {

            var userModel = _mapper.Map<User>(user);

            // Initialize UserRoles if it's null
            if (userModel.UserRoles == null)
            {
                userModel.UserRoles = new List<UserRole>();
            }

            // Add the user's role
            userModel.UserRoles.Add(new UserRole
            {
                User = userModel,
                Role = new Role { RoleName = "admin" }
            });

            byte[] passwordHash, passwordSalt;



            CreatePasswordHash(user.Password, out passwordHash, out passwordSalt); // Passing user.Password instead of user.PasswordHash
            userModel.PasswordHash = Convert.ToBase64String(passwordHash);
            userModel.PasswordSalt = Convert.ToBase64String(passwordSalt);
            await _userRepository.CreateUser(userModel);

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key; // Using hmac.Key generates a new random salt
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {

            using (var hmac = new HMACSHA512(passwordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);

            }

            return false;
        }
    }
}
