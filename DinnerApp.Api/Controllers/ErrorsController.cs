﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        // var (statusCode, message) = exception switch
        // {
        //     DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists."),
        //     _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        // };
        
        return Problem();
    }
}