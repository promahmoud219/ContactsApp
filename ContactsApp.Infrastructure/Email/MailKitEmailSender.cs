using ContactsApp.Core.Services.Email;  
using MailKit.Net.Smtp;          
using MailKit.Security;         
using Microsoft.Extensions.Options;  
using MimeKit;       


namespace ContactsApp.Infrastructure.Email
{ 
    public sealed class MailKitEmailSender : IEmailSender
    { 
        private readonly SmtpOptions _options;
         
        public MailKitEmailSender(IOptions<SmtpOptions> options)
        {
            _options = options.Value;  
        }
         
        public async Task SendAsync(
            string to,
            string subject,
            string body,
            CancellationToken cancellationToken = default)  
        { 
            var message = new MimeMessage();
             
            message.From.Add(new MailboxAddress(_options.DisplayName, _options.From));
             
            message.To.Add(MailboxAddress.Parse(to));
             
            message.Subject = subject;
             
            message.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = body
            };
             
            using var client = new SmtpClient();
             
            await client.ConnectAsync(
                _options.Host,
                _options.Port,
                _options.UseSsl ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls,
                cancellationToken);
             
            if (!string.IsNullOrWhiteSpace(_options.UserName))
            { 
                await client.AuthenticateAsync(
                    _options.UserName,
                    _options.Password,
                    cancellationToken);
            }
             
            await client.SendAsync(message, cancellationToken);
             
            await client.DisconnectAsync(true, cancellationToken);
        }
    }
}