using CarDealershipManagement.Core.Dto.UseCaseRequests;
using CarDealershipManagement.Core.Dto.UseCaseResponses;
using CarDealershipManagement.Core.Interfaces;
using CarDealershipManagement.Core.Interfaces.Gateways.Repositories;
using CarDealershipManagement.Core.Interfaces.UseCases;
using CarDealershipManagement.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.UseCases
{
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.Create(new User { UserName = message.UserName}, message.Password);
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, true) : new RegisterUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
