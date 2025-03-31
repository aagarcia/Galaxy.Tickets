using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Galaxy.Tickets.AccesoDatos.Contexto;
using Galaxy.Tickets.Repositorios.Implementaciones;
using Galaxy.Tickets.Repositorios.Interfaces;
using Galaxy.Tickets.Servicio.Implementaciones;
using Galaxy.Tickets.Servicio.Interfaces;
using Galaxy.Tickets.Servicio.Mappers;
using Galaxy.Tickets.UI.Components;
using Microsoft.EntityFrameworkCore;
using Scrutor;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazoredToast();
builder.Services.AddSweetAlert2();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<DbTicketsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbTickets"));
});

builder.Services.Scan(p => p
	.FromAssemblies(typeof(ICategoriaRepositorio).Assembly, typeof(ICategoriaServicio).Assembly)
	.AddClasses(false)
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
	.AsMatchingInterface()
	.WithScopedLifetime());

builder.Services.AddAutoMapper(p => {
    p.AddMaps(typeof(RolMap).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
