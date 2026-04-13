using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Contacts.UseCases.CreateContact;
using ContactsApp.Core.Contacts.UseCases.DeleteContact;
using ContactsApp.Core.Contacts.UseCases.GetContactById;
using ContactsApp.Core.Contacts.UseCases.UpdateContact;
using ContactsApp.Core.Services.Email;
using ContactsApp.Infrastructure.Email;
using ContactsApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder.Extensions;
using Serilog;

namespace ContactsApp.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // logging
            Log.Logger = new LoggerConfiguration()
                            .Enrich.FromLogContext()
                            .WriteTo.Console()
                            .WriteTo.Seq("http://localhost:5341")
                            .CreateLogger();

            builder.Host.UseSerilog();
         
            builder.Services.AddControllers();

            builder.Services.Configure<SmtpOptions>(
                builder.Configuration.GetSection("Smtp"));

            builder.Services.AddScoped<IContactRepository, ContactRepository>();

            builder.Services.AddScoped<ICreateContactUseCase, CreateContactUseCase>();
            builder.Services.AddScoped<IUpdateContactUseCase, UpdateContactUseCase>();
            builder.Services.AddScoped<IDeleteContactUseCase, DeleteContactUseCase>();
            builder.Services.AddScoped<IGetContactByIdUseCase, GetContactByIdUseCase>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Provide Serilog logger to DI consumers (use case constructors, etc.)
            builder.Services.AddSingleton<Serilog.ILogger>(_ => Log.Logger);

            builder.Services.AddOptions<SmtpOptions>()
                .Bind(builder.Configuration.GetSection("Smtp"))
                .Validate(o => !string.IsNullOrWhiteSpace(o.Host), "SMTP Host is required.")
                .Validate(o => !string.IsNullOrWhiteSpace(o.From), "SMTP From is required.")
                .Validate(o => o.Port > 0, "SMTP Port must be greater than 0.")
                .ValidateOnStart();
            
            builder.Services.AddScoped<IEmailSender, MailKitEmailSender>();


            // CORS CONFIGURATION (NEW)
            // Register CORS and define a named policy for your frontend
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontendDevClient", policy =>
                {
                    //  خليته كومنت دلوقتي عشان اتفادى مشاكل الكورس دلوقتي 
                    // var frontendUrl = builder.Configuration["FrontendUrl"]
                    // var frontendUrl = builder.Configuration[]
                    //                 ?? throw new InvalidOperationException("FrontendUrl is not configured");
                    var frontendUrl = "http://localhost:5173";
                    policy.WithOrigins(frontendUrl) // React/Vite frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // ENABLE CORS MIDDLEWARE (NEW)
            // Apply the CORS policy BEFORE authorization
            app.UseCors("AllowFrontendDevClient");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}