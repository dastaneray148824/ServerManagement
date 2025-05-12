using ServerManagement.Components;
using ServerManagement.StateStore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents(); //render için

builder.Services.AddTransient<SessionStorage>();
//builder.Services.AddScoped<ContainerStorage>();
builder.Services.AddScoped<TorontoOnlineServerStore>();
builder.Services.AddScoped<MontrealOnlineServerStore>();
builder.Services.AddScoped<CalgaryOnlineServerStore>();
builder.Services.AddScoped<OttawaOnlineServerStore>();
builder.Services.AddScoped<HalifaxOnlineServerStore>();

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
