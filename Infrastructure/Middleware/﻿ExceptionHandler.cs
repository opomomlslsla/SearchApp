﻿using System.Data.Common;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Infrastructure.Middleware;

public class ExceptionHandler(RequestDelegate requestDelegate, ILogger logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await requestDelegate(httpContext);
        }
        catch (ArgumentException ex)
        {
            logger.Error($"{ex.Message} \n {ex.InnerException} \n {ex.StackTrace} \n");
            string msg = $"{ex.Message}";
            await HandleExeptionAsync(httpContext, msg, HttpStatusCode.BadRequest);
        }
        catch(DbException ex)
        {
            logger.Error($"{ex.Message} \n {ex.InnerException} \n {ex.StackTrace} \n");
            string msg = $"{ex.Message} \n {ex.InnerException} \n {ex.StackTrace} \n";
            await HandleExeptionAsync(httpContext, msg, HttpStatusCode.InternalServerError);
        }
        catch(Exception ex)
        {
            logger.Error($"{ex.Message} \n {ex.InnerException} \n {ex.StackTrace} \n");
            string msg = $"Internal server error ";
            await HandleExeptionAsync(httpContext, msg, HttpStatusCode.InternalServerError);

        }
    }
    private async Task HandleExeptionAsync(HttpContext httpContext, string msg, HttpStatusCode statusCode)
    {
        HttpResponse response = httpContext.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)statusCode;
        await response.WriteAsync(JsonSerializer.Serialize(msg));
    }
}