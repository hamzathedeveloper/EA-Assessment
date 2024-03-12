using EmiratesAuction.Data;
using EmiratesAuction.HttpClients.Refit.Interfaces;
using EmiratesAuction.ReportingDataService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;
using MudBlazor;
using MudBlazor.Services;
using Refit;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();
builder.Services.AddScoped<IReportingData, ReportingData>();
builder.Configuration.AddJsonFile("appsettings.json");

// Configure Refit client
var apiUrl = builder.Configuration.GetValue<string>("MyApiUrl");
var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) };
var myApiClient = RestService.For<IDataApi>(httpClient);
builder.Services.AddSingleton(myApiClient);
builder.Services.AddMudBlazorSnackbar(config =>
{
    config.PositionClass = Defaults.Classes.Position.TopRight;
    config.PreventDuplicates = false;
    config.NewestOnTop = true;
    config.ShowCloseIcon = true;
    config.VisibleStateDuration = 10000;
    config.HideTransitionDuration = 500;
    config.ShowTransitionDuration = 500;
    config.SnackbarVariant = Variant.Filled;

}
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
