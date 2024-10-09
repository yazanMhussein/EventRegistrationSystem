using Event_Registration_System.data;
using Event_Registration_System.Services.Interfaces;
using Event_Registration_System.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Event_Registration_System.Models;

namespace Event_Registration_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;
           
            string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

            builder.Services.AddDbContext<MainDBContext>(options => options.UseSqlServer(ConnectionString));

            builder.Services.AddIdentity<UserAuth, IdentityRole>(
                options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = true;
                }
                ).AddEntityFrameworkStores<MainDBContext>();


            builder.Services.AddScoped<IUser, IdentityUserService>();
            builder.Services.AddScoped<MailjetService>();
            //builder.Services.AddScoped(provider => { var configuration = provider.GetRequiredService<IConfiguration>(); string apiKey = configuration["Mailjet:ApiKey"]; string secretKey = configuration["Mailjet:SecretKey"]; return new Mailjet.Client.MailjetClient(apiKey, secretKey); }); // Register MailjetService builder.Services.AddScoped<MailjetService>();


            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            builder.Services.ConfigureApplicationCookie
                (

                options => options.LoginPath = "/Auth/Signup"
                );
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
