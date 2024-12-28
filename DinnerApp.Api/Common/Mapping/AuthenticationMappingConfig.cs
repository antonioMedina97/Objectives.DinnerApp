using Mapster;
using DinnerApp.Application.Authentication.Commands.Register;
using DinnerApp.Application.Authentication.Common;
using DinnerApp.Application.Authentication.Queries.Login;
using DinnerApp.Contracts.Authentication;

namespace DinnerApp.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>(); 
        config.NewConfig<LoginRequest, LoginQuery>(); 
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}