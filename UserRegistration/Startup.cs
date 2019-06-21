using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UserRegistration.Email;
using UserRegistration.Models;
using UserRegistration.Models.Client;
//using UserRegistration.Models.HeroCompany;

namespace UserRegistration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<HeroLING>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connection")));
            services.AddDbContext<HeroContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HeroDb")));
            services.AddDbContext<ClientContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MDNdemo")));
            //services.AddDbContext<HeroCompanyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HeroDb")));
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddCors(options=> {
                options.AddDefaultPolicy(
           builder =>
           {
               builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
           });
            });
            services.AddDefaultIdentity<User>(config=> { config.SignIn.RequireConfirmedEmail = true; }).AddEntityFrameworkStores<UserContext>();

            var key = Encoding.ASCII.GetBytes("f9a32479-4549-4cf2-ba47-daa00c3f2afe");
            var K = new SymmetricSecurityKey(key);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = K,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, HeroLING hero)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseAuthentication();
            app.UseCors();
            app.UseMvc();
            
            

        }
    }
}
