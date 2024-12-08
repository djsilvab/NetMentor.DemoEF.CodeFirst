using Microsoft.EntityFrameworkCore;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Data.Repositories;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NorthwindContext>(options => {
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

using (var scope = app.Services.CreateScope()) 
{ 
    NorthwindContext context = scope.ServiceProvider.GetRequiredService<NorthwindContext>();
    context.Database.Migrate();
}

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
