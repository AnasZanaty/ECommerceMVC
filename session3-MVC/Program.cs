using Demo.BLL.Interfaces;
using Demo.BLL.Reposatories;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using session3_MVC.Mapper;

namespace session3_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //„”∆Ê·… ⁄·Ï «‰Â«  ⁄„· ﬂ—ÌÌ  ··«Ê»Ãﬂ  «··Ì «‰« »⁄„·Â œÌ»‰œ‰”Ì «‰ÃÌﬂ‘‰ ›Ì ﬂ·«” «·—Ì»Ê”« Ê—Ì «··Ì »»«’Ì·Â ›Ì «Ê»Ãﬂ  «”„Â ﬂÊ‰ ﬂÌ” 
            builder.Services.AddDbContext<MVCAppDBContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //it means when i inject idepartmentreposatory interface it crates an object of departmentreposatory class
            builder.Services.AddScoped<IDepartmentReposatory, DepartmentReposatory>();
            builder.Services.AddScoped<IEmployeeReposatory, EmployeeReposatory>();
            builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie
                (CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString("/Account/SignIn");
                    options.AccessDeniedPath = new PathString("/Home/Error");
                } );
            builder.Services.AddAutoMapper(map => map.AddProfile(new MappingProfile()));
            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.SignIn.RequireConfirmedAccount = false;

            }).AddEntityFrameworkStores<MVCAppDBContext>()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

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
                pattern: "{controller=Account}/{action=SignUp}/{id?}");

            app.Run();
        }
    }
}