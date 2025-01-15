using Carter;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCarter();

var app = builder.Build();

app.UseExceptionHandler(exceptionHandleApp 
    => exceptionHandleApp.Run(async context 
        => await Results.Problem().ExecuteAsync(context)));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapCarter();

MigrateDatabase();

app.Run();

void MigrateDatabase() {
    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}