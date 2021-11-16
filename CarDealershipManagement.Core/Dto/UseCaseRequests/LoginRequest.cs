using CarDealershipManagement.Core.Dto.UseCaseResponses;
using CarDealershipManagement.Core.Interfaces;

namespace CarDealershipManagement.Core.Dto.UseCaseRequests
{
  public class LoginRequest : IUseCaseRequest<LoginResponse>
  {
    public string UserName { get; }
    public string Password { get; }

    public LoginRequest(string userName, string password)
    {
      UserName = userName;
      Password = password;
    }
  }
}
