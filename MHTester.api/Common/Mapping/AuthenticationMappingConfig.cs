using Mapster;
using MHTester.Application.Authentication.Commands.Register;
using MHTester.Application.Authentication.Common;
using MHTester.Application.Authentication.Queries.Login;
using MHTester.Contracts.Authentication;

namespace MHTester.api.Common.Mapping;

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