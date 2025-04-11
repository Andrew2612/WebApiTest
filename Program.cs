using Microsoft.EntityFrameworkCore;
using TestWebApp.Components.AdvertisingPlatforms.Api;
using DbContext = TestWebApp.Components.AdvertisingPlatforms.Implementation.DbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContext>(options =>
        options.UseInMemoryDatabase(databaseName: "PlatformLocalizations"));

builder.Services.AddScoped<IDbContext, DbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
