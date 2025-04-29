using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wixi.financeApp.Business.Abstract;
using wixi.financeApp.DataAccess.Context;
using wixi.financeApp.Entities.Dtos;
using wixi.financeApp.Entities.Modals;



/// Şidmiki yaptığımız Buiness üzerinden db işlemleri 
/// Repository design patterna a geçiricez


namespace wixi.financeApp.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly ApiResponse _apiResponse;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly RoleManager<IdentityRole> _roleManager;
        

        public UserService(
              ApplicationDbContext context,
            ApiResponse apiResponse,
            UserManager<ApplicationUser> usermanager,
            RoleManager<IdentityRole> roleManager
         

            )
        {
            _roleManager = roleManager;
            _context = context;
            _apiResponse = apiResponse;
            _usermanager = usermanager;
        }

        public Task<ApiResponse> Register(RegisterRequestDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> Login(LoginRequestDto model)
        {
       
            ApplicationUser UserFromDb = _context.ApplicationUsers.FirstOrDefault(x => x.UserName.ToLower() == model.UserName.ToLower()); // eşleşen kullanıcıyı bul

            if (UserFromDb == null) /// Kullanıcı yok ise sistemde bu mesajı döndürecek
            {
                _apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                _apiResponse.ErrorMessages.Add( "Kullanıcı bulunamadı");
                return _apiResponse;
            }
            else
            {
                bool isValidPassword = _usermanager.CheckPasswordAsync(UserFromDb, model.Password).Result; // Kullanıcı varsa şifreyi kontrol et
               
                if (!isValidPassword) /// Şifre yanlış ise bu mesajı döndürecek
                {
                    _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _apiResponse.ErrorMessages.Add("Şifre yanlış");
                    return _apiResponse;
                }
                else /// Kullanıcı ve şifre doğru ise bu mesajı döndürecek
                {
                    var role = await _usermanager.GetRolesAsync(UserFromDb);

                    /// Token üretme alanını koyacağız 

                    _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    _apiResponse.Result = UserFromDb;
                    return _apiResponse;
                }
            }



        }
    }   
 
}
