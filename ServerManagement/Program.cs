using Microsoft.EntityFrameworkCore;
using ServerManagement.Components;
using ServerManagement.Data;
using ServerManagement.Models;
using ServerManagement.StateStore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents(); //render için
builder.Services.AddDbContextFactory<ServerManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServerManagement")));

builder.Services.AddTransient<SessionStorage>();
//builder.Services.AddScoped<ContainerStorage>();
builder.Services.AddScoped<TorontoOnlineServerStore>();
builder.Services.AddScoped<MontrealOnlineServerStore>();
builder.Services.AddScoped<CalgaryOnlineServerStore>();
builder.Services.AddScoped<OttawaOnlineServerStore>();
builder.Services.AddScoped<HalifaxOnlineServerStore>();

builder.Services.AddTransient<IServerEFCoreRepository, ServerEFCoreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().
    AddInteractiveServerRenderMode();// sayfa yenilemeden render etmesi

app.Run();
