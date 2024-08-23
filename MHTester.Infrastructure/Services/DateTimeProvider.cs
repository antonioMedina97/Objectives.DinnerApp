using MHTester.Application.Common.Interfaces.Services;

namespace MHTester.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}