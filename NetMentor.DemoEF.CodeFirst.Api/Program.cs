using Microsoft.EntityFrameworkCore;
using NetMentor.DemoEF.CodeFirst.Data.Connections;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Data.Repositories;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using NetMentor.DemoEF.CodeFirst.Data.Services;
using NetMentor.DemoEF.CodeFirst.Data.Services.Interfaz;
using NetMentor.DemoEF.CodeFirst.Data.UnitOfWork;
using NetMentor.DemoEF.CodeFirst.Entities.Settings;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<NorthwindContext>(options => {
//    options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection"));
//});


builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMySql(builder.Configuration);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWorkingExperienceRepository, WorkingExperienceRepository>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<CreateUserWithExperiencesService>();
builder.Services.AddScoped<InsertUserOnlyService>();
builder.Services.AddScoped<UpdateUserAndEmailService>();

//builder.Services.AddSingleton(x =>
//{
//    SmtpSettings smptSettings = new SmtpSettings();
//    builder.Configuration.Bind("SmtpService", smptSettings);
//    return smptSettings;
//}).AddScoped<ISenderSmtpService,SenderSmptService>();

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpService"))
    .PostConfigure<SmtpSettings>(config => {
        if (string.IsNullOrEmpty(config.Servidor)) throw new Exception("El servidor está vacío");
    });


//==>
//IOptions<SmtpSettings>
//IOptionsSnapshot<SmtpSettings>
//IOptionsMonitor<SmtpSettings>

builder.Services.AddScoped<ISenderSmtpService, SenderSmptService>();

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
