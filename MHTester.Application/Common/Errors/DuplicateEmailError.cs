﻿using FluentResults;

namespace MHTester.Application.Common.Errors;

public class DuplicateEmailError : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
};
