﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using eCommerceProject.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<eCommerceProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("eCommerceProjectContext") ?? throw new InvalidOperationException("Connection string 'eCommerceProjectContext' not found.")));
builder.Services.AddSession();
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
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
