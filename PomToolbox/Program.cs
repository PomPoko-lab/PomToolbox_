using PomToolbox.Components;
using PomToolbox.Services.ApiServices;
using PomToolbox.Services.Interfaces;
using PomToolbox.Data.Repositories;

using dotenv.net;
using Blazored.LocalStorage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
DotEnv.Load();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPokemonTcgApiService, PokemonTcgApiService>();
builder.Services.AddScoped<IPokemonCollectionRepository, PokemonCollectionRepository>();

builder.Services.AddBlazoredLocalStorage();

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
