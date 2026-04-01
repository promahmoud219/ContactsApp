namespace ContactsApp.Infrastructure.Email
{
    public sealed class SmtpOptions
    {
        public string DisplayName { get; set; } = "ContactsApp";
        public string From { get; set; } = default!;
        public string Host { get; set; } = default!;
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
