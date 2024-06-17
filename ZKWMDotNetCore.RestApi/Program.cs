using Microsoft.EntityFrameworkCore;
using ZKWMDotNetCore.RestApi.Db;
using ZKWMDotNetCore.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string ConnectionString = builder.Configuration.GetConnectionString("DbConnection")!;


builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(ConnectionString), ServiceLifetime.Transient, ServiceLifetime.Transient);

//builder.Services.AddScoped<AdoDotNetService>(n => new AdoDotNetService(ConnectionString));
//builder.Services.AddScoped<DapperService>(n => new DapperService(ConnectionString));


builder.Services.AddScoped(n => new AdoDotNetService(ConnectionString));
builder.Services.AddScoped(n => new DapperService(ConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
