namespace ContactsApp.Core.Services.Email
{
    public interface IEmailSender
    {
        Task SendAsync(
            string to,
            string subject,
            string body,
            CancellationToken cancellationToken = default);
    }
}
