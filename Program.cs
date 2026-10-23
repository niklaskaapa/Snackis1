using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Snackis1.Components;
using Snackis1.Components.Account;
using Snackis1.Data;
using Snackis1.Data.Repositories;
using Snackis1.Services;
using Snackis1.Data.Seed;

namespace Snackis1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();


            // om vi vill lägga till felmeddelanden som blir lite vettigare i Azure, hamnar i consolen.
            //builder.Services.AddServerSideBlazor()
            //    .AddCircuitOptions(options =>
            //    {
            //        options.DetailedErrors = true;
            //    });



            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            //Vid lokalt: "DefaultConnection" Vid Azure: "AzureConnection" (kör update database),

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzåäöABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ0123456789-._";
                    options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();



            builder.Services.AddScoped<IForumRepository, ForumRepository>();
            builder.Services.AddScoped<IPrivateMessageRepository, PrivateMessageRepository>();
            builder.Services.AddScoped<IReportRepository, ReportRepository>();

            builder.Services.AddScoped<ForumService>();
            builder.Services.AddScoped<PrivateMessageService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<ReportService>();
            builder.Services.AddScoped<CurrentUserService>();


            builder.Services.AddHttpClient<PostApiService>(
                client =>
                {
                    //client.BaseAddress = new Uri("https://localhost:7250/");  //När APIt var separat

                   client.BaseAddress = new Uri("https://localhost:7200/");

                    // Kör en ny publish med denna om API i samma projekt
                    //client.BaseAddress = new Uri("https://snackisnkwebbapp-gbhmcdfvbghtahg9.swedencentral-01.azurewebsites.net/");


                });


            builder.Services.AddControllers();


            var app = builder.Build();

            await IdentitySeeder.SeedAdminAsync(app);



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseAntiforgery();

            app.MapStaticAssets();

            // Lägg till denna för bilderna. Ser till att filerna via wwwroot hanteras rätt
              app.UseStaticFiles();


            app.MapControllers();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            await app.RunAsync();
        }
    }
}
