using BlazorApp.Data;
using Blazored.Modal;
using CommonCode.Services;
using CurrieTechnologies.Razor.SweetAlert2;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<IPersonService, PersonService>();

builder.Services.AddScoped<Radzen.DialogService>();

builder.Services.AddSweetAlert2();

builder.Services.AddBlazoredModal();



// new injections for sql from Dapper and after 

//builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

//builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


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
