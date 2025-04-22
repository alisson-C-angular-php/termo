using entity.Context;
using entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var customConfig = new Configuration();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<Configuration>();

builder.Services.AddDbContext<TermoContext>(options =>
    options.UseSqlServer(customConfig.ConnectionString)
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //  app.UseHsts();
}




app.MapControllers();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
