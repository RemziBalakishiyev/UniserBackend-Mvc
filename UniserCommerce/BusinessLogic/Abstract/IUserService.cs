using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IUserService
    {
        Task Register(UserRegisterDto user);
        Task<UserRegisterDto> Login(UserRegisterDto user);

    }
}
