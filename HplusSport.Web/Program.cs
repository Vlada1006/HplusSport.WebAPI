using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HplusSport.Web.Data;
using HplusSport.Web;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HplusSportWebContextConnection") ?? throw new InvalidOperationException("Connection string 'HplusSportWebContextConnection' not found.");

builder.Services.AddDbContext<HplusSportWebContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<HplusSportWebUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<HplusSportWebContext>();

// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
