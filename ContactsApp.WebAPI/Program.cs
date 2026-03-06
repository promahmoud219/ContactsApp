using ContactsApp.Infrastructure.Repositories;
using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Contacts.UseCases.CreateContact;
using ContactsApp.Core.Contacts.UseCases.DeleteContact;

namespace ContactsApp.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<ICreateContactUseCase, CreateContactUseCase>();
            builder.Services.AddScoped<IDeleteContactUseCase, DeleteContactUseCase>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Swagger (Development only)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}   