using CarDealershipManagement.Core.Dto.UseCaseRequests;
using CarDealershipManagement.Core.Dto.UseCaseResponses;

namespace CarDealershipManagement.Core.Interfaces.UseCases
{
    public interface IRegisterUserUseCase : IUseCaseRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
    }
}
