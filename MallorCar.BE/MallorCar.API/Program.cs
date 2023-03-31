using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MallorCar.Infrastructure;
using MallorCar.Infrastructure.Autofac;
using MallorCar.Infrastructure.ExternalServicesNotificationProvider;
using MallorCar.Infrastructure.Persistence.Repositories;
using MallorCarApplication.Common.Interfaces;
using MallorCarApplication.Dtos;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new DbContextAutofacModule(builder.Configuration["ConnectionString"]));
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(IMallorCarApplication).Assembly);
});

builder.Services.AddDbContext(builder.Configuration["ConnectionString"]!);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IRentalRepository), typeof(RentalRepository));
builder.Services.AddScoped(typeof(IExternalNotificationServicesProvider), typeof(ExternalServicesNotificationProvider));

var emailConfig = builder.Configuration.GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
var smsConfig = builder.Configuration.GetSection("SmsConfiguration")
    .Get<SmsConfiguration>();
builder.Services.AddSingleton(smsConfig);

var app = builder.Build();
app.MapControllers();
app.UseSwagger();
app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});


app.Run();