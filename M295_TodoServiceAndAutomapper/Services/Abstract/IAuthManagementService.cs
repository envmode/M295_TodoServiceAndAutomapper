using M295_TodoServiceAndAutomapper.Models.DTO.Requests;

namespace M295_TodoServiceAndAutomapper.Services.Abstract
{
    public interface IAuthManagementService
    {
        Task<RegistrationResponse> Register(UserRegistrationRequestDTO user);

        Task<RegistrationResponse> Login(UserLoginRequest user);
    }
}