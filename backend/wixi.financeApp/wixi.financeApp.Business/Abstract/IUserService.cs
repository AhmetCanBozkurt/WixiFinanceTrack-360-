using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wixi.financeApp.Entities.Dtos;
using wixi.financeApp.Entities.Modals;

namespace wixi.financeApp.Business.Abstract
{
    public interface IUserService
    {
        Task<ApiResponse> Register(RegisterRequestDto model);

        Task<ApiResponse> Login(LoginRequestDto model);

    }
}
