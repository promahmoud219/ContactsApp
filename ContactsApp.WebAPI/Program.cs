using ContactsApp.Infrastructure.Repositories;
using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Contacts.UseCases.AddContact;





namespace ContactsApp.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // i commented this line because i found an error. it says that the ContactRepository class does not exist in the ContactsApp.Infrastructure.Repositories namespace. you should check if you have created the ContactRepository class and if it is in the correct namespace. if you have not created the ContactRepository class, you can create it and implement the IContactRepository interface. if you have created the ContactRepository class but it is in a different namespace, you should update the using statement at the top of this file to include the correct namespace.
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IAddContactUseCase, AddContactUseCase>();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}   