using CarDealershipManagement.Core.Dto.UseCaseResponses;
using CarDealershipManagement.Core.Interfaces;

namespace CarDealershipManagement.Core.Dto.UseCaseRequests
{
  public class RegisterUserRequest : IUseCaseRequest<RegisterUserResponse>
  {
    public string UserName { get; }
    public string Password { get; }

    public RegisterUserRequest(string userName, string password)
    {
      UserName = userName;
      Password = password;
    }
  }
}
