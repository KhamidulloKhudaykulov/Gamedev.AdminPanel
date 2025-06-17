using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mirradev.Admin.Api.Application.UseCases.Admins.Commands;
using Mirradev.Admin.Api.Application.UseCases.Clients.Queries;
using Mirradev.Admin.Api.Application.UseCases.Payments.Queries;
using Mirradev.Admin.Api.Application.UseCases.Rates.Commands;
using Mirradev.Admin.Api.Application.UseCases.Rates.Queries;
using Mirradev.Admin.Api.Contracts;
using Mirradev.Admin.Api.Extensions;
using Mirradev.Admin.Api.Persistence;
using AuthenticationMiddleware = Mirradev.Admin.Api.Middlewares.AuthenticationMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:80");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

builder.Services.AddAdminApi(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DbInitializer.Initialize(app.Services);

app.UseCors("AllowLocalhost5173");

app.UseMiddleware<AuthenticationMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/auth", async ([FromQuery] string login, string password , ISender _sender) =>
{
    var command = new LoginAdminCommand(login, password);
    var token = await _sender.Send(command);
    if (token is null)
        return Results.Unauthorized();

    return Results.Ok(new { token });
});

app.MapGet("/payments", async ([FromQuery] int amount, ISender _sender) =>
{
    var query = new GetLastNPaymentsQuery(amount);
    var payments = await _sender.Send(query);
    var result = payments.Select(p => new PaymentResponseDTO()
    {
        Id = p.Id,
        Amount = p.Amount,
        ClientId = p.ClientId,
        CreatedAt = p.CreatedAt.ToString("dd.MM.yyyy")
    });
    
    return Results.Ok(result);
});

app.MapGet("/clients", async (ISender _sender)=>
{
    var query = new GetAllClientsQuery();
    var clients = await _sender.Send(query);
    var result = clients.Select(c => new ClientResponseDTO()
    {
        Id = c.Id,
        Name = c.Name,
        Email = c.Email,
        BalanceToken = c.BalanceToken
    });
    
    return Results.Ok(result);
});


app.MapGet("/rate", async (ISender _sender)=>
{
    var query = new GetCurrentRateQuery();
    var result = await _sender.Send(query);
    return Results.Ok(result);
});


app.MapPost("/rate", async ([FromQuery] decimal value, ISender _sender)=>
{
    var command = new UpdateRateCommand(value);
    var result = await _sender.Send(command);
    return Results.Ok(result);
});

app.Run();
