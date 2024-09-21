using fantasticfive1.Components;
using Microsoft.EntityFrameworkCore;

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
.AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddScoped<fantasticfive1.Data.LookupService>();

var connectionString = builder.Configuration.GetConnectionString("SupportDb");
builder.Services.AddDbContextFactory<SupportDataContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.UseStaticFiles();
app.UseAntiforgery();

app.Run();
