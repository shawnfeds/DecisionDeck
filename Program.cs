using DecisionDeck.Contracts;
using DecisionDeck.MappingProfiles;
using DecisionDeck.Models;
using DecisionDeck.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// serilog configuration
builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var conString = builder.Configuration.GetConnectionString("DecisionDeckContext") ??
     throw new InvalidOperationException("Connection string 'DecisionDeckContext'" +
    " not found.");

builder.Services.AddScoped(typeof(IDecisionRepository<>), typeof(DecisionRepository<>));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IPollRepository), typeof(PollRepository));
builder.Services.AddScoped(typeof(IPollOptionRepository), typeof(PollOptionRepository));
builder.Services.AddScoped(typeof(IAlreadyVotedRepository), typeof(AlreadyVotedRepository));

builder.Services.AddAutoMapper(typeof(DecisionDeckProfiles));

builder.Services.AddDbContext<DecisionDeckContext>(options =>
    options.UseSqlServer(conString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
