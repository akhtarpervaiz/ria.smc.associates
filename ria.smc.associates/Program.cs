using ria.smc.associates.DataAccessLayer.Common;
using ria.smc.associates.DataAccessLayer.Interfaces.Dashboard;
using ria.smc.associates.DataAccessLayer.Interfaces.EmployeeManagement;
using ria.smc.associates.DataAccessLayer.Interfaces.MasterData;
using ria.smc.associates.DataAccessLayer.Interfaces.Users;
using ria.smc.associates.DataAccessLayer.Repositories.Dashboard;
using ria.smc.associates.DataAccessLayer.Repositories.EmployeeManagement;
using ria.smc.associates.DataAccessLayer.Repositories.MasterData;
using ria.smc.associates.DataAccessLayer.Repositories.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IGenericRepository, GenericRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IDashboardItemsRepository, DashboardItemsRepository>();
builder.Services.AddTransient<IMasterDataRepository, MasterDataRepository>();
builder.Services.AddTransient<IEmployeeManagementRepository, EmployeeManagementRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
