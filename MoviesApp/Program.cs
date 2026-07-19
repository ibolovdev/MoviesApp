using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Services;

namespace MoviesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            //Simple authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/Login";//redirect to here if the user is not loggedin
        options.AccessDeniedPath = "/Denied";//the user is loggedin but is not authorized to access the page
    });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("GraduatedOnly", policy => policy.RequireClaim("GraduationYear", "2010", "2012", "2015"));
            });



            //   builder.Services.AddTransient<IMoviesSrv,MoviesService>();//for each request a new reference is going to be created
            builder.Services.AddScoped<IMoviesSrv, MoviesService>();//for each page a new reference is going to be created


            builder.Services.AddDbContext<ApplicationDBContext>(options => 
                                                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnStr")));

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
        }
    }
}