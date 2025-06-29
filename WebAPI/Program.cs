using Domain_BLL.Interfaces;
using Domain_BLL.Mappings;
using Domain_BLL.Services;
using Infrastructure_DAL.Data;
using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<BankSystemDb3Context>();
builder.Services.AddAutoMapper(typeof(PersonProfile));

builder.Services.AddScoped<CountryData>();
builder.Services.AddScoped<CountryService>();

builder.Services.AddScoped<JobTitleData>();
builder.Services.AddScoped<JobTitleService>();

builder.Services.AddScoped<TransactionTypeData>();
builder.Services.AddScoped<TransactionTypeService>();

builder.Services.AddScoped<IClientData, ClientData>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<IEmployeeData, EmployeeData>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IPersonData, PersonData>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddScoped<ITransactionData, TransactionData>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddScoped<ITransferHistory, TransferHistoryData>();
builder.Services.AddScoped<ITransferHistoryService, TransferHistoryService>();

builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IUserService, UserService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
